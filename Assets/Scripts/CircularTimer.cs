using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularTimer : MonoBehaviour
{
    public static GameObject instance;
    Image fillImg;
    public float timeAmount;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        fillImg = gameObject.GetComponent<Image>();
        time = timeAmount;
        instance = gameObject;
        gameObject.SetActive(false);
        GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            fillImg.fillAmount = time / timeAmount;
        }

        if(time <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        fillImg.fillAmount = 1;
        time = timeAmount;
    }
}
