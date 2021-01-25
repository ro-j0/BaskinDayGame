using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public static bool GamePaused;
    public GameObject pauseMenuUI;
    public GameObject canvasUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        //canvasUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void ResumeGame(){
        //canvasUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void RestartGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        Application.Quit();
    }
}
