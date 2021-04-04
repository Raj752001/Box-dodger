using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMangager : MonoBehaviour
{
    public GameObject mainCanvas;
    public Text mainScoreText;
    public GameObject gameOverCanvas;
    public Image pausePlayButtonImage;
    public Sprite pauseImage;
    public Sprite playImage;
    public Image pausePlayAudioImage;
    public Sprite pauseAudio;
    public Sprite playAudio;
    public GameObject pauseBackgroundImage;
    public Text gameOverScoreText;
    public Text highScoreText;
    public AudioSource mainAudioSource;
    public AudioClip mainAudioClip;
    public AudioClip gameOverAudioClip;

    bool isGameOver=false;
    bool ispause = false;
    bool isPauseAudio = false;

    // Start is called before the first frame update
    void Start()
    {

        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);

        FindObjectOfType<PlayerControl>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            mainScoreText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartLevel();
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    void OnGameOver()
    {
        isGameOver = true;
        mainAudioSource.Stop();
        AudioSource.PlayClipAtPoint(gameOverAudioClip, transform.position);
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (Time.timeSinceLevelLoad > highScore)
        {
            highScore = Time.timeSinceLevelLoad;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        highScoreText.text = "High Socre : " + Mathf.Round(highScore).ToString();
        gameOverScoreText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
    }

    public void PausePlayGame()
    {
        if (!ispause)
        {
            pausePlayButtonImage.sprite = pauseImage;
            pauseBackgroundImage.SetActive(true);
            ispause = true;
            Time.timeScale = 0;
        }
        else
        {
            pausePlayButtonImage.sprite = playImage;
            pauseBackgroundImage.SetActive(false);
            ispause = false;
            Time.timeScale = 1;
        }
        
    }

    public void PlayMuteAudio()
    {
        if (!isPauseAudio)
        {
            pausePlayAudioImage.sprite = pauseAudio;
            isPauseAudio = true;
            mainAudioSource.Stop();
        }
        else
        {
            pausePlayAudioImage.sprite = playAudio;
            isPauseAudio = false;
            mainAudioSource.Play();
        }

    }
}
