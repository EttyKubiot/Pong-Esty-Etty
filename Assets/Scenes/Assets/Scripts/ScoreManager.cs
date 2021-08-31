using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int p1Score = 0;
    private int p2Score = 0;

    private int limitScore = 5;

    [SerializeField] 
    private Text p1ScoreText;
    [SerializeField] 
    private Text p2ScoreText;
    [SerializeField] 
    private Text winText;
    [SerializeField]
    private GameObject confity;

    public void AddScore(PlayerNumber player)
    {
        if (player == PlayerNumber.Player1)
        {
            p1Score++;
            p1ScoreText.text = "Score:" + p1Score;
            CheckIfWin(PlayerNumber.Player1, p1Score);
        }
        else if(player == PlayerNumber.Player2)
        {
            p2Score++;
            p2ScoreText.text = "Score:" + p2Score;
            CheckIfWin(PlayerNumber.Player2, p2Score);
        }
    }

    private void CheckIfWin(PlayerNumber player, int score)
    {
        if (score >= limitScore)
        {
            winText.gameObject.SetActive(true);
            confity.gameObject.SetActive(true);
            winText.text = player.ToString() + " Win!!!!!!!!";
            Invoke("Menu", 7);

        }
    }

    public void Menu()
    {
        SceneManager.LoadScene(5);

    }

}
