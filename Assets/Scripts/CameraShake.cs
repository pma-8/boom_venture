using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public static CameraShake instance;

    private Vector3 _originalPos;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;
   

    // Start is called before the first frame update
    private void Awake()
    {
        //Singleton
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;
    }

    public static void Shake(float shakeDuration, float shakeAmount, float decreaseFactor)
    {
        instance._originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(shakeDuration, shakeAmount, decreaseFactor));
    }

    public IEnumerator cShake (float shakeDuration, float shakeAmount, float decreaseFactor)
    {
        float endTime = Time.time + shakeDuration;
        while(shakeDuration > 0)
        {
            if (shakeDuration > 0)
            {
                gameObject.transform.localPosition = _originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
                shakeAmount -= Time.deltaTime * decreaseFactor;
                if (shakeAmount <= 0) shakeAmount = 0;
            }
            else
            {
                shakeDuration = 0f;
                gameObject.transform.localPosition = _originalPos;
            }
            yield return null;
        }

        transform.localPosition = _originalPos;
    }
}
