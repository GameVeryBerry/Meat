using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float sin;

    // Start is called before the first frame update
    void Start()
    {
        sin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //時間で移動する
        sin = Mathf.Sin(Time.deltaTime);

        transform.rotation = Quaternion.AngleAxis(sin, transform.position);
    }
}
