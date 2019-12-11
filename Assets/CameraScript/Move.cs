using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float move;
    // Start is called before the first frame update
    void Start()
    {
        move = -6.67f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(move, 0.64f, 4.13f);
        move += 0.01f;
    }
}
