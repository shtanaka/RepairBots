using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAwakeEventsScript : MonoBehaviour
{
   [SerializeField]
    private UnityEvent events;

    [SerializeField]
    private bool onEnableCallEvent = false;

    private void Awake() {
        events.Invoke();
    }

    private void OnEnable()
    {
        if(onEnableCallEvent) {
            events.Invoke();
        }
    }
}
