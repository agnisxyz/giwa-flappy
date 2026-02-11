using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UI Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    [Header("Game Objects")]
    [SerializeField] private GameObject _playerObject;

    // Static bool to check if we are coming from a retry
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

        if (_shouldStartImmediately)
        {
            // If retrying, skip menu and start countdown
            _shouldStartImmediately = false; // Reset for next time
            _mainMenuPanel.SetActive(false);
            StartCoroutine(CountdownRoutine());
        }
        else
        {
            // First entry, show menu
            _mainMenuPanel.SetActive(true);
            if (_playerObject != null) _playerObject.SetActive(false);
        }

        ShowHighScore();
    }

    public void StartGameButton()
    {
        _mainMenuPanel.SetActive(false);
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        if (_playerObject != null) _playerObject.SetActive(true);

        // Reset player position and status before countdown
        BirdMovement movement = _playerObject.GetComponent<BirdMovement>();
        if (movement != null)
        {
            movement.IsAlive = true;
            _playerObject.transform.position = Vector3.zero;
            _playerObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        }

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

        Time.timeScale = 1;
    }

    public void TriggerGameOver()
    {
        Time.timeScale = 0;
        ScoreManager.Instance.SaveHighScore(); // Save before showing panel
        _gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        _shouldStartImmediately = true; // Set flag to skip menu
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowHighScore()
    {
        if (_highScoreText != null)
        {
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            _highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}