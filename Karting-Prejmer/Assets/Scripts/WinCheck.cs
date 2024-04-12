using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

public class WinCheck : MonoBehaviour
{
    [SerializeField] public SpriteSignCollider _SpriteSignCollider;
    [SerializeField] public TextMeshProUGUI _WinText;
    [SerializeField] public SoundManager _SoundManager;
    [SerializeField] public SplineAnimate _CarSpline;

    public float countdownDuration = 1f; // Duration for each count (in seconds)
    public float startDelay = 1f; // Delay before starting the countdown

    void Start()
    {
        // Freeze the game
        Time.timeScale = 0f;

        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSecondsRealtime(startDelay);

        for (int count = 3; count > 0; count--)
        {
            _WinText.text = count.ToString();
            // Wait for the countdown duration
            yield return new WaitForSecondsRealtime(countdownDuration);
        }

        _WinText.text = "Go!";
        Time.timeScale = 1f; // Unfreeze the game
        _CarSpline.Play();

        yield return new WaitForSecondsRealtime(countdownDuration);
        _WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_SpriteSignCollider._CheckByPlayer && other.gameObject.CompareTag("Player"))
        {
            _WinText.SetText("You Win");
            _SoundManager._BackgroundSound.Stop();
            _SoundManager._WinSound.Play();
            Invoke(nameof(RestartGame), 5);
        }

        else if (_SpriteSignCollider._CheckByEnemy && other.gameObject.CompareTag("Enemy"))
        {
            _WinText.SetText("You Lost");
            _SoundManager._BackgroundSound.Stop();
            _SoundManager._loseSound.Play();
            Invoke(nameof(RestartGame), 5);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
