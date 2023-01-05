using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public BirdScript birdScript;
    
    public int playerScore = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject GameOverScreen;

    [ContextMenu("increase player score")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameOver() {
        GameOverScreen.SetActive(true);
    }
}
