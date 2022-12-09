using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameM : MonoBehaviour
{
    public Text scoreText;
    public float score01;
    //public Gems gems;
    public static GameM instance;
    public float leveltime;
    public float currentTime,time;
    public HealthBar health;
    bool isTimeStop=false;

    public GameObject gameOverPanel,scoreBar,healthbar,pauseBtn,pausePanel;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health.SetMaxHealth(currentTime);
       
    }

    // Update is called once per frame
    void Update()
    {
        TimeDec();
        GameOver();

        if (isTimeStop==true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

       
    }

    public void AddPoint()
    {
        score01 += 1;
        scoreText.text = score01.ToString();
    }

    public void TimeDec()
    {
        currentTime -= time* Time.deltaTime;
        health.SetHealth(currentTime);
       
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
        scoreBar.SetActive(false);
        healthbar.SetActive(false);
        pauseBtn.SetActive(false);
        //Time.timeScale = 0;
        isTimeStop = true;
    }
    public void GameOver() {
        if (currentTime<=0)
        {
            GameOverPanel();
        }
     /* else
        {
            Time.timeScale = 1;
        }*/
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverPanel.SetActive(false);
        scoreBar.SetActive(true);
        healthbar.SetActive(true);
        pauseBtn.SetActive(true);

    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        scoreBar.SetActive(false);
        healthbar.SetActive(false);
        // Time.timeScale = 0;
        isTimeStop = true;
    }

    public void ReasumeGame()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        scoreBar.SetActive(true);
        healthbar.SetActive(true);
        isTimeStop = false;
    }
}
