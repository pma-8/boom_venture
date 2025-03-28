using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    public GameObject explosion;
    public int seconds;

    GameObject player;
    GameObject effectGenerator;
    GameObject blackHolePooler;
    GameObject explosionPooler;
    GameObject circularClock;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Rock");
        effectGenerator = GameObject.Find("EffectGenerator");
        blackHolePooler = GameObject.Find("BlackholePooler");
        explosionPooler = GameObject.Find("ExplosionPooler");
        circularClock = CircularTimer.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == explosion.tag)
        {
            SoundController.Instance.PlaySound(SoundsGame.pickUpSound);
            if(effectGenerator == null)
            {
                effectGenerator = GameObject.Find("EffectGenerator");
            }
            if(blackHolePooler == null)
            {
                blackHolePooler = GameObject.Find("BlackholePooler");
            }

            effectGenerator.GetComponent<ObjectGenerator>().target = blackHolePooler.GetComponent<ObjectPooler>();
            circularClock.SetActive(true);

            foreach(Transform child in transform)
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            StartCoroutine(WaitForDespawn());
        }
    }

    IEnumerator WaitForDespawn()
    {
        yield return new WaitForSeconds(seconds);
        effectGenerator.GetComponent<ObjectGenerator>().target = explosionPooler.GetComponent<ObjectPooler>();
        gameObject.SetActive(false);
        foreach (Transform child in transform)
        {
            child.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
