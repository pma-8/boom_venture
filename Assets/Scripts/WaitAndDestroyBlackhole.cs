using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAndDestroyBlackhole : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(WaitCoroutine());
    }
    // Use this for initialization
    IEnumerator WaitCoroutine()
    {
        //After activating object, deactivate it after waiting the maximum lifetime of a particle
        Transform childTrans = gameObject.transform.Find("BlackHole_ForceField");
        if(childTrans != null)
        {
            childTrans = childTrans.transform.Find("BlackHole_Effect");
            if(childTrans != null)
            {
                yield return new WaitForSeconds(childTrans.GetComponent<ParticleSystem>().main.startLifetime.constantMax);
                gameObject.SetActive(false);
            }
        }
    }
}
