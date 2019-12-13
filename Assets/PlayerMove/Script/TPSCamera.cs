﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    // 注視対象プレイヤー
    [SerializeField]
    private Transform player;
    // 注視対象プレイヤーからカメラを離す距離
    [SerializeField]
    private float distance = 15.0f;
    // カメラの垂直回転(見下ろし回転)
    [SerializeField]
    private Quaternion vRotation;
    // カメラの水平回転  
    [SerializeField]
    public Quaternion hRotation;     


    // Start is called before the first frame update
    void Start()
    {
        // 回転の初期化
        vRotation = Quaternion.Euler(30, 0, 0);         // 垂直回転(X軸を軸とする回転)は、30度見下ろす回転
        hRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = hRotation * vRotation;     // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        // player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }
}
