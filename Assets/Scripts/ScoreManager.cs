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

    // Borudan geçince bu çalışacak
    public void AddScore()
    {
        _currentScore++;
        _scoreText.text = _currentScore.ToString();

        // SES BURADA ÇALIYOR
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.CoinSound);
        }
    }

    public int GetCurrentScore()
    {
        return _currentScore;
    }
}