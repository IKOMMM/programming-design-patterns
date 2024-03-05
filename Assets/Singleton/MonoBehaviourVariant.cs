using UnityEngine;

namespace Singleton
{
    /// <summary>
    /// Standard singleton variant.
    /// </summary>
    public class MonoBehaviourVariant : MonoBehaviour
    {
        public static MonoBehaviourVariant Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else { Destroy(gameObject); }
        }

    }
}
  
