using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TyperScript : MonoBehaviour
{
    [SerializeField]
    [TextArea(5,20)]
    private string TextToType;

    [SerializeField]
    private Text TextToWriteTo;

    private int charCounter = 0;

    [SerializeField]
    private bool restart = false;

    [SerializeField]
    private UnityEvent eventToCall;

    [SerializeField, Range(0.0f, 5.0f)]
    private float timer;

    [SerializeField, Range(0.0f, 5.0f)]
    private float initialTimer;

    private float counter;

    private int charStep;

    private void Start() {
        ResetValues();
    }


    private void Update()
    {
        counter += Time.deltaTime;
        if(counter >= timer) {
            for (int i = 0; i < charStep; i++)
            {
                if(charCounter < TextToType.Length) {
                    TextToWriteTo.text += TextToType[charCounter];
                    ++charCounter;
                } else {
                    if(restart) {
                        Restart();
                    } else {
                        if(eventToCall != null) {
                            eventToCall.Invoke();
                            break;
                        }
                    }
                }
            }
            counter = 0.0f;
        }
    }

    public void AddSpeed(float value) {
        timer = Mathf.Max(0.0f, timer - value);
        if(timer == 0.0f) {
            charStep++;
            // timer = initialTimer;
        }
    }

    public void Restart() {
        ResetValues();
        timer = initialTimer;
    }

    private void ResetValues() {
        TextToWriteTo.text = "";
        charCounter = 0;
        counter = 0.0f;
        charStep = 1;
    }
}
