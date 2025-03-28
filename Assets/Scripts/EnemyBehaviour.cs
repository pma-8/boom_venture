using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public int life;
    public GameObject explosion;
    public GameObject blackhole;
    public GameObject[] lifes;

    GameObject deathMenu;
    GameObject player;
    GameObject rWall;
    GameObject lWall;
    Material lifeMaterial;
    Color lifeColor;
    float lifeTransparency;
    int currentLifes;
    int resetLife;
    float reduceSpeed = 0.005f;

    Vector3 dir = new Vector3(1, 0, 0);

    private void Start()
    {
        lifeTransparency = 0;
        currentLifes = life - 1;
        resetLife = life;
        deathMenu = FindInActiveObjectByName("DeathMenu");
        player = GameObject.Find("Rock");
        rWall = GameObject.Find("RightWall");
        lWall = GameObject.Find("LeftWall");
        lifeMaterial = lifes[0].GetComponent<Renderer>().material;
        lifeColor = lifeMaterial.color;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.Translate(dir * Time.deltaTime * 5);
    }

    private void OnDisable()
    {
        resetLife = 2;
        life = resetLife;
        currentLifes = resetLife - 1;
        lifeTransparency = 0;

        foreach (GameObject life in lifes)
        {
            life.SetActive(true);
        }
    }

    private void Update()
    {
        if (life <= 0)
        {
            gameObject.SetActive(false);
            life = resetLife;
            currentLifes = resetLife - 1;
            lifeTransparency = 0;

            foreach (GameObject life in lifes)
            {
                life.SetActive(true);
            }
        }

        foreach (GameObject life in lifes)
        {
            life.GetComponent<Renderer>().material.color = new Color(lifeColor.r, lifeColor.g, lifeColor.b, lifeTransparency);
        }

        if (lifeTransparency > 0)
        {
            if (lifeTransparency - reduceSpeed == 0)
            {
                lifeTransparency = 0;
            }
            else
            {
                lifeTransparency -= reduceSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == rWall || collision.gameObject == lWall)
        {
            dir.x = dir.x * -1;
        }

        if (collision.gameObject == player)
        {
            deathMenu.SetActive(true);
        }

        if (collision.gameObject.tag == explosion.tag)
        {
            SoundController.Instance.PlaySound(SoundsGame.deathMobSound);

            if (currentLifes > -1 && currentLifes < lifes.Length)
            {
                lifes[currentLifes].SetActive(false);
                currentLifes--;
                life--;

                lifeTransparency = 1;
            }
        }

        if (collision.gameObject.tag == blackhole.tag)
        {
            SoundController.Instance.PlaySound(SoundsGame.deathMobSound);

            foreach (GameObject lifeObject in lifes)
            {
                lifeObject.SetActive(false);
                currentLifes = 0;
                life = 0;
                lifeTransparency = 1;
            }
        }
    }

    GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
