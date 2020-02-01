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
    [SerializeField]
    private Animator canvasAnimator;
    [SerializeField]
    private GameObject cleanerRobotPanel;

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

    public void MoveCleanerRobot() {
        float movement = Mathf.Max(0.0f, Mathf.Min(canvasAnimator.GetFloat("BlendCleanerRobot") + 0.125f, 1.0f));
        canvasAnimator.SetFloat("BlendCleanerRobot", movement);

        if(movement >= 1.0f) {
            cleanerRobotPanel.SetActive(false);
            canvasAnimator.SetFloat("BlendCleanerRobot", 0.0f);
            canvasAnimator.SetTrigger("RemoveCleanerRobot");
        }
    }
}
