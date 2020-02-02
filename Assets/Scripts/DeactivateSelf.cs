using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSelf : MonoBehaviour
{
    public void Deactivate() {
        gameObject.SetActive(false);
    }

    public void DeactivateOther(GameObject anotherGameObject) {
        anotherGameObject.SetActive(false);
    }
}
