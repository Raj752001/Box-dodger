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
    public Text gameOverScoreText;
    public AudioSource mainAudioSource;
    public AudioClip mainAudioClip;
    public AudioClip gameOverAudioClip;

    bool isGameOver=false;

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
        gameOverScoreText.text = Mathf.Round(Time.timeSinceLevelLoad).ToString();
    }
}
