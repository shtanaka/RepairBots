using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLogic : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Vector2 animationSpeedVariation;

    void Awake() {
        animator.SetFloat("RobotAnimationSpeed", Random.Range(animationSpeedVariation.x, animationSpeedVariation.y));
    }
}
