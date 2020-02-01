using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MoveTowardsColor : MonoBehaviour
{

    [SerializeField]
    private UnityEvent eventToCallZero;

    [SerializeField]
    private UnityEvent eventToCall;

    [SerializeField]
    private UnityEvent tickEventToCall;

    [SerializeField]
    private Color initialColor;

    [SerializeField]
    private Color finalColor;

    [SerializeField]
    private Image image;

    private float incrementalStep;

    void Awake() {
        incrementalStep = 0.0f;
    }

    public void StepTowardsColor(float step) {
        incrementalStep = Mathf.Max(0.0f, Mathf.Min(1.0f, incrementalStep + step));
        image.color = Color.Lerp(initialColor, finalColor, incrementalStep);
        if(tickEventToCall != null) {
            tickEventToCall.Invoke();
        }

        if(incrementalStep == 1.0 && eventToCall != null) {
            eventToCall.Invoke();
            Destroy(this);
        }

        if(incrementalStep == 0.0 && eventToCallZero != null) {
            eventToCallZero.Invoke();
            Destroy(this);
        }
    }

    public float getIncrementalStep() {
        return incrementalStep;
    }
}
