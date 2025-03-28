using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRisingAnimation : MonoBehaviour
{

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.y < 0)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + speed, transform.localPosition.z);
        }
    }
}
