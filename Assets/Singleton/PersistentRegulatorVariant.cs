using UnityEngine;

namespace Singleton
{
    /// <summary>
    /// Persistent regulator singleton. Will destroy any other older components of the same type if finds on awake
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersistentRegulatorVariant<T> : MonoBehaviour where T : Component
    {
        protected static T instance;

        public static bool HasInstance => instance != null;
        public float InitializationTime { get; private set; }
        public static T TryGetInstance() => HasInstance ? instance : null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null)
                    {
                        var newInstanceGameObject = new GameObject(typeof(T).Name + " Auto-Generated");
                        newInstanceGameObject.hideFlags = HideFlags.HideAndDontSave;
                        instance = newInstanceGameObject.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Make sure to call base.Awake in override if you need awake!
        /// </summary>

        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying) return;
            InitializationTime = Time.time;
            DontDestroyOnLoad(gameObject);

            T[] oldInstances = FindObjectsByType<T>(FindObjectsSortMode.None);

            foreach(T old in oldInstances)
            {
                if(old.GetComponent<PersistentRegulatorVariant<T>>().InitializationTime < InitializationTime)
                {
                    Destroy(old.gameObject);
                }
            }

            if (instance == null)
            {
                instance = this as T;
            }

        }
    }
}


