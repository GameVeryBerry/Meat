using UnityEngine;
using System.Collections;

//キューブオブジェクトのステート
namespace PlyerState
{

    //ステートの実行を管理するクラス
    public class StateProcessor
    {
        //ステート本体
        private PlyerState _State;
        public PlyerState State
        {
            set { _State = value; }
            get { return _State; }
        }

        // 実行ブリッジ
        public void Execute()
        {
            State.Execute();
        }

    }

    //ステートのクラス
    public abstract class PlyerState
    {
        //デリゲート
        public delegate void ExecuteState();
        public ExecuteState _execDelegate;

        //実行処理
        public virtual void Execute()
        {
            if (_execDelegate != null)
            {
                _execDelegate();
            }
        }

        //ステート名を取得するメソッド
        public abstract string GetStateName();
    }

    // 以下状態クラス

    //  DefaultPosition
    public class PlayerStateID : PlyerState
    {
        public override string GetStateName()
        {
            return "State:Default";
        }
    }

    //  StateA
    public class Standing : PlyerState
    {
        public override string GetStateName()
        {
            return "Standing";
        }
    }

    //  StateB
    public class Running : PlyerState
    {
        public override string GetStateName()
        {
            return "Running";
        }
    }


    public class Jumping : PlyerState
    {
        public override string GetStateName()
        {
            return "Jumping";
        }
    }

}


//namespace CharacterState
//{
//    / <summary>
//    / ステートの実行を管理するクラス
//    / </summary>
//    public class StateProcessor
//    {
//        public ReactiveProperty<CharacterState> State { get; set; } = new ReactiveProperty<CharacterState>();

//        実行ブリッジ
//        public void Execute() => State.Value.Execute();
//    }

//    / <summary>
//    / ステートのクラス
//    / </summary>
//    public abstract class CharacterState
//    {
//        デリゲート
//        public Action ExecAction { get; set; }

//        実行処理
//        public virtual void Execute()
//        {
//            if (ExecAction != null) ExecAction();
//        }

//        ステート名を取得するメソッド
//        public abstract string GetStateName();
//    }

//    =================================================================================
//    以下状態クラス
//    =================================================================================

//    / <summary>
//    / 何もしていない状態
//    / </summary>
//    public class CharacterStateStanding : CharacterState
//    {
//        public override string GetStateName()
//        {
//            return "State:Idle";
//        }
//    }

//    / <summary>
//    / 走っている状態
//    / </summary>
//    public class CharacterStateRunning : CharacterState
//    {
//        public override string GetStateName()
//        {
//            return "State:Run";
//        }
//    }

//    / <summary>
//    / 攻撃している状態
//    / </summary>
//    public class CharacterStateJumping : CharacterState
//    {
//        public override string GetStateName()
//        {
//            return "State:Attack";
//        }

//        public override void Execute()
//        {
//            Debug.Log("なにか特別な処理をしたいときは派生クラスにて処理をしても良い");
//            if (ExecAction != null) ExecAction();
//        }
//    }
//}
