using UnityEngine;

namespace Singleton
{
    /// <summary>
    /// Generic variant of standard singleton
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericVariant<T> : MonoBehaviour where T : Component
    {
        protected static T instance;

        public static bool HasInstance => instance != null;
        public static T TryGetInstance() => HasInstance ? instance : null;

        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = FindAnyObjectByType<T>();    
                    if(instance == null)
                    {
                        var newInstanceGameObject = new GameObject(typeof(T).Name + " Auto-Generated");
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

            instance = this as T;
        }


    }
}
