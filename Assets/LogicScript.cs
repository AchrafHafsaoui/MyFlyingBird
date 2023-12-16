using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public Text scoreText;
    public Text coinsText;
    public Text shieldsText;
    public Text highestScoreText;
    public GameObject gameOverScreen;
    public GameObject reviveScreen;
    public GameObject costCoin;

    private string highestScoreKey = "HighestScore";
    private string coinsCountKey = "PlayerCoins";
    private string shieldsCountKey = "ShieldsCount";

    private int playerScore;
    private int playerCoins;
    private int shieldsCount;
    private int highestScore;

    void Start()
    {   
        highestScore = PlayerPrefs.GetInt(highestScoreKey, 0);
        playerCoins = PlayerPrefs.GetInt(coinsCountKey, 0);
        shieldsCount = PlayerPrefs.GetInt(shieldsCountKey, 0);
        UpdateUI();
    }

    public void addScore(int points)
    {
        playerScore += points;
        scoreText.text = playerScore.ToString();

        if (playerScore > highestScore)
        {
            highestScore = playerScore;
        }
        addCoins(1);
        UpdateUI();
        SaveData();
    }

    public void addCoins(int coins){
        playerCoins += coins;
        UpdateUI();
        SaveData();
    }

    public int getCoins(){
        return playerCoins;
    }

    void SaveData()
    {
        PlayerPrefs.SetInt(highestScoreKey, highestScore);
        PlayerPrefs.SetInt(coinsCountKey, playerCoins);
        PlayerPrefs.SetInt(shieldsCountKey, shieldsCount);
        PlayerPrefs.Save();
    }

    void UpdateUI()
    {
        if(scoreText!=null)scoreText.text = playerScore.ToString();
        coinsText.text = playerCoins.ToString();
        if(shieldsText!=null)shieldsText.text=shieldsCount.ToString();
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }

    public void startGame()
    {
        SceneManager.LoadScene("Play");
    }

    public void homescreen()
    {
        SaveData(); 
        SceneManager.LoadScene("Homescreen");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOverVisibility(bool b)
    {
        gameOverScreen.SetActive(b);
        costCoin.SetActive(b);
    }

    public void reviveVisibility(bool b)
    {
        reviveScreen.SetActive(b);
    }

    public void buyShield(){
        if(playerCoins>=100){
            playerCoins -= 100;
            shieldsCount++;
            UpdateUI();
            SaveData();
        }
    }
}
