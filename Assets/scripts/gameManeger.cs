using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManeger : MonoBehaviour
{
    [Header("skor sayaç")]
    private int score;
    public TextMeshProUGUI scoreText;
    public int bestScore=0;
    public TextMeshProUGUI bestScoreText;

    [Header("sayfalar")]
    public  bool gameOver;
    public GameObject gameOverPanel;
    public bool best=false;
    public GameObject bestScorePenel;

    [Header("döngü")]
    public GameObject prefabSpwn;

    [Header("butonlar")]
    public GameObject play;
    public GameObject quit;
    public GameObject highS;
    void Start()
    {
        Time.timeScale=1f;
        gameOver=false;
        
    }
 
     private void Update()
     {
        gameOverPan();
        
     }
     public void gameScore(int ringSc)
     {
        score+=ringSc;
        scoreText.text=score.ToString();
        if (score>bestScore)
        {
            bestScore=score;
            PlayerPrefs.SetInt("Best Score",bestScore);
            PlayerPrefs.Save();
        }
     }

     public void spawnClyn(int num)
     {
        GameObject sapwn=Instantiate(prefabSpwn);
        Vector3 sapawnPosition=new Vector3(0f,0f-num,0f);
        sapwn.transform.position=sapawnPosition;
        sapwn.transform.Rotate(0f,0f+ num,0f);
     }

    public void playButton()
    {
        SceneManager.LoadScene(0);
    }
    public void quitButton()
    {
        Application.Quit();
    }
    public void highScore()
    {
        best=true;
        bestScorePenel.SetActive(true);
        bestScore=PlayerPrefs.GetInt("Best Score",bestScore);
        bestScoreText.text=bestScore.ToString();
        
        
    }
    public void gameOverPan()
    {
        if (gameOver)
        {
            Time.timeScale=0;
            gameOverPanel.SetActive(true);
           
        }
        else if (best)//bestscor panelini kapatmak için buton fonsiyonu haricinde update ihtiyacı olduğu için burada tazılmıştır.
        {
            if(Input.GetMouseButton(0))
            {
            
              bestScorePenel.SetActive(false);
            }
        }
        
            
        
    }
     public void retryButton()
    {
        SceneManager.LoadScene(0);
    }
    public void menuButton()
    {
        SceneManager.LoadScene(1);
    }
    
    
}
