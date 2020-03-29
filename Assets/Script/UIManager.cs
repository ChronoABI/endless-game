using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text CoinText;
    [SerializeField]Text ScoreText;
    public float score;
   
    

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.playerIsMoving)
        {
            score += Time.deltaTime; 
        }
        ScoreText.text = "Score : " +Mathf.Round( score);
        CoinText.text = "Coin : " + gameManager.Coin.ToString();
    }

    public void RestartLevel()
    {
        //maybe take this to another script later
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
