using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameUIPanelManager : MonoBehaviour
{
    [System.Serializable]
    public class UIPanelData
    {
        public string panelName;
        public GameObject panel;
        public GameObject firstSelect;
    }

    [Header("UI Panels")]
    [SerializeField]
    private List<UIPanelData> panels = new();

    [Header("Pause")]
    [SerializeField]
    private string pausePanelName = "Pause";

    [SerializeField]
    private InputActionReference pauseAction;

    private bool isPaused = false;

    private void Awake()
    {
        CloseAll();
    }

    private void OnEnable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.Enable();
            pauseAction.action.performed += OnPause;
        }
    }

    private void OnDisable()
    {
        if (pauseAction != null)
        {
            pauseAction.action.performed -= OnPause;
            pauseAction.action.Disable();
        }
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        OpenPanel(pausePanelName);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;

        CloseAll();
    }

    public void BackToTitle()
    {
        Time.timeScale = 1f;
        isPaused = false;

        SceneManager.LoadScene("Title");
    }

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

    public void CloseAll()
    {
        foreach (var data in panels)
        {
            data.panel.SetActive(false);
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}