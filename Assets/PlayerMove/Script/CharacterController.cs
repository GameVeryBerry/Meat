using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class CharacterController : MonoBehaviour
{
    //変更前のステート名
    private string _prevStateName;
    // 移動方向
    [SerializeField]
    private Vector3 _velocity;              
    // 移動速度                           
    [SerializeField]
    private float _moveSpeed = 5.0f;
    //リジットボディー
    [SerializeField]
    private Rigidbody _rb;

    //ステート
    public CharacterState.StateProcessor StateProcessor { get; set; } = new CharacterState.StateProcessor();
    public CharacterState.CharacterStateStanding StateStanding { get; set; } = new CharacterState.CharacterStateStanding();
    public CharacterState.CharacterStateRunning StateRunning { get; set; } = new CharacterState.CharacterStateRunning();
    public CharacterState.CharacterStateJumping StateJumping { get; set; } = new CharacterState.CharacterStateJumping();

    void Start()
    {
        //ステートの初期化
        StateProcessor.State.Value = StateStanding;
        StateStanding.ExecAction = Standing;
        StateRunning.ExecAction = Running;
        StateJumping.ExecAction = Jumping;

        //ステートの値が変更されたら実行処理を行うようにする
        StateProcessor.State
            .Where(_ => StateProcessor.State.Value.GetStateName() != _prevStateName)
            .Subscribe(_ =>
            {
                Debug.Log("Now State:" + StateProcessor.State.Value.GetStateName());
                _prevStateName = StateProcessor.State.Value.GetStateName();
                StateProcessor.Execute();
            })
            .AddTo(this);

        _rb = GetComponent<Rigidbody>();
        _velocity = Vector3.zero;
    }

    /// <summary>
    /// アップデート
    /// </summary>
    void Update()
    {
        StateProcessor.Execute();

        _rb.velocity = _velocity;

        _velocity = _velocity.normalized * _moveSpeed * Time.deltaTime;
    }

    /// <summary>
    /// 何もしていない状態
    /// </summary>
    public void Standing()
    {
        Debug.Log("StateがRStandingに状態遷移しました。");

        if (Input.GetKey(KeyCode.W))
        { 
            _velocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
            _velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            _velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            _velocity.x += 1;
        // 速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
      
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    public void Running()
    {
       
        Debug.Log("StateがRunningに状態遷移しました。");
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    public void Jumping()
    {
        Debug.Log("StateがJumpingに状態遷移しました。");
    }
}
