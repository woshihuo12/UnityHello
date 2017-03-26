using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.IO;

namespace KEngine
{
    /// <summary>
    /// Some tool function for time, bytes, MD5, or something...
    /// </summary>
    public class KTool
    {
        private static readonly Dictionary<string, Shader> CacheShaders = new Dictionary<string, Shader>();
        // Shader.Find是一个非常消耗的函数，因此尽量缓存起来

        /// <summary>
        /// Whether In Wifi or Cable Network
        /// </summary>
        /// <returns></returns>
        public static bool IsWifi()
        {
            return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
        }

        /// <summary>
        /// 获取最近的2次方
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int GetNearestPower2(int num)
        {
            return (int)(Mathf.Pow(2, Mathf.Ceil(Mathf.Log(num) / Mathf.Log(2))));
        }

        /// <summary>
        /// 判断一个数是否2的次方
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool CheckPow2(int num)
        {
            int i = 1;
            while (true)
            {
                if (i > num)
                    return false;
                if (i == num)
                    return true;
                i = i * 2;
            }
        }

        /// <summary>
        /// 模仿 NGUISelectionTool的同名方法，将位置旋转缩放清零
        /// </summary>
        /// <param name="t"></param>
        public static void ResetLocalTransform(Transform t)
        {
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

        // 最大公约数
        public static int GetGCD(int a, int b)
        {
            if (a < b)
            {
                int t = a;
                a = b;
                b = t;
            }
            while (b > 0)
            {
                int t = a % b;
                a = b;
                b = t;
            }
            return a;
        }

        /// <summary>
        /// Find Type from every assembly
        /// </summary>
        /// <param name="type"></param>
        /// <param name="qualifiedTypeName"></param>
        /// <returns></returns>
        public static Type FindType(string qualifiedTypeName)
        {
            Type t = Type.GetType(qualifiedTypeName);
            if (t != null)
            {
                return t;
            }
            else
            {
                Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
                for (int n = 0; n < Assemblies.Length; n++)
                {
                    Assembly asm = Assemblies[n];
                    t = asm.GetType(qualifiedTypeName);
                    if (t != null)
                        return t;
                }
                return null;
            }
        }

        /// <summary>
        /// Destroy a game object's children
        /// </summary>
        /// <param name="go"></param>
        public static void DestroyGameObjectChildren(GameObject go)
        {
            var tran = go.transform;

            while (tran.childCount > 0)
            {
                var child = tran.GetChild(0);

                if (Application.isEditor && !Application.isPlaying)
                {
                    child.parent = null; // 清空父, 因为.Destroy非同步的
                    GameObject.DestroyImmediate(child.gameObject);
                }
                else
                {
                    GameObject.Destroy(child.gameObject);
                    // 预防触发对象的OnEnable，先Destroy
                    child.parent = null; // 清空父, 因为.Destroy非同步的
                }
            }
        }

        public static Shader FindShader(string shaderName)
        {
            Shader shader;
            if (!CacheShaders.TryGetValue(shaderName, out shader))
            {
                shader = Shader.Find(shaderName);
                CacheShaders[shaderName] = shader;
                if (shader == null)
                    Log.Error("缺少Shader：{0}  ， 检查Graphics Settings的预置shader", shaderName);
            }

            return shader;
        }

        // 同Lua, Lib:GetUtcDay
        public static int GetUtcDay()
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime now = DateTime.UtcNow;
            var span = now - origin;
            return span.Days;
        }

        public static int GetDeltaMinutes(DateTime origin)
        {
            DateTime now = DateTime.UtcNow;
            var span = now - origin;
            return span.Minutes;
        }

        /// <summary>
        /// Utc毫秒转Utc时间
        /// </summary>
        /// <param name="utcTime"></param>
        /// <param name="zone">默认0时区</param>
        /// <returns></returns>
        public static DateTime GetDateTimeByUtcMilliseconds(long utcTime, int zone = 0)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddMilliseconds(utcTime).AddHours(zone);
        }

