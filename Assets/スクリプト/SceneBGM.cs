using UnityEngine;

public class SceneBGM : MonoBehaviour
{
    [SerializeField]
    private int bgmIndex;

    private void Start()
    {
        BGMManager bgmManager = FindFirstObjectByType<BGMManager>();

        if (bgmManager != null)
        {
            bgmManager.PlayBGM(bgmIndex);
        }
    }
}