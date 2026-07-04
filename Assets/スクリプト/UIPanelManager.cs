using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPanelManager : MonoBehaviour
{
    [System.Serializable]
    public class UIPanelData
    {
        public string panelName;
        public GameObject panel;
        public GameObject firstSelect;
    }

    [SerializeField]
    private List<UIPanelData> panels = new();

    /// <summary>
    /// 指定したパネルだけを開く
    /// </summary>
    public void OpenPanel(string panelName)
    {
        foreach (var data in panels)
        {
            bool active = data.panelName == panelName;
            data.panel.SetActive(active);

            if (active && data.firstSelect != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(data.firstSelect);
            }
        }
    }

    /// <summary>
    /// 指定したパネルを開く（他のパネルはそのまま）
    /// </summary>
    public void ShowPanel(string panelName)
    {
        foreach (var data in panels)
        {
            if (data.panelName == panelName)
            {
                data.panel.SetActive(true);

                if (data.firstSelect != null)
                {
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(data.firstSelect);
                }

                return;
            }
        }
    }

    /// <summary>
    /// 指定したパネルを閉じる
    /// </summary>
    public void ClosePanel(string panelName)
    {
        foreach (var data in panels)
        {
            if (data.panelName == panelName)
            {
                data.panel.SetActive(false);
                return;
            }
        }
    }

    /// <summary>
    /// パネルが開いているか
    /// </summary>
    public bool IsOpen(string panelName)
    {
        foreach (var data in panels)
        {
            if (data.panelName == panelName)
            {
                return data.panel.activeSelf;
            }
        }

        return false;
    }

    /// <summary>
    /// 全て閉じる
    /// </summary>
    public void CloseAll()
    {
        foreach (var data in panels)
        {
            data.panel.SetActive(false);
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
}