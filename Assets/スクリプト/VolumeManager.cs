using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField]
    private AudioMixer mixer;

    [Header("Sliders")]
    [SerializeField]
    private Slider masterSlider;

    [SerializeField]
    private Slider bgmSlider;

    [SerializeField]
    private Slider seSlider;

    private const string MASTER_KEY = "MasterVolume";
    private const string BGM_KEY = "BGMVolume";
    private const string SE_KEY = "SEVolume";

    private void Start()
    {
        // ï€ë∂Ç≥ÇÍÇΩílÇì«Ç›çûÇ›
        float master = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float bgm = PlayerPrefs.GetFloat(BGM_KEY, 1f);
        float se = PlayerPrefs.GetFloat(SE_KEY, 1f);

        // SliderÇ÷îΩâf
        masterSlider.value = master;
        bgmSlider.value = bgm;
        seSlider.value = se;

        // AudioMixerÇ÷îΩâf
        ApplyMasterVolume(master);
        ApplyBGMVolume(bgm);
        ApplySEVolume(se);
    }

    public void SetMasterVolume(float value)
    {
        ApplyMasterVolume(value);

        PlayerPrefs.SetFloat(MASTER_KEY, value);
        PlayerPrefs.Save();
    }

    public void SetBGMVolume(float value)
    {
        ApplyBGMVolume(value);

        PlayerPrefs.SetFloat(BGM_KEY, value);
        PlayerPrefs.Save();
    }

    public void SetSEVolume(float value)
    {
        ApplySEVolume(value);

        PlayerPrefs.SetFloat(SE_KEY, value);
        PlayerPrefs.Save();
    }

    private void ApplyMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
    }

    private void ApplyBGMVolume(float value)
    {
        mixer.SetFloat("BGMVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20);
    }

    private void ApplySEVolume(float value)
    {
        mixer.SetFloat("SEVolume", Mathf.Lerp(-80f, 0f, value));
    }
}