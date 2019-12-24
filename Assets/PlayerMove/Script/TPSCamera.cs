using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField]
    public Transform _player;

    private float _rotateSpeed;
    private float _rotate;
    private float _yaw;
    private float _pitch;
    private Vector3 _distance;
    private Vector3 _targetPos;
    private Vector3 _cameraPos;
     void Start()
    {
        _rotateSpeed = 3;
        _distance = transform.position;

        _yaw = transform.localEulerAngles.y;
        _pitch = transform.localEulerAngles.x;
        _player = GameObject.Find("Player").GetComponent<Transform>();
        Cursor.visible = false;
    }

    void Update()
    {
       

        transform.position = _player.transform.position;

       

        _yaw   += Input.GetAxis("Mouse X") * _rotateSpeed; //横回転入力
        _pitch -= Input.GetAxis("Mouse Y") * _rotateSpeed; //縦回転入力

       _pitch = Mathf.Clamp(_pitch, -80, 60); //縦回転角度制限する

       

        transform.localEulerAngles = new Vector3(_pitch, _yaw, 0);
   
    }
}