using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _currentScore = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore()
    {
        _currentScore++;
        _scoreText.text = _currentScore.ToString();
    }

    public void SaveHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (_currentScore > savedHighScore)
        {
            PlayerPrefs.SetInt("HighScore", _currentScore);
            PlayerPrefs.Save(); // Veriyi diske kesin olarak yazar
        }
    }
}