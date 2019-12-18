using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField]
    Transform _player;
    [SerializeField]
    float _rotateSpeed;

    float _yaw, _pitch;
    Vector3 _distance;

    private void Start()
    {
        _rotateSpeed = 1;
        _distance = transform.position;
    }

    void Update()
    {

        //プライヤー位置を追従する
        transform.position = new Vector3(_player.position.x + _distance.x, transform.position.y, _player.position.z + _distance.z);

        _yaw += Input.GetAxis("Mouse X") * _rotateSpeed; //横回転入力
        _pitch -= Input.GetAxis("Mouse Y") * _rotateSpeed; //縦回転入力

        _pitch = Mathf.Clamp(_pitch, -80, 60); //縦回転角度制限する

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f); //回転の実行
    }
}