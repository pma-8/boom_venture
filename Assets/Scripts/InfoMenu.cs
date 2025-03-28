using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    public GameObject title;
    public GameObject startButton;
    public GameObject infoMenu;

    public Toggle infoToggle;
    public Image infoIcon;

    public void SwitchInfoMenu()
    {
        if (infoToggle.isOn)
        {
            infoIcon.color = new Color(0.7843137f, 0.7843137f, 0.7843137f, 1); //Grey
            title.SetActive(false);
            startButton.SetActive(false);
            infoMenu.SetActive(true);
        }
        else
        {
            infoMenu.transform.localPosition = new Vector3(infoMenu.transform.localPosition.x, -250, infoMenu.transform.localPosition.z);
            infoIcon.color = Color.white;
            title.SetActive(true);
            startButton.SetActive(true);
            infoMenu.SetActive(false);
        }
    }
}
