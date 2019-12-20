using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField]
    Transform _player;
    [SerializeField]
    float _rotateSpeed;
    float _rotate;
    float _yaw;
    float _pitch;
    Vector3 _distance;
    Vector3 _targetPos;
    Vector3 _cameraPos;
    private void Start()
    {
        _rotateSpeed = 1;
        _distance = transform.position;

        _yaw = 0;
        _pitch = 0;
        Debug.Log(_distance);
       
    }

    void Update()
    {
       // Debug.Log(_targetPos);
        Debug.Log(transform.position);
        //プライヤー位置を追従する
        _targetPos = _player.transform.position;

        float pre_yaw = _yaw;

        _yaw   += Input.GetAxis("Mouse X") * _rotateSpeed; //横回転入力
        _pitch -= Input.GetAxis("Mouse Y") * _rotateSpeed; //縦回転入力

       _pitch = Mathf.Clamp(_pitch, -80, 60); //縦回転角度制限する

        _rotate = _yaw - pre_yaw;

        transform.RotateAround(_targetPos, Vector3.up, _rotate);
        transform.LookAt(_targetPos, Vector3.up);
//        transform.position = _targetPos + (transform.position - _targetPos).normalized * _distance.magnitude;
        transform.position = _targetPos + (transform.position - _targetPos + _distance).normalized * _distance.magnitude;

       
        
    }
}