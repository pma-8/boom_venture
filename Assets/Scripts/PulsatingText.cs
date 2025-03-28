using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PulsatingText : MonoBehaviour
{
    //Grow parameters
    public float approachSpeed = 0.02f;
    public float growthbound = 2f;
    public float shrinkBound = 0.5f;
    private float currentRatio = 1;

    //The text object we're trying to manipulate
    TextMeshProUGUI text;

    //And something to do the manipulating
    private Coroutine routine;
    private bool keepGoing = true;

    void Awake()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();

        //Start animation
        routine = StartCoroutine(Pulse());
    }

    IEnumerator Pulse()
    {
        //Run this indefinitely
        while (keepGoing)
        {
            //Get bigger for a few seconds
            while(currentRatio != growthbound)
            {
                //Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, growthbound, approachSpeed);

                //Update our text element
                text.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }

            //Shrink for a few seconds
            while(this.currentRatio != this.shrinkBound)
            {
                //Determine the new ratio to use
                currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, approachSpeed);

                //Update our text element
                text.transform.localScale = Vector3.one * currentRatio;

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
