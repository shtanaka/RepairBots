using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class TimedAction : MonoBehaviour
{
    [SerializeField]
    private UnityEvent eventToCall;

    [SerializeField]
    [Tooltip("Timer to activate the action (ms).")]
    [Range(0.0f, 40.0f)]
    private float timer;
    private float counter;

    [SerializeField]
    [Tooltip("If the timer should reset after invoking the event.")]
    private bool resetAfterTimer;

    private bool hasDisplayText;

    [SerializeField]
    private Text displayText;

    [SerializeField]
    [Tooltip("If the text will show the time increasing (true) or decreasing (false).")]
    private bool showTimerDecreasing = false;

    [SerializeField]
    [Tooltip("If the text will deleted after the timer runs out. Only works if resetAfterTimer is set to false.")]
    private bool deleteTextAfterCompletion = false;

    private float remainder;

    private void Awake() {
        Restart();
        hasDisplayText = displayText != null;
    }

    private void Update()
    {
        counter += Time.deltaTime;
        remainder = counter - timer;
        if(hasDisplayText) {
            displayText.text = (showTimerDecreasing) ? String.Format("{0:0}", counter) : String.Format("{0:0}", -remainder);
        }

        if(remainder >= 0.001f) {
            eventToCall.Invoke();
            if(resetAfterTimer) {
                counter = 0.0f;
            } else {
                Destroy(this);
                if(deleteTextAfterCompletion && hasDisplayText) {
                    Destroy(displayText);
                }
            }
        } 
    }

    public void Restart() {
        counter = 0.0f;
    }

    public void setTimer(float newTimer) {
        this.timer = newTimer;
    }
}
