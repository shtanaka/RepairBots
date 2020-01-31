using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private static GameLogic instance;
    void Awake() {
        if(GameLogic.instance == null) {
            GameLogic.instance = this;
        } else {
            Destroy(this);
            Debug.LogError("The Game already has a GameLogic instance!");
        }
    }

    [SerializeField]
    [Tooltip("Minimal Timer for timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float minimalTimer;

    [SerializeField]
    [Tooltip("Maximal Timer for timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float maximalTimer;

    public void generateRandomTimer(TimedAction timedActionScript) {
        float randomTimer = Random.Range(minimalTimer, maximalTimer);
        timedActionScript.setTimer(randomTimer);
    }
}
