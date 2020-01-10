using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMove : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        speed = new Vector3(10.0f, 0.0f, 0.0f);

        rigid.AddForce(speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
