using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    void Update()
    {
        if (Gamepad.current == null)
            return;

        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            SceneManager.LoadScene(1);
        }
    }
}