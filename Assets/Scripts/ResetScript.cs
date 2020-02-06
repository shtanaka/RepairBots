using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    private void Start() {
        ResetTimeScale();
    }

    public void ResetTimeScale() {
        Time.timeScale = 1.0f;
    }
}
