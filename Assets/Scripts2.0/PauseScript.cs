using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{    
     public GameObject pauseMenu;
     public GameObject pauseButton;
     
     public  bool GameIsPaused;
    // Start is called before the first frame update
    
    void Start()
    {
        GameIsPaused = false;
    pauseButton.GetComponent<Button>().onClick.AddListener(pauseAndResume);



    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
// for normal clicks
      if(GameIsPaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
     
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    

      public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
        public void Restart()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         GameIsPaused = false;
         Time.timeScale = 1f;
    }


         public void QuitGame()
    {
        Application.Quit();
    }
    
    private void pauseAndResume(){
          GameIsPaused ^= true;
          
          pauseMenu.SetActive(GameIsPaused);
    }

}
