using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UI Panelleri")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        // Oyun ilk açıldığında her şeyi dondur ve menüyü göster
        Time.timeScale = 0;
        _mainMenuPanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        _countdownText.gameObject.SetActive(false);

        // Varsa High Score'u yükle
        UpdateHighScoreDisplay();
    }

    // Play butonuna basınca çalışacak fonksiyon
    public void StartGameSequence()
    {
        _mainMenuPanel.SetActive(false);
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        _countdownText.gameObject.SetActive(true);
        int count = 3;

        while (count > 0)
        {
            _countdownText.text = count.ToString();
            // Zaman durduğu için WaitForSecondsRealtime kullanıyoruz
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        _countdownText.text = "START!";
        yield return new WaitForSecondsRealtime(0.5f);

        _countdownText.gameObject.SetActive(false);
        Time.timeScale = 1; // Fizik motorunu ve hareketi başlat
    }

    public void TriggerGameOver()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateHighScoreDisplay()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScoreText.text = "High Score : " + highScore.ToString();
    }
}