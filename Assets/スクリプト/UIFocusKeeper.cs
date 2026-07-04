using UnityEngine;
using UnityEngine.EventSystems;

public class UIFocusKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultButton;

    public static GameObject LastSelected;

    private void Start()
    {
        LastSelected = defaultButton;
        EventSystem.current.SetSelectedGameObject(defaultButton);
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (LastSelected != null &&
                LastSelected.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(LastSelected);
            }
        }
    }
}