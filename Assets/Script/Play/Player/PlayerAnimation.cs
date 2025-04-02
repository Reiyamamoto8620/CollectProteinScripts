using UnityEngine;

/// <summary>
/// Playerのアニメーションを管理
/// </summary>
public class PlayerAnimation : MonoBehaviour
{

     Animator m_animator;           //アニメーターのクラス
    
    /// <summary>
    /// 起動時初期化
    /// </summary>
     void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 状態を参照して、アニメーションのフラグを設定
    /// </summary>
    public void ManagedUpdate(int _state)
    {
        m_animator.SetBool("isIdle", _state == (int)PlayerState.State.Idle);

        m_animator.SetBool("isWalk", _state == (int)PlayerState.State.Walk);

        m_animator.SetBool("isRun", _state == (int)PlayerState.State.Run);

        m_animator.SetBool("isTired", _state == (int)PlayerState.State.Tired);

        m_animator.SetBool("isSquat", _state == (int)PlayerState.State.Squat);
    }
}
