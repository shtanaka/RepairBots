using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonLogic : MonoBehaviour
{

    [SerializeField]
    private Animator animatorPanel;
    [SerializeField]
    private Animator animatorRotation;
    [SerializeField]
    private MoveTowardsColor backpanelMoveTowardsColor;

    public void setLifeAnimationSpeed(MoveTowardsColor moveTowardsColor) {
        float incrementalStep = moveTowardsColor.getIncrementalStep();
        animatorPanel.SetFloat("Progress", incrementalStep);
        animatorRotation.SetFloat("LifeSpeed", incrementalStep);
        backpanelMoveTowardsColor.StepTowardsColor(incrementalStep);
    }
}
