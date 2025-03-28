using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroyFire : MonoBehaviour
{
    // Use this for initialization
    void OnEnable()
    {
        StartCoroutine(WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        Transform childTrans = gameObject.transform.Find("FX_Explosion_Rubble");
        if (childTrans != null)
        {
            childTrans = childTrans.transform.Find("FX_Explosion_Fire");
            if (childTrans != null)
            {
                yield return new WaitForSeconds(childTrans.GetComponent<ParticleSystem>().main.startLifetime.constantMax);
                gameObject.SetActive(false);
            }
        }
    }
}
