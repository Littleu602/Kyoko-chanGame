using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [Header("Ä¶‰Â”\‚ÈBGMˆê——")]
    [SerializeField] private AudioClip[] bgmList;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // w’è”Ô†‚ÌBGM‚ğÄ¶
    public void PlayBGM(int index)
    {
        if (index < 0 || index >= bgmList.Length)
            return;

        // “¯‚¶‹È‚È‚çÄ¶‚µ’¼‚³‚È‚¢
        if (audioSource.clip == bgmList[index])
            return;

        audioSource.clip = bgmList[index];
        audioSource.Play();
    }

    // ’â~
    public void StopBGM()
    {
        audioSource.Stop();
    }
}