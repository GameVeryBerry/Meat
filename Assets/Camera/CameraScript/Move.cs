using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float sin;
    bool sinState;
    float move;
    Quaternion qua;

    // Start is called before the first frame update
    void Start()
    {
        sin = 0;
        sinState = false;
    }

    // Update is called once per frame
    void Update()
    {
        //時間で移動する
        sin = Mathf.Sin(Time.time);

        //一度マイナスになったらその後は移動を二倍にする
        if (sin < 0) sinState = true;

        if (sinState)
        {
            qua = Quaternion.Euler(0, sin / 2, 0);
        }
        else
        {
            qua = Quaternion.Euler(0, sin / 4, 0);
        }
        transform.rotation = transform.rotation * qua;
    }
}