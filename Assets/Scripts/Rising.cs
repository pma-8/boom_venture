using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rising : MonoBehaviour
{
    public GameObject lavaAnchor;
    public GameObject mainCamera;
    
    public GameObject pauseMenu;
    public GameObject deathMenu;

    private float old_pos;
    private float new_pos;

    public float spd;

    public void Start()
    {
        old_pos = mainCamera.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            new_pos = mainCamera.transform.position.y;
            if (old_pos < new_pos)
            {
                gameObject.transform.Translate(new Vector3(0, spd, 0) * Time.deltaTime);

                if (lavaAnchor.transform.position.y > gameObject.transform.position.y)
                {
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, lavaAnchor.transform.position.y, gameObject.transform.position.z);
                }
            }
    }
}
