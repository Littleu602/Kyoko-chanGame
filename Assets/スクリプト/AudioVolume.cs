using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [Header("Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    // 保存キー
    private const string MASTER_KEY = "MasterVolume";
    private const string BGM_KEY = "BGMVolume";
    private const string SE_KEY = "SEVolume";

    private void Start()
    {
        // 保存データ読み込み
        float master = PlayerPrefs.GetFloat(MASTER_KEY, 5f);
        float bgm = PlayerPrefs.GetFloat(BGM_KEY, 5f);
        float se = PlayerPrefs.GetFloat(SE_KEY, 5f);

        // スライダーへ反映
        masterSlider.value = master;
        bgmSlider.value = bgm;
        seSlider.value = se;

        // AudioMixerへ反映
        SetAudioMixerMaster(master);
        SetAudioMixerBGM(bgm);
        SetAudioMixerSE(se);

        // スライダー変更イベント登録
        masterSlider.onValueChanged.AddListener(SetAudioMixerMaster);
        bgmSlider.onValueChanged.AddListener(SetAudioMixerBGM);
        seSlider.onValueChanged.AddListener(SetAudioMixerSE);
    }

    // ==========================
    // Master
    // ==========================
    public void SetAudioMixerMaster(float value)
    {
        ApplyVolume("MasterVolume", value);

        PlayerPrefs.SetFloat(MASTER_KEY, value);
        PlayerPrefs.Save();
    }

    // ==========================
    // BGM
    // ==========================
    public void SetAudioMixerBGM(float value)
    {
        ApplyVolume("BGMVolume", value);

        PlayerPrefs.SetFloat(BGM_KEY, value);
        PlayerPrefs.Save();
    }

    // ==========================
    // SE
    // ==========================
    public void SetAudioMixerSE(float value)
    {
        ApplyVolume("SEVolume", value);

        PlayerPrefs.SetFloat(SE_KEY, value);
        PlayerPrefs.Save();
    }

    // ==========================
    // 共通処理
    // ==========================
    private void ApplyVolume(string parameterName, float value)
    {
        value /= 5f;

        float volume =
            Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f;

        audioMixer.SetFloat(parameterName, volume);

        Debug.Log($"{parameterName} : {volume}");
    }
}