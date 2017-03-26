using UnityEngine;
using System.Collections;
using System;

public class AssetBundleLoaderOld : IDisposable
{
    static Locker<string> mAssetLocker = new Locker<string>();
    public AssetBundle mAssetBundle;
    public UnityEngine.Object mObj;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    private IEnumerator LoadBundleFunc(string assetPath, int version, uint crc)
    {
        mAssetBundle = null;
        WWW download = null;
        if (Caching.enabled)
        {
            while (!Caching.ready)
            {
                yield return null;
            }
            download = WWW.LoadFromCacheOrDownload(assetPath, version, crc);
        }
        else
        {
            download = new WWW(assetPath);
        }
        yield return download;
        if (download.error != null)
        {
            Debug.LogWarning(download.error);
            download.Dispose();
        }
        else
        {
            mAssetBundle = download.assetBundle;
            download.Dispose();
            download = null;
        }
    }

    public IEnumerator LoadBundle(string assetPath, int version, uint crc)
    {
        while (mAssetLocker.IsLock(assetPath))
        {
            yield return null;
        }

        mAssetLocker.Lock(assetPath);
        yield return Globals.Instance.StartCoroutine(LoadBundleFunc(assetPath, version, crc));
        mAssetLocker.UnLock(assetPath);
    }

    public IEnumerator LoadBundleAsset<T>(string assetPath, int version, uint crc, string assetName)
        where T : UnityEngine.Object
    {
        while (mAssetLocker.IsLock(assetPath))
        {
            yield return null;
        }

        mAssetLocker.Lock(assetPath);

        mObj = null;
        yield return Globals.Instance.StartCoroutine(LoadBundleFunc(assetPath, version, crc));

        if (mAssetBundle == null)
        {
            Debug.LogWarning("assetBundle is null!");
            yield return null;
        }
        else
        {
            if (string.IsNullOrEmpty(assetName))
            {
                mObj = mAssetBundle.mainAsset;
            }
            else
            {
                AssetBundleRequest assetReq = mAssetBundle.LoadAssetAsync(assetName, typeof(T));
                yield return assetReq;
                mObj = assetReq.asset;
            }
        }

        mAssetLocker.UnLock(assetPath);
    }
}
