﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTowardsColor : MonoBehaviour
{
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
    }
}
