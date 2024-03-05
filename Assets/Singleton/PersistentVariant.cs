using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Singleton
{
    /// <summary>
    /// Sigleton that don't destroy on load. 
    /// Works only on root level
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PersistentVariant<T> : MonoBehaviour where T : Component
    {
        public bool AutoUnparentOnAwake = true;

        protected static T instance;

        public static bool HasInstance => instance != null;
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

            if(AutoUnparentOnAwake)
            {
                transform.SetParent(null);
            }

            if(instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if(Instance != this)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}

    

