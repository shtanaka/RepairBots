using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;

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

    [SerializeField]
    private UnityEvent chatBotEvent;

    [SerializeField]
    private GameObject chatBotGameObject;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField, Range(-3.0f, 3.0f)]
    private float regularPitch;

    public void Start() {
        ResetEffects();
    }

    public void setChromaticAberrationValue(float value) {
        ChromaticAberration ca = null;
        profile.TryGetSettings<ChromaticAberration>(out ca);
        if(ca != null) {
            ca.intensity.value = value;
        }
    }

    public void setContrast(float value) {
        ColorGrading cg = null;
        profile.TryGetSettings<ColorGrading>(out cg);
        if(cg != null) {
            cg.contrast.value = value;
        }
    }

    public void setSaturation(float value) {
        ColorGrading cg = null;
        profile.TryGetSettings<ColorGrading>(out cg);
        if(cg != null) {
            cg.saturation.value = value;
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

    public void ActivateSlowMode() {
        Time.timeScale = 0.8f;
        audioSource.pitch = 0.8f;
        setChromaticAberrationValue(0.1f);
        setContrast(50);
        setSaturation(-40);
    }

    public void ActivateTurboMode() {
        Time.timeScale = 1.5f;
        audioSource.pitch = 1.5f;
        setChromaticAberrationValue(1.0f);
        setContrast(90);
    }

    public void DeactivateTurboMode() {
        Time.timeScale = 1.0f;
        audioSource.pitch = regularPitch;
        setChromaticAberrationValue(0.0f);
        setContrast(36);
        setSaturation(0);
    }

    public void CheckChatBotAvailability() {
        if(!chatBotGameObject.activeSelf) {
            chatBotEvent.Invoke();
        }
    }

    public void ResetEffects() {
        ChromaticAberration ca = null;
        profile.TryGetSettings<ChromaticAberration>(out ca);
        if(ca != null) {
            ca.intensity.value = 0;
        }

        ColorGrading cg = null;
        profile.TryGetSettings<ColorGrading>(out cg);
        if(cg != null) {
            cg.colorFilter.value = Color.white;
        }

        DeactivateTurboMode();
    }
}
