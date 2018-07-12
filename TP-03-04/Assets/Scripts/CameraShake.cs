using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    //Handles camera shake
    public Camera mainCamera;
    float shakeAmout = 0;
    public static CameraShake cameraShake;

    public static CameraShake Get()
    {
        return cameraShake;
    }

    void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        cameraShake = this;
    }   

    public void Shake(float amt, float length)
    {
        shakeAmout = amt;
        InvokeRepeating("DoShake", 0, 0.1f);
        Invoke("StopShake", length);
    }
    
    void DoShake()
    {
        if (shakeAmout > 0)
        {
            Vector3 camPos = mainCamera.transform.position;
            float offsetX = Random.value * shakeAmout * 2 - shakeAmout;
            float offsetY = Random.value * shakeAmout * 2 - shakeAmout;
            camPos.x += offsetX;
            camPos.y += offsetY;
            mainCamera.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCamera.transform.localPosition = Vector3.zero;
    }
       
}
