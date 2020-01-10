using UnityEngine;
using System.Collections;
using PlyerState;
using System;

public class PlayerController : MonoBehaviour
{

    //変更前のステート名
    private string _beforeStateName;
    // 移動方向
    private Vector3 _velocity;
    // 移動速度                           
    private const float MOVE_SPEED = 0.3f;
    public const float RESEET_SPEED = 0.0f;
    public const float JUMP_POWER = 5.0f;
    //リジットボディー
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    public Transform _camera;

    private bool _isGround;
    //ステート
    public StateProcessor StateProcessor = new StateProcessor();           //プロセッサー
    public PlayerStateID PlayerStateID = new PlayerStateID();
    public Standing Stand = new Standing();
    public Running Run = new Running();
    public Jumping Jump = new Jumping();

    // Use this for initialization
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        _rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        _camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        //DefaultState
        StateProcessor.State = Stand;
        PlayerStateID._execDelegate = Default;
        Stand._execDelegate = Standing;
        Run._execDelegate = Running;
        Jump._execDelegate = Jumping;
        _isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        //ステートの値が変更されたら実行処理を行う
        if (StateProcessor.State == null)
        {
            return;
        }
        StateProcessor.Execute();
   
        _rb.AddForce(Quaternion.AngleAxis(_camera.transform.eulerAngles.y, Vector3.up) * _velocity, ForceMode.Impulse);
    }

    public void Default()
    {

    }

    public void Standing()
    {
        Debug.Log("StateがRStandingに状態遷移しました。");
        if (_isGround == true)
        {
            _velocity.y = RESEET_SPEED;
            if (Input.GetKey(KeyCode.W))
            {
                _velocity.z = MOVE_SPEED;
                StateProcessor.State = Run;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _velocity.x = -MOVE_SPEED;
                StateProcessor.State = Run;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _velocity.z = -MOVE_SPEED;
                StateProcessor.State = Run;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _velocity.x = MOVE_SPEED;
                StateProcessor.State = Run;
            }
            else
            {
                _velocity = Vector3.zero;
            }


            if (Input.GetKey(KeyCode.Space) && _isGround)
            {
                _velocity.y = JUMP_POWER;
                StateProcessor.State = Jump;
            }
        }
    }

    public void Running()
    {
        Debug.Log("StateがRunningに状態遷移しました。");

        if (Input.GetKeyUp(KeyCode.W))
        {
            _velocity.z = RESEET_SPEED;
            StateProcessor.State = Stand;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _velocity.x = RESEET_SPEED;
            StateProcessor.State = Stand;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _velocity.z = RESEET_SPEED;
            StateProcessor.State = Stand;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _velocity.x = RESEET_SPEED;
            StateProcessor.State = Stand;
        }

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            _velocity.y = JUMP_POWER;
            StateProcessor.State = Jump;
        }

    }
    public void Jumping()
    {
        Debug.Log("StateがJumpingに状態遷移しました。");
        if (_isGround == false)
        {
            _velocity.y  = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            Debug.Log("a");
            _velocity = Vector3.zero;
            StateProcessor.State = Stand;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _velocity.y = RESEET_SPEED;
            _isGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }


}