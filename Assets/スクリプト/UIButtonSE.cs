using UnityEngine;

public class UIButtonSE : MonoBehaviour
{
    [SerializeField]
    private int seIndex;

    public void PlayClick()
    {
        SEManager.Instance.PlaySE(seIndex);
    }
}