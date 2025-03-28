using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //Creating object explosion
    public ObjectPooler target;

    // Update is called once per frame
    void Update()
    {
        //Left Clicked on Screen
        if (Input.GetMouseButtonDown(0))
        {
            if (target.tag == "Explosion")
            {
                SoundController.Instance.PlaySound(SoundsGame.explosionSound);
            }
            else if (target.tag == "BlackHole"){
                SoundController.Instance.PlaySound(SoundsGame.blackholeSound);
            }
            //Get pooled object
            GameObject newEffect = target.GetPooledObject();

            //Get mouse position
            var mousePos = Input.mousePosition;
            mousePos.z = newEffect.transform.position.z + 10; //Position of the prefab gameobject

            //Translate local Camera-Position in World-Position
            var objectPos = Camera.main.ScreenToWorldPoint(mousePos);

            //Set the new position for effect and activate object from the objectpool
            newEffect.transform.position = objectPos;
            newEffect.SetActive(true);
            
        }

    }
}
