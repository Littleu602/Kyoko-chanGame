using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private UIPanelManager uiPanelManager;

    [Header("Input")]
    [SerializeField] private InputActionReference pauseAction;

    [Header("Panel Name")]
    [SerializeField] private string pausePanelName = "Pause";
    [SerializeField] private string optionPanelName = "Option";

    private bool isPaused = false;

    private void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.performed += OnPause;
    }

    private void OnDisable()
    {
        pauseAction.action.performed -= OnPause;
        pauseAction.action.Disable();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    /// <summary>
    /// ポーズ切替
    /// </summary>
    public void TogglePause()
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    /// <summary>
    /// ポーズ開始
    /// </summary>
    public void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;

        uiPanelManager.OpenPanel(pausePanelName);
    }

    /// <summary>
    /// ポーズ解除
    /// </summary>
    public void Resume()
    {
        isPaused = false;

        Time.timeScale = 1f;

        uiPanelManager.ClosePanel(pausePanelName);
    }

    /// <summary>
    /// オプションを開く
    /// </summary>
    public void OpenOption()
    {
        uiPanelManager.OpenPanel(optionPanelName);
    }

    /// <summary>
    /// オプションを閉じる
    /// </summary>
    public void CloseOption()
    {
        uiPanelManager.OpenPanel(pausePanelName);
    }

    /// <summary>
    /// タイトルへ戻る
    /// </summary>
    public void BackToTitle()
    {
        Time.timeScale = 1f;
        isPaused = false;

        SceneManager.LoadScene("タイトル");
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    public void QuitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}