using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    public static GameLogic GetInstance() {
        return GameLogic.instance;
    }

    [SerializeField]
    private UnityEvent startGameEvents;

    [SerializeField]
    [Tooltip("Minimal Timer for Robots' timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float minimalTimerRobots;
    [SerializeField]
    [Tooltip("Maximal Timer for Robots' timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float maximalTimerRobots;

    [SerializeField]
    [Tooltip("Minimal Timer for Pylon timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float minimalTimerPylon;
    [SerializeField]
    [Tooltip("Maximal Timer for Pylon timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float maximalTimerPylon;

    [SerializeField]
    [Tooltip("Minimal Timer for Bad Events' timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float minimalTimerBadEvents;
    [SerializeField]
    [Tooltip("Maximal Timer for Bad Events' timedActionScripts (ms).")]
    [Range(0.0f, 40.0f)]
    private float maximalTimerBadEvents;

    [SerializeField]
    [Tooltip("Everytime game, the initial countdown is random instead of fixed.")]
    private bool startWithRandomTimers;

    private void Start() {
        startGameEvents.Invoke();
    }

    public void generateRandomTimer(TimedAction timedActionScript) {
        float randomTimer = Random.Range(minimalTimerRobots, maximalTimerRobots);
        timedActionScript.setTimer(randomTimer);
    }

    public void generateRandomTimerPylon(TimedAction timedActionScript) {
        float randomTimer = Random.Range(minimalTimerPylon, maximalTimerPylon);
        timedActionScript.setTimer(randomTimer);
    }

    public void generateRandomTimerBadEvents(TimedAction timedActionScript) {
        float randomTimer = Random.Range(minimalTimerBadEvents, maximalTimerBadEvents);
        timedActionScript.setTimer(randomTimer);
    }

    public void RestartGame() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public bool DoesStartWithRandomTimers() {
        return startWithRandomTimers;
    }
}
