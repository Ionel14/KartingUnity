using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class GameManager : MonoBehaviour
{
    [SerializeField] public SpriteSignCollider _SpriteSignCollider;
    [SerializeField] public TextMeshProUGUI _WinText;
    [SerializeField] public SoundManager _SoundManager;
    [SerializeField] public SplineAnimate _CarSpline;
    [SerializeField] public GameObject _Enemy;


    private float _countdownDuration = 1f; // Duration for each count (in seconds)
    private float _startDelay = 1f; // Delay before starting the countdown
    private bool _gameEnded = false;
    public static bool _CountdownStarted = false;

    void Start()
    {
        // Freeze the game
        Time.timeScale = 0f;

        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCountdown()
    {
        _CountdownStarted = true;
        yield return new WaitForSecondsRealtime(_startDelay);

        for (int count = 3; count > 0; count--)
        {
            while (PauseMenu.GameIsPaused)
            {
                _WinText.text = "";
                yield return new WaitForSecondsRealtime(_countdownDuration);
            }
            _WinText.text = count.ToString();
            // Wait for the countdown duration
            yield return new WaitForSecondsRealtime(_countdownDuration);
        }

        _WinText.text = "Go!";
        Time.timeScale = 1f; // Unfreeze the game
        _Enemy.GetComponent<SplineAnimate>().Duration = 180 - 40 * ChangeDifficulty._Difficulty;
        _CarSpline.Play();

        yield return new WaitForSecondsRealtime(_countdownDuration);
        _WinText.text = "";
        _CountdownStarted = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gameEnded)
        {
            if (_SpriteSignCollider._CheckByPlayer && other.gameObject.CompareTag("Player"))
            {
                _gameEnded = true;
                WinGame();
            }
            else if (_SpriteSignCollider._CheckByEnemy && other.gameObject.CompareTag("Enemy"))
            {
                _gameEnded = true;
                LoseGame();
            }
        }
    }

    private void WinGame()
    {
        _WinText.SetText("You Win");
        _SoundManager._BackgroundSound.Stop();
        _SoundManager._WinSound.Play();
        Invoke(nameof(RestartGame), 5);
    }

    private void LoseGame()
    {
        _WinText.SetText("You Lost");
        _SoundManager._BackgroundSound.Stop();
        _SoundManager._LoseSound.Play();
        Invoke(nameof(RestartGame), 5);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
