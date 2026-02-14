using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private int currentScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore()
    {
        currentScore++;
        _scoreText.text = currentScore.ToString();

        AudioManager.Instance.PlaySFX(AudioManager.Instance.CoinSound);
    }

    public void SaveHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save(); // Veriyi diske kesin olarak yazar
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}