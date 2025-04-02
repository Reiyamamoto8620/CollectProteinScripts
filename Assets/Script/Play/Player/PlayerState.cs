using UnityEngine;

/// <summary>
/// プレイヤーの状態管理
/// </summary>
public class PlayerState : MonoBehaviour
{
    /// <summary>
    /// Playerの状態
    /// </summary>
    public enum State
    {
        None,
        Idle,
        Walk,
        Run,
        Tired,
        Squat
    }
    
    private State m_state;      //Playerの状態を保存する変数

    /// <summary>
    /// 起動時初期化
    /// </summary>
    private void Awake()
    {
        m_state = new State();
    }

    /// <summary>
    /// 状態の更新
    /// </summary>
    public void ManagedUpdate(Vector2 _stickInputValue, bool _isRun, bool _isTired,bool _isSquat)
    {
        //デフォルトのIdle状態を代入
        m_state = State.Idle;

        //スティック入力がある場合、Walk状態にする
        if (_stickInputValue.x != 0 || _stickInputValue.y != 0)
        {
            m_state = State.Walk;
        }

        //Runボタンの入力がり、Walk状態の場合ある場合、Run状態にする
        if (_isRun && m_state == State.Walk)
        {
            m_state = State.Run;
        }

        //スタミナゲージが最大の場合、Tired状態にする
        if (_isTired)
        {
            m_state = State.Tired;
        }

        //バーベルを拾った時にSquat状態にする
        if(_isSquat)
        {
            m_state = State.Squat;
        }
    }
    /// <summary>
    /// 状態を取得
    /// </summary>
    public State GetState()
    {
        return m_state;
    }
}