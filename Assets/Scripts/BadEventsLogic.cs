using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BadEventsLogic : MonoBehaviour
{
    [SerializeField]
    private PostProcessLayer layer;
    [SerializeField]
    private PostProcessVolume volume;
    [SerializeField]
    private PostProcessProfile profile;

    public void setChromaticAberrationValue(float value) {
        ChromaticAberration ca = null;
        profile.TryGetSettings<ChromaticAberration>(out ca);
        if(ca != null) {
            ca.intensity.value = value;
        }
    }

    public void randomizeChromaticAberration() {
        ChromaticAberration ca = null;
        profile.TryGetSettings<ChromaticAberration>(out ca);
        if(ca != null) {
            ca.intensity.value = Random.Range(0.0f, 1.0f);
        }
    }

    public void randomizeTintColorTowards(Image image) {
        ColorGrading cg = null;
        profile.TryGetSettings<ColorGrading>(out cg);
        if(cg != null) {
            cg.colorFilter.value = Color.Lerp(Color.white, image.color, Random.Range(0.0f, 1.0f));
        }
    }
}
