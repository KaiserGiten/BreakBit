using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour
{
    public Camera mainCamera;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }
    Vector3 originalCameraPosition = new Vector3(0,0,-10);

    private float shakeAmt = 0;

    void OnCollisionEnter2D(Collision2D coll)
    {

        shakeAmt = coll.relativeVelocity.magnitude * .0050f;
        InvokeRepeating("CameraShake", 0, .02f);
        Invoke("StopShaking", 0.2f);

    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt;
            pp.x += quakeAmt;
            //pp.z += quakeAmt * 0.05f;
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

}