using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SimplePM
{
    public class InstanceHandler
    {
        public delegate GameObject InstantiateDelegate(GameObject prefab, Vector3 pos, Quaternion rot);
        public delegate void DestroyDelegate(GameObject instance);

        public static InstantiateDelegate InstantiateDelegates;
        public static DestroyDelegate DestroyDelegates;

        internal static GameObject InstantiatePrefab(GameObject prefab, Vector3 pos, Quaternion rot)
        {
            if (InstanceHandler.InstantiateDelegates != null)
            {
                return InstanceHandler.InstantiateDelegates(prefab, pos, rot);
            }
            else
            {
                return Object.Instantiate(prefab, pos, rot) as GameObject;
            }
        }

        internal static void DestroyInstance(GameObject instance)
        {
            if (InstanceHandler.DestroyDelegates != null)
            {
                InstanceHandler.DestroyDelegates(instance);
            }
            else
            {
                Object.Destroy(instance);
            }
        }
    }

    public class SimplePoolManager
    {
        private static SimplePoolManager sInstance = null;
        public static SimplePoolManager Instance()
        {
            if (sInstance == null)
            {
                sInstance = new SimplePoolManager();
            }
            return sInstance;
        }

        public delegate void OnCreatedDelegate(SpawnPool pool);
        internal Dictionary<string, OnCreatedDelegate> mOnCreatedDelegates = new Dictionary<string, OnCreatedDelegate>();

        private Dictionary<string, SpawnPool> mPools = new Dictionary<string, SpawnPool>();

        public void AddOnCreatedDelegate(string poolName, OnCreatedDelegate createdDelegate)
        {
            if (!mOnCreatedDelegates.ContainsKey(poolName))
            {
                mOnCreatedDelegates.Add(poolName, createdDelegate);
                return;
            }
            mOnCreatedDelegates[poolName] += createdDelegate;
        }

        public void RemoveOnCreatedDelegate(string poolName, OnCreatedDelegate createdDelegate)
        {
            if (mOnCreatedDelegates.ContainsKey(poolName))
            {
                mOnCreatedDelegates[poolName] -= createdDelegate;
            }
        }

        private bool AssertValidPoolName(string poolName)
        {
            string tmpPoolName = poolName.Replace("Pool", "");
            // Warn if "Pool" was used in poolName
            if (tmpPoolName != poolName)
            {
                // Log a warning and continue on with the fixed name
                string msg = string.Format("'{0}' has the word 'Pool' in it. " +
                       "This word is reserved for GameObject defaul naming. " +
                       "The pool name has been changed to '{1}'",
                       poolName, tmpPoolName);

                Debug.LogWarning(msg);
                poolName = tmpPoolName;
            }
            if (mPools.ContainsKey(poolName))
            {
                Debug.Log(string.Format("A pool with the name '{0}' already exists",
                                        poolName));
                return false;
            }
            return true;
        }

        public SpawnPool CreateSpawnPool(string poolName)
        {
            GameObject owner = new GameObject(poolName + "Pool");
            return owner.AddComponent<SpawnPool>();
        }

        public SpawnPool CreateSpawnPool(string poolName, GameObject owner)
        {
            if (!AssertValidPoolName(poolName))
            {
                return null;
            }

            string ownerName = owner.gameObject.name;
            try
            {
                owner.gameObject.name = poolName;
                // Note: This will use SpawnPool.Awake() to finish init and self-add the pool
                return owner.AddComponent<SpawnPool>();
            }
            finally
            {
                // Runs no matter what
                owner.gameObject.name = ownerName;
            }
        }

        public bool DestroySpawnPool(string poolName)
        {
            SpawnPool spawnPool;
            if (!mPools.TryGetValue(poolName, out spawnPool))
            {
                return false;
            }
            UnityEngine.Object.Destroy(spawnPool.gameObject);
            return true;
        }

        public void DestroyAllSpawnPool()
        {
            foreach (var tmp in mPools)
            {
                UnityEngine.Object.Destroy(tmp.Value);
            }
            mPools.Clear();
        }

        internal void AddSpawnPool(SpawnPool spawnPool)
        {
            if (mPools.ContainsKey(spawnPool.PoolName))
            {
                return;
            }

            mPools.Add(spawnPool.PoolName, spawnPool);
            if (mOnCreatedDelegates.ContainsKey(spawnPool.PoolName))
            {
                mOnCreatedDelegates[spawnPool.PoolName](spawnPool);
            }
        }

        internal bool RemoveSpawnPool(SpawnPool spawnPool)
        {
            if (!mPools.ContainsKey(spawnPool.PoolName) && Application.isPlaying)
            {
                Debug.LogError(string.Format("PoolManager: Unable to remove '{0}'. " +
                                                "Pool not in PoolManager",
                                            spawnPool.PoolName));
                return false;
            }
            mPools.Remove(spawnPool.PoolName);
            return true;
        }

        public bool ContainsSpawnPool(string poolName)
        {
            return mPools.ContainsKey(poolName);
        }
    }

    public class SpawnPool : MonoBehaviour
    {
        public delegate GameObject InstantiateDelegate(GameObject prefab, Vector3 pos, Quaternion rot);
        public delegate void DestroyDelegate(GameObject instance);

        public InstantiateDelegate instantiateDelegates;
        public DestroyDelegate destroyDelegates;

        private string mPoolName = string.Empty;
        public string PoolName
        {
            get
            {
                return mPoolName;
            }
            set
            {
                mPoolName = value;
            }
        }

        private bool mMatchPoolScale = false;
        public bool MatchPoolScale
        {
            get
            {
                return mMatchPoolScale;
            }
            set
            {
                mMatchPoolScale = value;
            }
        }

        private bool mMatchPoolLayer = false;
        public bool MatchPoolLayer
        {
            get
            {
                return mMatchPoolLayer;
            }
            set
            {
                mMatchPoolLayer = value;
            }
        }

        private bool mDontReparent = false;
        public bool DontReparent
        {
            get
            {
                return mDontReparent;
            }
            set
            {
                mDontReparent = value;
            }
        }

        private bool mDontDestroyOnLoad = false;
        public bool IsDontDestroyOnLoad
        {
            get
            {
                return mDontDestroyOnLoad;
            }
            set
            {
                mDontDestroyOnLoad = value;
                if (Group != null)
                {
                    Object.DontDestroyOnLoad(Group.gameObject);
                }
            }
        }

        private bool mLogMessages = false;
        public bool LogMessages
        {
            get
            {
                return mLogMessages;
            }
            set
            {
                mLogMessages = value;
            }
        }

        private Transform mGroup;
        public Transform Group
        {
            get
            {
                return mGroup;
            }
            set
            {
                mGroup = value;
            }
        }

        private List<PrefabPool> mPerPrefabPoolOptions = new List<PrefabPool>();
        public List<PrefabPool> PerPrefabPoolOptions
        {
            get
            {
                return mPerPrefabPoolOptions;
            }
            set
            {
                mPerPrefabPoolOptions = value;
            }
        }

        private float mMaxParticleDespawnTime = 300;
        public float MaxParticleDespawnTime
        {
            get
            {
                return mMaxParticleDespawnTime;
            }
            set
            {
                mMaxParticleDespawnTime = value;
            }
        }

        private Dictionary<string, Transform> mPrefabs = new Dictionary<string, Transform>();

        private List<PrefabPool> mPrefabPools = new List<PrefabPool>();
        public Dictionary<string, PrefabPool> PrefabPools
        {
            get
            {
                var dict = new Dictionary<string, PrefabPool>();
                for (int i = 0; i < mPrefabPools.Count; i++)
                {
                    dict[mPrefabPools[i].PrefabGO.name] = mPrefabPools[i];
                }
                return dict;
            }
        }

        internal List<Transform> mSpawned = new List<Transform>();
        public List<Transform> Spawned
        {
            get
            {
                return mSpawned;
            }
        }

        private void Awake()
        {
            if (IsDontDestroyOnLoad)
            {
                Object.DontDestroyOnLoad(gameObject);
            }

            Group = transform;

            if (string.IsNullOrEmpty(PoolName))
            {
                PoolName = Group.name.Replace("Pool", "");
                PoolName = PoolName.Replace("(Clone)", "");
            }

            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0}: Initializing..", PoolName));
            }

            for (int i = 0; i < PerPrefabPoolOptions.Count; ++i)
            {
                if (PerPrefabPoolOptions[i].Prefab == null)
                {
                    continue;
                }

                PerPrefabPoolOptions[i].InstanceConstructor();
                CreatePrefabPool(PerPrefabPoolOptions[i]);
            }

            SimplePoolManager.Instance().AddSpawnPool(this);
        }

        internal GameObject InstantiatePrefab(GameObject prefab, Vector3 pos, Quaternion rot)
        {
            if (this.instantiateDelegates != null)
            {
                return this.instantiateDelegates(prefab, pos, rot);
            }
            else
            {
                return InstanceHandler.InstantiatePrefab(prefab, pos, rot);
            }
        }

        internal void DestroyInstance(GameObject instance)
        {
            if (this.destroyDelegates != null)
            {
                this.destroyDelegates(instance);
            }
            else
            {
                InstanceHandler.DestroyInstance(instance);
            }
        }

        private void OnDestroy()
        {
            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0}: Destroying...", PoolName));
            }

            SimplePoolManager.Instance().RemoveSpawnPool(this);

            StopAllCoroutines();
            mSpawned.Clear();
            foreach (PrefabPool pool in mPrefabPools)
            {
                pool.SelfDestruct();
            }
            mPrefabPools.Clear();
            mPrefabs.Clear();
        }

        public PrefabPool GetPrefabPool(Transform prefab)
        {
            for (int i = 0; i < mPrefabPools.Count; ++i)
            {
                if (mPrefabPools[i].PrefabGO == null)
                {
                    continue;
                }

                if (mPrefabPools[i].PrefabGO == prefab.gameObject)
                {
                    return mPrefabPools[i];
                }
            }
            return null;
        }

        public PrefabPool GetPrefabPool(GameObject prefab)
        {
            for (int i = 0; i < mPrefabPools.Count; ++i)
            {
                if (mPrefabPools[i].PrefabGO == null)
                {
                    continue;
                }

                if (mPrefabPools[i].PrefabGO == prefab)
                {
                    return mPrefabPools[i];
                }
            }

            return null;
        }

        public void CreatePrefabPool(PrefabPool prefabPool)
        {
            bool isAlreadyPool = GetPrefabPool(prefabPool.Prefab) == null ? false : true;
            if (isAlreadyPool)
            {
                return;
            }

            prefabPool.OwnedSpawnPool = this;
            mPrefabPools.Add(prefabPool);

            mPrefabs.Add(prefabPool.Prefab.name, prefabPool.Prefab);

            if (!prefabPool.PreLoaded)
            {
                prefabPool.PreloadInstances();
            }
        }

        public Transform GetPrefab(Transform instance)
        {
            for (int i = 0; i < mPrefabPools.Count; i++)
            {
                if (mPrefabPools[i].Contains(instance))
                {
                    return mPrefabPools[i].Prefab;
                }
            }
            return null;
        }

        public GameObject GetPrefab(GameObject instance)
        {
            for (int i = 0; i < mPrefabPools.Count; i++)
            {
                if (mPrefabPools[i].Contains(instance.transform))
                {
                    return mPrefabPools[i].PrefabGO;
                }
            }
            return null;
        }



        public void Add(Transform inst, string prefabName, bool despawn, bool parent)
        {
            for (int i = 0; i < mPrefabPools.Count; ++i)
            {
                if (mPrefabPools[i].PrefabGO == null)
                {
                    return;
                }

                if (mPrefabPools[i].PrefabGO.name == prefabName)
                {
                    mPrefabPools[i].AddUnpooled(inst, despawn);

                    if (parent)
                    {
                        var worldPositionStays = !(inst is RectTransform);
                        inst.SetParent(Group, worldPositionStays);
                    }

                    if (!despawn)
                    {
                        mSpawned.Add(inst);
                    }

                    return;
                }
            }
        }

        public Transform Spawn(Transform prefab)
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity);
        }

        public Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
        {
            Transform inst = this.Spawn(prefab, pos, rot, null);
            return inst;
        }

        public Transform Spawn(Transform prefab, Transform parent)
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity, parent);
        }

        public Transform Spawn(GameObject prefab)
        {
            return Spawn(prefab.transform);
        }

        public Transform Spawn(GameObject prefab, Transform parent)
        {
            return Spawn(prefab.transform, parent);
        }

        public Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
        {
            return Spawn(prefab.transform, pos, rot);
        }

        public Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent)
        {
            return Spawn(prefab.transform, pos, rot, parent);
        }

        public Transform Spawn(string prefabName)
        {
            Transform prefab = mPrefabs[prefabName];
            return Spawn(prefab);
        }

        public Transform Spawn(string prefabName, Transform parent)
        {
            Transform prefab = mPrefabs[prefabName];
            return Spawn(prefab, parent);
        }

        public Transform Spawn(string prefabName, Vector3 pos, Quaternion rot)
        {
            Transform prefab = mPrefabs[prefabName];
            return Spawn(prefab, pos, rot);
        }

        public Transform Spawn(string prefabName, Vector3 pos, Quaternion rot, Transform parent)
        {
            Transform prefab = mPrefabs[prefabName];
            return Spawn(prefab, pos, rot, parent);
        }

        public AudioSource Spawn(AudioSource prefab, Vector3 pos, Quaternion rot)
        {
            return Spawn(prefab, pos, rot, null);
        }

        public AudioSource Spawn(AudioSource prefab)
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity, null);
        }

        public AudioSource Spawn(AudioSource prefab, Transform parent)
        {
            return Spawn(prefab, Vector3.zero, Quaternion.identity, parent);
        }

        public Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot, Transform parent)
        {
            Transform inst = null;

            PrefabPool tmpPool = GetPrefabPool(prefab);
            if (tmpPool == null)
            {
                tmpPool = new PrefabPool(prefab);
                CreatePrefabPool(tmpPool);
            }

            if (tmpPool != null)
            {
                inst = tmpPool.SpawnInstance(pos, rot);
                if (parent != null)
                {
                    var worldPositionStays = !(inst is RectTransform);
                    inst.SetParent(parent, worldPositionStays);
                    //inst.parent = parent;
                }
                else
                {
                    var worldPositionStays = !(inst is RectTransform);
                    inst.SetParent(Group, worldPositionStays);
                    //inst.parent = Group;
                }

                mSpawned.Add(inst);
                inst.gameObject.BroadcastMessage("OnSpawned", this, SendMessageOptions.DontRequireReceiver);
            }
            return inst;
        }

        private IEnumerator ListForAudioStop(AudioSource src)
        {
            yield return null;

            while (src.isPlaying)
            {
                yield return null;
            }

            if (!src.gameObject.activeInHierarchy)
            {
                src.Stop();
                yield break;
            }

            Despawn(src.transform);
        }

        public AudioSource Spawn(AudioSource prefab, Vector3 pos, Quaternion rot, Transform parent)
        {
            Transform inst = Spawn(prefab.transform, pos, rot, parent);
            if (inst == null) return null;
            var src = inst.GetComponent<AudioSource>();
            src.Play();
            StartCoroutine(ListForAudioStop(src));
            return src;
        }

        private IEnumerator ListenForEmitDespawn(ParticleSystem emitter)
        {
            yield return new WaitForSeconds(emitter.startDelay + 0.25f);

            float safetimer = 0;
            GameObject emitterGO = emitter.gameObject;
            while (emitter.IsAlive(true) && emitterGO.activeInHierarchy)
            {
                safetimer += Time.deltaTime;
                if (safetimer > MaxParticleDespawnTime)
                {
                    Debug.LogWarning
                    (
                          string.Format
                          (
                              "SpawnPool {0}: " +
                                  "Timed out while listening for all particles to die. " +
                                  "Waited for {1}sec.", PoolName, MaxParticleDespawnTime
                          )
                      );
                }
                yield return null;
            }

            if (emitterGO.activeInHierarchy)
            {
                Despawn(emitter.transform);
                emitter.Clear(true);
            }
        }

        public ParticleSystem Spawn(ParticleSystem prefab, Vector3 pos, Quaternion rot)
        {
            return Spawn(prefab, pos, rot, null);
        }

        public ParticleSystem Spawn(ParticleSystem prefab, Vector3 pos, Quaternion rot, Transform parent)
        {
            Transform inst = this.Spawn(prefab.transform, pos, rot, parent);
            if (inst == null) return null;
            ParticleSystem emitter = inst.GetComponent<ParticleSystem>();
            //emitter.Play(true);
            StartCoroutine(ListenForEmitDespawn(emitter));
            return emitter;
        }

        private IEnumerator ListenForEmitDespawn(ParticleEmitter emitter)
        {
            yield return null;
            yield return new WaitForEndOfFrame();

            float safetimer = 0;
            GameObject emitterGO = emitter.gameObject;
            while (emitter.particleCount > 0 && emitterGO.activeInHierarchy)
            {
                safetimer += Time.deltaTime;
                if (safetimer > MaxParticleDespawnTime)
                {
                    Debug.LogWarning
                    (
                        string.Format
                        (
                            "SpawnPool {0}: " +
                                "Timed out while listening for all particles to die. " +
                                "Waited for {1}sec.",
                            PoolName,
                            MaxParticleDespawnTime
                        )
                    );
                }
                yield return null;
            }
            emitter.emit = false;
            if (emitterGO.activeInHierarchy)
            {
                Despawn(emitter.transform);
            }
        }

        public ParticleEmitter Spawn(ParticleEmitter prefab, Vector3 pos, Quaternion rot)
        {
            Transform inst = this.Spawn(prefab.transform, pos, rot);
            if (inst == null) return null;
            ParticleAnimator animator = inst.GetComponent<ParticleAnimator>();
            if (animator != null) animator.autodestruct = false;
            ParticleEmitter emitter = inst.GetComponent<ParticleEmitter>();
            emitter.emit = true;
            StartCoroutine(ListenForEmitDespawn(emitter));
            return emitter;
        }

        public ParticleEmitter Spawn(ParticleEmitter prefab, Vector3 pos, Quaternion rot, string colorPropertyName, Color color)
        {
            Transform inst = Spawn(prefab.transform, pos, rot);
            if (inst == null) return null;

            ParticleAnimator animator = inst.GetComponent<ParticleAnimator>();
            if (animator != null) animator.autodestruct = false;

            ParticleEmitter emitter = inst.GetComponent<ParticleEmitter>();

            emitter.GetComponent<Renderer>().material.SetColor(colorPropertyName, color);
            emitter.emit = true;

            StartCoroutine(ListenForEmitDespawn(emitter));

            return emitter;
        }

        public void Despawn(Transform inst, Transform parent)
        {
            //instance.parent = parent;
            var worldPositionStays = !(inst is RectTransform);
            inst.SetParent(parent, worldPositionStays);
            Despawn(inst);
        }

        private IEnumerator DoDespawnAfterSeconds(Transform instance, float seconds, bool useParent, Transform parent)
        {
            GameObject go = instance.gameObject;
            while (seconds > 0)
            {
                yield return null;
                if (!go.activeInHierarchy)
                {
                    yield break;
                }
                seconds -= Time.deltaTime;
            }
            if (useParent)
            {
                Despawn(instance, parent);
            }
            else
            {
                Despawn(instance);
            }
        }

        public void Despawn(Transform instance, float seconds)
        {
            StartCoroutine(DoDespawnAfterSeconds(instance, seconds, false, null));
        }

        public void Despawn(Transform instance, float seconds, Transform parent)
        {
            StartCoroutine(DoDespawnAfterSeconds(instance, seconds, true, parent));
        }

        public void Despawn(Transform instance)
        {
            bool despawned = false;
            for (int i = 0; i < mPrefabPools.Count; ++i)
            {
                if (mPrefabPools[i].Spawned.Contains(instance))
                {
                    despawned = mPrefabPools[i].DespawnInstance(instance);
                    break;
                }
                else if (mPrefabPools[i].Despawned.Contains(instance))
                {
                    Debug.LogError(
                        string.Format("SpawnPool {0}: {1} has already been despawned. " +
                                  "You cannot despawn something more than once!",
                                   PoolName,
                                   instance.name));
                    return;
                }
            }

            if (!despawned)
            {
                Debug.LogError(string.Format("SpawnPool {0}: {1} not found in SpawnPool",
                               PoolName,
                               instance.name));
                return;
            }

            mSpawned.Remove(instance);
        }

        public void DespawnAll()
        {
            var spawned = new List<Transform>(mSpawned);
            for (int i = 0; i < spawned.Count; i++)
            {
                Despawn(spawned[i]);
            }
        }

        public bool IsSpawned(Transform instance)
        {
            return mSpawned.Contains(instance);
        }
    }

    public class PrefabPool
    {
        private Transform mPrefab;
        public Transform Prefab
        {
            get
            {
                return mPrefab;
            }
        }

        private GameObject mPrefabGO;
        public GameObject PrefabGO
        {
            get
            {
                return mPrefabGO;
            }
        }

        private int mPreLoadAmount = 1;
        public int PreLoadAmount
        {
            get
            {
                return mPreLoadAmount;
            }
            set
            {
                mPreLoadAmount = value;
            }
        }

        private bool mPreLoadTime = false;
        public bool PreLoadTime
        {
            get
            {
                return mPreLoadTime;
            }
            set
            {
                mPreLoadTime = value;
            }
        }

        private int mPreLoadFrames = 2;
        public int PreLoadFrames
        {
            get
            {
                return mPreLoadFrames;
            }
            set
            {
                mPreLoadFrames = value;
            }
        }

        private float mPreLoadDelay = 0f;
        public float PreLoadDelay
        {
            get
            {
                return mPreLoadDelay;
            }
            set
            {
                mPreLoadDelay = value;
            }
        }

        private bool mLimitInstances = false;
        public bool LimitInstances
        {
            get
            {
                return mLimitInstances;
            }
            set
            {
                mLimitInstances = value;
            }
        }

        private int mLimitAmount = 100;
        public int LimitAmount
        {
            get
            {
                return mLimitAmount;
            }
            set
            {
                mLimitAmount = value;
            }
        }

        private bool mLimitFIFO = false;
        public bool LimitFIFO
        {
            get
            {
                return mLimitFIFO;
            }
            set
            {
                mLimitFIFO = value;
            }
        }

        private bool mCullDespawned = false;
        public bool CullDespawned
        {
            get
            {
                return mCullDespawned;
            }
            set
            {
                mCullDespawned = value;
            }
        }

        private int mCullAbove = 50;
        public int CullAbove
        {
            get
            {
                return mCullAbove;
            }
            set
            {
                mCullAbove = value;
            }
        }

        private int mCullDelay = 60;
        public int CullDelay
        {
            get
            {
                return mCullDelay;
            }
            set
            {
                mCullDelay = value;
            }
        }

        private int mCullMaxPerPass = 5;
        public int CullMaxPerPass
        {
            get
            {
                return mCullMaxPerPass;
            }
            set
            {
                mCullMaxPerPass = value;
            }
        }

        private SpawnPool mSpawnPool;
        public SpawnPool OwnedSpawnPool
        {
            get
            {
                return mSpawnPool;
            }
            set
            {
                mSpawnPool = value;
            }
        }

        private bool mCullingActive = false;
        public bool CullingActive
        {
            get
            {
                return mCullingActive;
            }
            set
            {
                mCullingActive = value;
            }
        }

        public int TotalCount
        {
            get
            {
                return mSpawned.Count + mDespawned.Count;
            }
        }

        private bool mPreLoaded = false;
        internal bool PreLoaded
        {
            get
            {
                return mPreLoaded;
            }
            private set
            {
                mPreLoaded = value;
            }
        }



        private List<Transform> mSpawned = new List<Transform>();
        public List<Transform> Spawned
        {
            get
            {
                return mSpawned;
            }
        }

        private List<Transform> mDespawned = new List<Transform>();
        public List<Transform> Despawned
        {
            get
            {
                return mDespawned;
            }
        }


        private bool mForceLogSilent = false;

        private bool mLogMessages = false;
        public bool LogMessages
        {
            get
            {
                if (mForceLogSilent)
                {
                    return false;
                }
                if (OwnedSpawnPool.LogMessages)
                {
                    return true;
                }
                else
                {
                    return mLogMessages;
                }
            }
        }

        public PrefabPool()
        {
        }

        public PrefabPool(Transform prefab)
        {
            mPrefab = prefab;
            mPrefabGO = prefab.gameObject;
        }

        internal void InstanceConstructor()
        {
            mPrefabGO = mPrefab.gameObject;
            mSpawned = new List<Transform>();
            mDespawned = new List<Transform>();
        }

        internal void SelfDestruct()
        {
            mPrefab = null;
            mPrefabGO = null;

            if (mSpawnPool != null)
            {
                Transform tmp = null;
                for (int i = 0; i < mDespawned.Count; ++i)
                {
                    tmp = mDespawned[i];
                    if (tmp == null) continue;
                    mSpawnPool.DestroyInstance(tmp.gameObject);
                }

                for (int i = 0; i < mSpawned.Count; ++i)
                {
                    tmp = mSpawned[i];
                    if (tmp == null) continue;
                    mSpawnPool.DestroyInstance(tmp.gameObject);
                }
            }

            mSpawned.Clear();
            mDespawned.Clear();

            mSpawnPool = null;
        }

        internal bool DespawnInstance(Transform tr)
        {
            return DespawnInstance(tr, true);
        }

        internal bool DespawnInstance(Transform tr, bool sendEventMessage)
        {
            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): Despawning '{2}'",
                       mSpawnPool.PoolName,
                       mPrefab.name,
                       tr.name));
            }

            mSpawned.Remove(tr);
            mDespawned.Add(tr);

            if (sendEventMessage)
            {
                tr.gameObject.BroadcastMessage("OnDespawned", mSpawnPool, SendMessageOptions.DontRequireReceiver);
            }

            tr.gameObject.SetActive(false);

            if (!CullingActive
                && CullDespawned
                && TotalCount > CullAbove)
            {
                CullingActive = true;
                mSpawnPool.StartCoroutine(CoCullDespawned());
            }
            return true;
        }

        internal IEnumerator CoCullDespawned()
        {
            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): CULLING TRIGGERED! " +
                          "Waiting {2}sec to begin checking for despawns...",
                        mSpawnPool.PoolName,
                        mPrefab.name,
                        CullDelay));
            }

            yield return new WaitForSeconds(CullDelay);
            while (TotalCount > CullAbove)
            {
                for (int i = 0; i < CullMaxPerPass; ++i)
                {
                    if (TotalCount <= CullAbove)
                    {
                        break;
                    }

                    if (mDespawned.Count > 0)
                    {
                        Transform inst = mDespawned[0];
                        mDespawned.RemoveAt(0);
                        mSpawnPool.DestroyInstance(inst.gameObject);

                        if (LogMessages)
                        {
                            Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                    "CULLING to {2} instances. Now at {3}.",
                                 mSpawnPool.PoolName,
                                 mPrefab.name,
                                 CullAbove,
                                 TotalCount));
                        }
                    }
                    else
                    {
                        if (LogMessages)
                        {
                            Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                                        "CULLING waiting for despawn. " +
                                                        "Checking again in {2}sec",
                                                    mSpawnPool.PoolName,
                                                    mPrefab.name,
                                                    CullDelay));
                        }
                        break;
                    }
                }

                yield return new WaitForSeconds(CullDelay);
            }

            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): CULLING FINISHED! Stopping",
                      mSpawnPool.PoolName,
                      mPrefab.name));
            }

            CullingActive = false;
            yield return null;
        }

        internal Transform SpawnInstance(Vector3 pos, Quaternion rot)
        {
            if (LimitInstances && LimitFIFO && mSpawned.Count >= LimitAmount)
            {
                Transform firstIn = mSpawned[0];
                if (LogMessages)
                {
                    Debug.Log(string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                            "LIMIT REACHED! FIFO=True. Calling despawning for {2}...",
                          mSpawnPool.PoolName,
                          mPrefab.name,
                          firstIn
                    ));
                }
                DespawnInstance(firstIn);
                mSpawnPool.Spawned.Remove(firstIn);
            }

            Transform inst;
            if (mDespawned.Count == 0)
            {
                inst = SpawnNew(pos, rot);
            }
            else
            {
                inst = mDespawned[0];
                mDespawned.RemoveAt(0);
                mSpawned.Add(inst);

                inst.position = pos;
                inst.rotation = rot;
                inst.gameObject.SetActive(true);
            }

            return inst;
        }

        public Transform SpawnNew()
        {
            return SpawnNew(Vector3.zero, Quaternion.identity);
        }


        public Transform SpawnNew(Vector3 pos, Quaternion rot)
        {
            if (LimitInstances && TotalCount >= LimitAmount)
            {
                if (LogMessages)
                {
                    Debug.Log(string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                                "LIMIT REACHED! Not creating new instances! (Returning null)",
                                mSpawnPool.PoolName,
                                mPrefab.name
                    ));
                }
                return null;
            }

            if (pos == Vector3.zero)
            {
                pos = mSpawnPool.Group.position;
            }
            if (rot == Quaternion.identity)
            {
                rot = mSpawnPool.Group.rotation;
            }

            GameObject instGO = mSpawnPool.InstantiatePrefab(mPrefabGO, pos, rot);
            Transform inst = instGO.transform;

            NameInstance(inst);

            if (!mSpawnPool.DontReparent)
            {
                bool worldPositionStays = !(inst is RectTransform);
                inst.SetParent(mSpawnPool.Group, worldPositionStays);
            }

            if (mSpawnPool.MatchPoolScale)
            {
                inst.localScale = Vector3.one;
            }

            if (mSpawnPool.MatchPoolLayer)
            {
                SetRecursively(inst, mSpawnPool.gameObject.layer);
            }

            mSpawned.Add(inst);

            if (LogMessages)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): Spawned new instance '{2}'.",
                        mSpawnPool.PoolName,
                        mPrefab.name,
                        inst.name));
            }

            return inst;
        }

        private void SetRecursively(Transform xform, int layer)
        {
            xform.gameObject.layer = layer;
            foreach (Transform child in xform)
            {
                SetRecursively(child, layer);
            }
        }

        internal void AddUnpooled(Transform inst, bool despawn)
        {
            NameInstance(inst);

            if (despawn)
            {
                inst.gameObject.SetActive(false);
                mDespawned.Add(inst);
            }
            else
            {
                mSpawned.Add(inst);
            }
        }

        internal void PreloadInstances()
        {
            if (PreLoaded)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                          "Already preloaded! You cannot preload twice. " +
                                          "If you are running this through code, make sure " +
                                          "it isn't also defined in the Inspector.",
                                        mSpawnPool.PoolName,
                                        mPrefab.name));
                return;
            }

            PreLoaded = true;

            if (mPrefab == null)
            {
                Debug.LogError(string.Format("SpawnPool {0} ({1}): Prefab cannot be null.",
                                          mSpawnPool.PoolName,
                                          mPrefab.name));
                return;
            }

            if (mLimitInstances && PreLoadAmount > LimitAmount)
            {
                Debug.LogWarning
                (
                    string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                            "You turned ON 'Limit Instances' and entered a " +
                            "'Limit Amount' greater than the 'Preload Amount'! " +
                            "Setting preload amount to limit amount.",
                                mSpawnPool.PoolName,
                                mPrefab.name
                    )
                );

                PreLoadAmount = LimitAmount;
            }

            if (CullDespawned && PreLoadAmount > CullAbove)
            {
                Debug.LogWarning(string.Format("SpawnPool {0} ({1}): " +
                    "You turned ON Culling and entered a 'Cull Above' threshold " +
                    "greater than the 'Preload Amount'! This will cause the " +
                    "culling feature to trigger immediatly, which is wrong " +
                    "conceptually. Only use culling for extreme situations. " +
                    "See the docs.",
                    mSpawnPool.PoolName,
                    mPrefab.name
                ));
            }

            if (PreLoadTime)
            {
                if (PreLoadFrames > PreLoadAmount)
                {
                    Debug.LogWarning(string.Format("SpawnPool {0} ({1}): " +
                        "Preloading over-time is on but the frame duration is greater " +
                        "than the number of instances to preload. The minimum spawned " +
                        "per frame is 1, so the maximum time is the same as the number " +
                        "of instances. Changing the preloadFrames value...",
                        mSpawnPool.PoolName,
                        mPrefab.name
                    ));

                    PreLoadFrames = PreLoadAmount;
                }
                mSpawnPool.StartCoroutine(PreloadOverTime());
            }
            else
            {
                mForceLogSilent = true;

                Transform inst;
                while (TotalCount < PreLoadAmount)
                {
                    inst = SpawnNew();
                    DespawnInstance(inst, false);
                }
                mForceLogSilent = false;
            }
        }

        private IEnumerator PreloadOverTime()
        {
            yield return new WaitForSeconds(PreLoadDelay);

            Transform inst;
            int amount = PreLoadAmount - TotalCount;
            if (amount <= 0)
            {
                yield break;
            }

            int remainder = amount % PreLoadFrames;
            int numPerFrame = amount / PreLoadFrames;

            mForceLogSilent = true;

            int numThisFrame;
            for (int i = 0; i < PreLoadFrames; i++)
            {
                numThisFrame = numPerFrame;
                if (i == PreLoadFrames - 1)
                {
                    numThisFrame += remainder;
                }

                for (int n = 0; n < numThisFrame; n++)
                {
                    inst = SpawnNew();
                    if (inst != null)
                    {
                        DespawnInstance(inst, false);
                    }
                    yield return null;
                }

                if (TotalCount > PreLoadAmount)
                {
                    break;
                }
            }

            mForceLogSilent = false;
        }

        public bool Contains(Transform tr)
        {
            if (mPrefabGO == null)
            {
                Debug.LogError(string.Format("SpawnPool {0}: PrefabPool.prefabGO is null",
                             mSpawnPool.PoolName));
            }

            if (mSpawned.Contains(tr) || mDespawned.Contains(tr))
            {
                return true;
            }
            return false;
        }

        private void NameInstance(Transform instance)
        {
            instance.name += (TotalCount + 1).ToString("#000");
        }
    }
}



