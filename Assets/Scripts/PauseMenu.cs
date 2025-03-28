using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject explosion;
    public GameObject pauseMenu;
    public GameObject meterScore;
    public TextMeshProUGUI pausedCurrentScore;
    public TextMeshProUGUI currentScore;
    public GameObject background;
    public GameObject audioButtons;

    public void OnMouseEnter()
    {
        explosion.SetActive(false);
    }

    public void OnMouseExit()
    {
        explosion.SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        LeanTween.scale(background, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeanTween.scale(background, new Vector3(1f, 1f, 1f), 0.1f);

    }


    public void PauseGame()
    {
        SoundController.Instance.PlaySound(SoundsGame.buttonPressSound);
        SoundController.Instance.PlaySound(SoundsGame.menuMovingSound);
        Time.timeScale = 0;
        audioButtons.SetActive(true);
        gameObject.SetActive(false);
        explosion.SetActive(false);
        pauseMenu.SetActive(true);
        pausedCurrentScore.text = currentScore.text;
        meterScore.SetActive(false);
        background.SetActive(false);
        pauseMenu.transform.localPosition = new Vector3(transform.localPosition.x, -250, transform.localPosition.z);
    }

    public void ResumeGame()
    {
        SoundController.Instance.PlaySound(SoundsGame.buttonPressSound);
        Time.timeScale = 1;
        audioButtons.SetActive(false);
        gameObject.SetActive(true);
        explosion.SetActive(true);
        meterScore.SetActive(true);
        pauseMenu.SetActive(false);
        background.SetActive(true);

    }

    public void RestartGame()
    {
        SoundController.Instance.PlaySound(SoundsGame.buttonPressSound);
        Time.timeScale = 1;
        audioButtons.SetActive(true);
        gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        explosion.SetActive(true);
        meterScore.SetActive(true);
        background.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
