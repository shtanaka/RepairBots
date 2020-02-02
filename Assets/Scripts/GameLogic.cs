using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System;

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

    [SerializeField]
    [Tooltip("Chance of Bad Event after damage.")]
    [Range(0.0f, 100.0f)]
    private float chanceOfBadEvent;

    [SerializeField]
    private GameObject[] listOfBadEvents;

    [SerializeField]
    private int forceEvent = -1;

    [SerializeField]
    private MoveTowardsColor mainGameTowardsColor;

    private void Start() {
        startGameEvents.Invoke();
    }

    public void generateRandomTimer(TimedAction timedActionScript) {
        float randomTimer = UnityEngine.Random.Range(minimalTimerRobots, maximalTimerRobots);
        timedActionScript.setTimer(randomTimer);
    }

    public void generateRandomTimerPylon(TimedAction timedActionScript) {
        float randomTimer = UnityEngine.Random.Range(minimalTimerPylon, maximalTimerPylon);
        timedActionScript.setTimer(randomTimer);
    }

    public void generateRandomTimerBadEvents(TimedAction timedActionScript) {
        float randomTimer = UnityEngine.Random.Range(minimalTimerBadEvents, maximalTimerBadEvents);
        timedActionScript.setTimer(randomTimer);
        timedActionScript.Restart();
    }

    public void RestartGame() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public bool DoesStartWithRandomTimers() {
        return startWithRandomTimers;
    }

    public void randomizeBadEvents() {
        if(UnityEngine.Random.Range(0.0f, 100.0f) < chanceOfBadEvent) {
            int count = listOfBadEvents.Length;

            GameObject badEvent = (forceEvent == -1) ? listOfBadEvents[UnityEngine.Random.Range(0, count)] : listOfBadEvents[Mathf.Min(count - 1, Mathf.Max(forceEvent, 0))];
            if(!badEvent.activeSelf) {
                badEvent.SetActive(true);
            }
        }
    }

    public void setScore(Text text) {
        text.text = String.Format("{0:0.0000}", mainGameTowardsColor.getAccumulatePositive());
    }
}
