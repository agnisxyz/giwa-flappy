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