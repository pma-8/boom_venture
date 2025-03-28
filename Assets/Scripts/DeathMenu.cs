using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public GameObject pauseButton;
    public ObjectGenerator generator;
    public GameObject meterScore;
    public TextMeshProUGUI deathCurrentScore;
    public TextMeshProUGUI currentScore;
    public GameObject oldHighscore;
    public GameObject newHighscore;
    public GameObject scoreTitle;
    public GameObject pauseBackground;
    public GameObject audioButtons;
    public GameObject circularClock;

    public float animatingTime;

    public void Start()
    {
        SoundController.Instance.PlaySound(SoundsGame.menuMovingSound);
        if (ScoreManager.score > ScoreManager.highscore)
        {
            ScoreManager.highscore = ScoreManager.score;
            PlayerPrefs.SetInt("highscore", ScoreManager.highscore);
            newHighscore.SetActive(true);
            oldHighscore.SetActive(false);
            scoreTitle.SetActive(false);
            SoundController.Instance.PlaySound(SoundsGame.newHighscoreSound);
        }
        else
        {
            newHighscore.SetActive(false);
            oldHighscore.SetActive(true);
            oldHighscore.GetComponent<TextMeshProUGUI>().text = "Highscore: " + ScoreManager.highscore + "m";
            scoreTitle.SetActive(true);
        }

        audioButtons.SetActive(true);
        circularClock.SetActive(false);
        pauseBackground.SetActive(false);
        deathCurrentScore.text = currentScore.text;
        meterScore.SetActive(false);
        pauseButton.SetActive(false);
        generator.gameObject.SetActive(false);

    }

    public void Update()
    {
        Time.timeScale = 0;
        if (GameObject.Find("Explode(Clone)") != null)
        {
            GameObject explode = GameObject.Find("Explode(Clone)");
            Object.Destroy(explode);
        }
    }

    public void RestartGame()
    {
        SoundController.Instance.PlaySound(SoundsGame.buttonPressSound);
        Time.timeScale = 1;
        transform.localPosition = new Vector3(transform.localPosition.x, -250, transform.localPosition.z);
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMain()
    {
        /*
        Time.timeScale = 1;
        gameObject.SetActive(false);
        SceneManager.LoadScene(mainMenulevel);
        */
    }

}
