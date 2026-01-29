using UnityEngine;
using TMPro; // TextMeshPro kullanacağımız için gerekli

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Diğer scriptlerden erişmek için

    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;

    private void Awake()
    {
        // Singleton yapısı: Her yerden ScoreManager.Instance diyerek ulaşabilirsin
        if (Instance == null) Instance = this;
    }

    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();

        // Buraya istersen skor artınca çalacak bir "point" sesi ekleyebilirsin
    }
}