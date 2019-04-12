using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float smoothing = 5f;

    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = new Vector3(Mathf.Clamp(Mathf.Lerp(transform.position.x, targetCamPos.x, smoothing * Time.deltaTime), -5.38f, 5.38f)
            , Mathf.Clamp(Mathf.Lerp(transform.position.y, targetCamPos.y, smoothing * Time.deltaTime), 0, 10)
            , Mathf.Clamp(Mathf.Lerp(transform.position.z, targetCamPos.z, smoothing * Time.deltaTime), -9f, -1.25f));
        //transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
