using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;

    [SerializeField] private AudioSource audioSource;

    [Header("Ä¶‰Â”\‚ÈSEˆê——")]
    [SerializeField] private AudioClip[] seList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // w’è”Ô†‚ÌSE‚ğÄ¶
    public void PlaySE(int index)
    {
        if (index < 0 || index >= seList.Length)
            return;

        audioSource.PlayOneShot(seList[index]);
    }

    // AudioClip‚ğ’¼ÚÄ¶
    public void PlaySE(AudioClip clip)
    {
        if (clip == null)
            return;

        audioSource.PlayOneShot(clip);
    }
}