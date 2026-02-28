using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject Panel;

    private InputAction _pause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pause = InputSystem.actions["Pause"];
    }

    // Update is called once per frame
    void Update()
    {
        if (_pause.WasReleasedThisFrame() && Panel != null)
        {
            if (Panel.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("tilemapping");
    }
}
