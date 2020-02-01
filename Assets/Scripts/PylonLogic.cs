using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PylonLogic : MonoBehaviour
{

    [SerializeField]
    private Animator animatorPanel;
    [SerializeField]
    private Animator animatorRotation;

    public void setLifeAnimationSpeed(MoveTowardsColor moveTowardsColor) {
        animatorPanel.SetFloat("Progress", moveTowardsColor.getIncrementalStep());
        animatorRotation.SetFloat("LifeSpeed", moveTowardsColor.getIncrementalStep());
    }
}
