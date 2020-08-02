using LuaInterface;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Mobcast.Coffee.UIExtensions;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace LuaFramework
{
    public class SocialHelpManager : MonoBehaviour
    {
        private string[] mImageCacheRoots;
        private string mImageCacheRoot;
        private string mFbImageCacheDir;
        private static string INVALID_CHARS = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        /// <summary>
        /// 初始化游戏管理器
        /// </summary>
        void Start()
        {
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        void Init()
        {
            //mImageCacheRoots = new string[2] { Application.temporaryCachePath, Application.persistentDataPath };
            mImageCacheRoots = new string[1] { Application.persistentDataPath };
            mImageCacheRoot = GetImageCacheRoot();
            mFbImageCacheDir = mImageCacheRoot + "/FacebookProfileImages";
        }

        public void SetImageSprite(Image img, string socialId, string imgUrl)
        {
            if (img == null)
            {
                return;
            }
            GetImageSprite2(socialId, imgUrl, delegate (Sprite sp)
            {
                img.sprite = sp;
            });
        }

        public void SetAtlasImageSprite(AtlasImage img, string socialId, string imgUrl)
        {
            if (img == null)
            {
                return;
            }
            GetImageSprite2(socialId, imgUrl, delegate (Sprite sp)
            {
                img.sprite = sp;
            });
        }

        public void SetImageTex(RawImage img, string socialId, string imgUrl)
        {
            if (img == null)
            {
                return;
            }
            GetImageTexture2(socialId, imgUrl, delegate (Texture2D tex)
            {
                img.texture = tex;
            });
        }

        public void GetImageSprite(string socialId, string imgUrl, LuaFunction handler)
        {
            var tmpHandler = handler;
            DoGetImageTexture(socialId, imgUrl, delegate (Texture2D tex)
            {
                Sprite obj = null;
                if (tex != null)
                {
                    obj = BuildSprite(tex);
                }

                tmpHandler.BeginPCall();
                tmpHandler.Push(obj);
                tmpHandler.PCall();
                tmpHandler.EndPCall();
            });
        }

        public void GetImageTexture(string socialId, string imgUrl, LuaFunction handler)
        {
            var tmpHandler = handler;
            DoGetImageTexture(socialId, imgUrl, delegate (Texture2D tex)
            {
                Sprite obj = null;
                if (tex != null)
                {
                    obj = BuildSprite(tex);
                }

                tmpHandler.BeginPCall();
                tmpHandler.Push(obj);
                tmpHandler.PCall();
                tmpHandler.EndPCall();
            });
        }

        private void GetImageSprite2(string socialId, string imgUrl, Action<Sprite> handler)
        {
            DoGetImageTexture(socialId, imgUrl, delegate (Texture2D tex)
            {
                Sprite obj = null;
                if (tex != null)
                {
                    obj = BuildSprite(tex);
                }
                handler(obj);
            });
        }

        private void GetImageTexture2(string socialId, string imgUrl, Action<Texture2D> handler)
        {
            DoGetImageTexture(socialId, imgUrl, handler);
        }

        private void DoGetImageTexture(string socialId, string imgUrl, Action<Texture2D> handler)
        {
            if (string.IsNullOrEmpty(imgUrl))
            {
                if (handler != null)
                {
                    handler(Texture2D.whiteTexture);
                }
                return;
            }
            string cachedUserIdName = $"{socialId}";
            if (HasCachedImage(cachedUserIdName))
            {
                Texture2D texture2D = new Texture2D(4, 4, TextureFormat.RGB24, false);
                texture2D.wrapMode = TextureWrapMode.Clamp;
                byte[] data = File.ReadAllBytes(ImageCacheUrl(cachedUserIdName));
                texture2D.LoadImage(data);
                if (handler != null)
                {
                    handler(texture2D);
                }
            }
            else
            {
                DownloadImageTexture(imgUrl, delegate (byte[] s)
                {
                    OnImageTextureRetrieved(cachedUserIdName, s, handler);
                });
            }
        }

        private void OnImageTextureRetrieved(string imageId, byte[] bytes, Action<Texture2D> handler)
        {
            Texture2D texture2D = null;
            if (bytes != null && bytes.Length > 0)
            {
                try
                {
                    if (!HasCachedImage(imageId))
                    {
                        CacheImage(imageId, bytes);
                    }
                    texture2D = new Texture2D(1, 1, TextureFormat.RGB24, false);
                    texture2D.wrapMode = TextureWrapMode.Clamp;
                    texture2D.LoadImage(bytes);
                }
                catch (IOException ex)
                {
                    Debug.LogError(ex.ToString() + ":An error occured while attempting to cache image.");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Debug.LogError(ex2.ToString() + ":An error occured while attempting to cache image.");
                }
            }
            if (handler != null)
            {
                handler.Invoke(texture2D);
            }
        }

        private string GetImageCacheRoot()
        {
            string result = string.Empty;
            for (int i = 0; i < mImageCacheRoots.Length; i++)
            {
                if (!string.IsNullOrEmpty(mImageCacheRoots[i]))
                {
                    result = mImageCacheRoots[i];
                    break;
                }
            }
            return result;
        }

        private string ImageCacheDirectoy
        {
            get
            {
                return mFbImageCacheDir;
            }
        }

        private void DownloadImageTexture(string imageUrl, Action<byte[]> handler)
        {
            StartCoroutine(RetrieveImageTexture(imageUrl, handler));
        }

        private IEnumerator RetrieveImageTexture(string imageUrl, Action<byte[]> handler)
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(imageUrl))
            {
                yield return uwr.SendWebRequest();
                if (!uwr.isNetworkError && !uwr.isHttpError)
                {
                    handler(uwr.downloadHandler.data);
                }
                else
                {
                    handler(null);
                }
            }
        }

        private bool HasCachedImage(string socialId)
        {
            var filePath = ImageCacheUrl(socialId);
            bool exist = File.Exists(filePath);
            if (!exist)
            {
                return false;
            }
            var createTime = File.GetCreationTimeUtc(filePath);
            if ((System.DateTime.Now - createTime).Seconds >= LuaFramework.Util.kFbImageCacheSeconds)
            {
                try
                {
                    File.Delete(filePath);
                }
                catch
                {
                }
                return false;
            }
            return true;
        }

        private void CacheImage(string socialId, byte[] bytes)
        {
            if (!Directory.Exists(ImageCacheDirectoy))
            {
                Directory.CreateDirectory(ImageCacheDirectoy);
            }
            string path = ImageCacheUrl(socialId);
            File.WriteAllBytes(path, bytes);
        }

        private string ImageCacheUrl(string userId)
        {
            return string.Format("{0}/{1}.png", ImageCacheDirectoy, NormalizeImageNameForCaching(userId));
        }

        private string NormalizeImageNameForCaching(string id)
        {
            string iNVALID_CHARS = INVALID_CHARS;
            for (int i = 0; i < iNVALID_CHARS.Length; i++)
            {
                var tmpStr = iNVALID_CHARS[i].ToString();
                if (id.Contains(tmpStr))
                {
                    id = id.Replace(tmpStr, "_");
                }
            }
            return id;
        }

        private Sprite BuildSprite(Texture2D texture)
        {
            //float pixelsPerUnit = (float)texture.width * 1f / ((float)width * 1f) * 100f;
            return Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        void OnDestroy()
        {
        }
    }
}