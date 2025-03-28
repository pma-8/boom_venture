using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeterCounter : MonoBehaviour
{
    private Vector3 startPoint;
    public TextMeshProUGUI score;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        startPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float meters = player.transform.position.y - startPoint.y;
        if (meters < 0)
        {
            meters = 0;
        }
        if (meters > ScoreManager.score)
        {
            ScoreManager.score = (int)meters;
        }
        score.text = ScoreManager.score.ToString() + "m";

    }
}
