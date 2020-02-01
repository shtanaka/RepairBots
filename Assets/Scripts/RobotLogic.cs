using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLogic : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Vector2 animationSpeedVariation;

    [SerializeField]
    private TimedAction timedAction;

    void Awake() {
        animator.SetFloat("RobotAnimationSpeed", Random.Range(animationSpeedVariation.x, animationSpeedVariation.y));
    }

    void Start() {
        if(GameLogic.GetInstance().DoesStartWithRandomTimers()) {
            GameLogic.GetInstance().generateRandomTimer(timedAction);
        }
    }

    void TakeDamage() {
        animator.SetTrigger("RobotDamage");
        
    }
}
