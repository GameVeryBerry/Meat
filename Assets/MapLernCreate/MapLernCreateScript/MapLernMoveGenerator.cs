//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
public class MapLernMoveGenerator : MonoBehaviour
{
    public GameObject moveObject;
    public GameObject goalPoint;

    Vector3 move_Position;
    Vector3 toGoPoint;

    float moveSpeed = 0.01f; //移動速度

    void Start()
    {
        move_Position = moveObject.transform.position; //移動させたいオブジェクトの座標
        toGoPoint = goalPoint.transform.position;      //目的地に設置したオブジェクトの座標
    }

    void Update()
    {
        //if (move_Position.z > toGoPoint.z)
        //{
            move_Position.z -= moveSpeed;
            moveObject.transform.position = move_Position;
        //}
    }
}