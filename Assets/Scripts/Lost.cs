using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public DeathMenu theDeathScreen;
    public GameObject pauseButton;

    public GameObject discoviDespawnPoint;
    public GameObject lava;
    public GameObject explosionGenerator;


    private void DeactivateEverything()
    {
        theDeathScreen.gameObject.SetActive(true);
        explosionGenerator.SetActive(false);
        gameObject.SetActive(false);
    }

    public void OnBecameInvisible()
    {
        if (theDeathScreen != null)
        {
           DeactivateEverything();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == lava)
        {
            SoundController.Instance.PlaySound(SoundsGame.fallingIntoLavaSound);
            if (theDeathScreen != null)
            {
            DeactivateEverything();
            }
        }
        else if (collision.gameObject.name.Contains("Sticky"))
        {
            SoundController.Instance.PlaySound(SoundsGame.stickyContactSound);
        }
        else if (collision.gameObject.name.Contains("Bouncy"))
        {
            SoundController.Instance.PlaySound(SoundsGame.bounceContactSound);
        }
        else if(!collision.gameObject.name.Contains("Ground"))
        {
            SoundController.Instance.PlaySound(SoundsGame.rockContactSound);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < discoviDespawnPoint.transform.position.y)
        {
            gameObject.SetActive(false);
        }
    }
}
