using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    public GameObject effectGenerator;
    public GameObject pauseButton;
    public GameObject scoreManager;
    public GameObject title;
    public GameObject background;
    public GameObject audioButtons;
    public GameObject creditButton;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundController.Instance.PlaySound(SoundsGame.buttonPressSound);
        LeanTween.scale(background, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        LeanTween.scale(background, new Vector3(1f, 1f, 1f), 0.1f);

    }

    public void Starting()
    {
        creditButton.SetActive(false);
        background.SetActive(false);
        effectGenerator.SetActive(true);
        pauseButton.SetActive(true);
        scoreManager.SetActive(true);
        gameObject.SetActive(false);
        title.SetActive(false);
        audioButtons.SetActive(false);
    }
}
