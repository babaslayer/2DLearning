using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int coin;
    [SerializeField] int score;
    [SerializeField] int highScore;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore",0);
        highScoreText.text = "HighScore:"+ highScore.ToString();
    } 
    public void CoinAdd()
    {
        coin++;
        coinText.text=coin.ToString();

    }
   public void AddScore()
    {
       score+=1 ;
      scoreText.text = score.ToString();

    }
    public void GameOver()
    {
     
    if(score > highScore)
        { 
            PlayerPrefs.SetInt("HighScore",score);
            PlayerPrefs.Save();
         }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
