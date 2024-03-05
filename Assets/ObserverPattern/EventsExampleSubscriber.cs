using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventsExampleSubscriber : UnityEngine.MonoBehaviour
{
    [SerializeField] UnityEvent onUnityEvent;

    [SerializeField] Button onUnityEventButton;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {

    }

    private void OnUnityEventExample()
    {
        onUnityEvent.Invoke();
    }
}