        /// <summary>
        /// Utc秒转Utc时间
        /// </summary>
        /// <param name="unixTimeStamp"></param>
        /// <param name="zone">默认0时区</param>
        /// <returns></returns>
        public static DateTime GetDateTimeByUtcSeconds(double unixTimeStamp, int zone = 0)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(unixTimeStamp).AddHours(zone);
        }

        /// <summary>
        /// Unix時間總毫秒數
        /// </summary>
        /// <returns></returns>
        public static double GetUtcMilliseconds()
        {
            return GetUtcMilliseconds(DateTime.UtcNow);
        }

        /// <summary>
        /// Unix時間總毫秒數
        /// </summary>
        /// <returns></returns>
        public static double GetUtcMilliseconds(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return diff.TotalMilliseconds;
        }

        /// <summary>
        /// Unix時間總秒數
        /// </summary>
        /// <returns></returns>
        public static double GetUtcSeconds()
        {
            return GetUtcSeconds(DateTime.UtcNow);
        }

        /// <summary>
        /// Unix時間總秒數
        /// </summary>
        /// <returns></returns>
        public static double GetUtcSeconds(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = date - origin;
            return diff.TotalSeconds;
        }

        /// <summary>
        /// Recursively set the game object's layer.
        /// </summary>
        public static void SetLayer(GameObject go, int layer)
        {
            go.layer = layer;
            var t = go.transform;

            for (int i = 0, imax = t.childCount; i < imax; ++i)
            {
                var child = t.GetChild(i);
                SetLayer(child.gameObject, layer);
            }
        }

        /// <summary>
        /// 传入uri寻找指定控件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="findTrans"></param>
        /// <param name="uri"></param>
        /// <param name="isLog"></param>
        /// <returns></returns>
        public static T GetChildComponent<T>(string uri, Transform findTrans, bool isLog = true) where T : Component
        {
            if (findTrans == null)
                return default(T);
            Transform trans = findTrans.Find(uri);
            if (trans == null)
            {
                if (isLog)
                    Log.Error("Get Child Error: " + uri);
                return default(T);
            }

            return (T)trans.GetComponent(typeof(T));
        }

        public static GameObject DFSFindObject(Transform parent, string name)
        {
            for (int i = 0; i < parent.childCount; ++i)
            {
                Transform node = parent.GetChild(i);
                if (node.name == name)
                    return node.gameObject;

                GameObject target = DFSFindObject(node, name);
                if (target != null)
                    return target;
            }

            return null;
        }

        public static GameObject GetGameObject(string name, Transform findTrans, bool isLog = true)
        {
            GameObject obj = DFSFindObject(findTrans, name);
            if (obj == null)
            {
                if (isLog)
                {
                    Log.Error("Find GemeObject Error: " + name);
                }
                return null;
            }
            return obj;
        }

        public static void SetChild(GameObject child, GameObject parent, bool selfRotation = false, bool selfScale = false)
        {
            SetChild(child.transform, parent.transform, selfRotation, selfScale);
        }

        public static void SetChild(Transform child, Transform parent, bool selfRotation = false, bool selfScale = false)
        {
            child.parent = parent;
            ResetTransform(child, selfRotation, selfScale);
        }

        public static void ResetTransform(UnityEngine.Transform transform, bool selfRotation = false, bool selfScale = false)
        {
            transform.localPosition = UnityEngine.Vector3.zero;
            if (!selfRotation)
                transform.localEulerAngles = UnityEngine.Vector3.zero;

            if (!selfScale)
                transform.localScale = UnityEngine.Vector3.one;
        }

        //获取从父节点到自己的完整路径
        public static string GetRootPathName(UnityEngine.Transform transform)
        {
            var pathName = "/" + transform.name;
            while (transform.parent != null)
            {
                transform = transform.parent;
                pathName += "/" + transform.name;
            }
            return pathName;
        }

        // 获取指定流的MD5
        public static string MD5_Stream(Stream stream)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider get_md5 =
                new System.Security.Cryptography.MD5CryptoServiceProvider();

            byte[] hash_byte = get_md5.ComputeHash(stream);

            string resule = System.BitConverter.ToString(hash_byte);
            resule = resule.Replace("-", "");
            return resule;
        }

        public static string MD5_File(string filePath)
        {
            try
            {
                using (FileStream get_file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return MD5_Stream(get_file);
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public static byte[] MD5_bytes(string str)
        {
            // MD5 文件名
            var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return md5.ComputeHash(System.Text.Encoding.Unicode.GetBytes(str));
        }

        // 字符串16位 MD5
        public static string MD5_16bit(string str)
        {
            byte[] md5bytes = MD5_bytes(str);
            str = System.BitConverter.ToString(md5bytes, 4, 8);
            str = str.Replace("-", "");
            return str;
        }

        public static T ToEnum<T>(string e)
        {
            return (T)Enum.Parse(typeof(T), e);
        }

        // 整形渐近，+1或-1 , kk
        public static int IntLerp(int from, int to)
        {
            if (from > to)
                return from - 1;
            else if (from < to)
                return from + 1;
            else
                return from;
        }

        // 粒子特效比例缩放
        public static void ScaleParticleSystem(GameObject gameObj, float scale)
        {
            var notFind = true;
            foreach (ParticleSystem p in gameObj.GetComponentsInChildren<ParticleSystem>(true))
            {
                notFind = false;
                p.startSize *= scale;
                p.startSpeed *= scale;
                p.startRotation *= scale;
                p.transform.localScale *= scale;
            }
            if (notFind)
            {
                gameObj.transform.localScale = new Vector3(scale, scale, 1);
            }
        }

        //设置粒子系统的RenderQueue
        public static void SetParticleSystemRenderQueue(Transform parent, int renderQueue = 3900)
        {
            int childCount = parent.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (child.childCount > 0)
                    SetParticleSystemRenderQueue(child, renderQueue);
                if (child.GetComponent<ParticleSystem>() != null)
                {
                    var particleSystem = child.GetComponent<ParticleSystem>();
                    if (particleSystem.GetComponent<Renderer>().sharedMaterial != null)
                        particleSystem.GetComponent<Renderer>().sharedMaterial.renderQueue = renderQueue;
                }
            }
            if (parent.GetComponent<ParticleSystem>() != null)
            {
                var particleSystem = parent.GetComponent<ParticleSystem>();
                //bug 当同一个窗口有多个使用相同的Material时，其它组件的Material在关闭后会被释放
                if (particleSystem.GetComponent<Renderer>().sharedMaterial != null)
                    particleSystem.GetComponent<Renderer>().sharedMaterial.renderQueue = renderQueue;
            }
        }

        // 测试有无写权限
        public static bool HasWriteAccessToFolder(string folderPath)
        {
            try
            {
                string tmpFilePath = Path.Combine(folderPath, Path.GetRandomFileName());
                using (
                    FileStream fs = new FileStream(tmpFilePath, FileMode.CreateNew, FileAccess.ReadWrite,
                        FileShare.ReadWrite))
                {
                    StreamWriter writer = new StreamWriter(fs);
                    writer.Write("1");
                }
                File.Delete(tmpFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SetStaticRecursively(GameObject obj)
        {
            LinkedList<Transform> transList = new LinkedList<Transform>();
            transList.AddLast(obj.transform);

            while (transList.Count > 0)
            {
                Transform trans = transList.First.Value;
                transList.RemoveFirst();

                trans.gameObject.isStatic = true;

                for (int i = 0; i < trans.childCount; ++i)
                {
                    transList.AddLast(trans.GetChild(i));
                }
            }
        }

        // 标准角度，角度负数会转正
        public static float GetNormalizedAngle(float _anyAngle)
        {
            _anyAngle = _anyAngle % 360;
            if (_anyAngle < 0)
            {
                _anyAngle += 360;
            }
            return _anyAngle;
        }
    }
}