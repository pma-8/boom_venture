using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    public static int highscore;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
    }
}
