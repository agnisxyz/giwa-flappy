using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _inGameScoreText;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _countdownText;

    [Header("Game Objects")]
    [SerializeField] private GameObject _playerObject;

    private static bool _shouldStartImmediately = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(false);
        _countdownText.gameObject.SetActive(false);
        _inGameScoreText.SetActive(false);
        UpdateHighScoreDisplay();

        if (_shouldStartImmediately)
        {
            _shouldStartImmediately = false;
            _mainMenuPanel.SetActive(false);
            if (_playerObject != null) _playerObject.SetActive(true);
            StartCoroutine(CountdownRoutine());
        }
        else
        {
            _mainMenuPanel.SetActive(true);
            if (_playerObject != null) _playerObject.SetActive(false);
        }
    }

    public void StartGameButton()
    {
        _mainMenuPanel.SetActive(false);
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        if (_playerObject != null) _playerObject.SetActive(true);
        _countdownText.gameObject.SetActive(true);
        int count = 3;

        while (count > 0)
        {
            _countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        _countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);
        _countdownText.gameObject.SetActive(false);
        _inGameScoreText.SetActive(true);

        // ZAMANI BAŞLAT: Kuş kodu bunu algılayıp zıplamaya izin verecek
        Time.timeScale = 1;
    }

    public void TriggerGameOver()
    {
        if (AudioManager.Instance != null) AudioManager.Instance.PlaySFX(AudioManager.Instance.DeathSound);

        int currentScore = ScoreManager.Instance.GetCurrentScore();
        _finalScoreText.text = "SCORE: " + currentScore.ToString();

        int savedHigh = PlayerPrefs.GetInt("HighScore", 0);
        if (currentScore > savedHigh)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();
        }
        UpdateHighScoreDisplay();

        Time.timeScale = 0; // Burada zaman durunca kuşun yaylanması "IsAlive = false" olduğu için çalışmayacak
        _inGameScoreText.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    private void UpdateHighScoreDisplay()
    {
        if (_highScoreText != null)
        {
            int high = PlayerPrefs.GetInt("HighScore", 0);
            _highScoreText.text = "BEST: " + high.ToString();
        }
    }

    public void RestartGame()
    {
        _shouldStartImmediately = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        _shouldStartImmediately = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}