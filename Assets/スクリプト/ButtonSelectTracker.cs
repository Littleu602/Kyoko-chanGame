using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSelectTracker : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        UIFocusKeeper.LastSelected = gameObject;
    }
}