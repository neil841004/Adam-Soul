using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    Transform charV3;
    Vector3 ObjectV3;
    Vector3 TargetV3;
    public float disparity = 0;
	public float layerUp = 0.01f;
	public float layerDown = 0.01f;

    // Use this for initialization
    void Start()
    {
        charV3 = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        TargetV3 = charV3.position;
        ObjectV3 = transform.position;
        if (ObjectV3.z - disparity > TargetV3.z)
        {
            ObjectV3.y = TargetV3.y - layerDown;
            this.transform.position = ObjectV3;
        }
        if (ObjectV3.z - disparity < TargetV3.z)
        {
            ObjectV3.y = TargetV3.y + layerUp;
            this.transform.position = ObjectV3;
        }

    }
}
