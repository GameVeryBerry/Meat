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



