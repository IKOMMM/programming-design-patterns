using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DependencyInjection
{
    public class Provider : MonoBehaviour, IDependencyProvider { }

    public class ServiceA
    {
        //Preview Implementation
        public void Initialize(string message = null) {
            Debug.Log($"SericeA.Initialize({message}");
        }
    }
    public class ServiceB
    {
        //Preview Implementation
        public void Initialize(string message = null)
        {
            Debug.Log($"SericeB.Initialize({message}");
        }
    }

    public class FactoryA
    {
        ServiceA cachedServiceA;

        public ServiceA CreateServiceA()
        {
            if(cachedServiceA == null ){
                cachedServiceA = new ServiceA();
            }
            return cachedServiceA;
        }
    }

}

