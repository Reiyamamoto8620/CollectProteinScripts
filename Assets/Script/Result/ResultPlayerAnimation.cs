using UnityEngine;

/// <summary>
/// リザルトのプレイヤーアニメーション制御クラス
/// </summary>
public class ResultPlayerAnimation : MonoBehaviour
{
    Animator m_animator;           //アニメーターのクラス

    /// <summary>
    /// 生成時に実行
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
        m_animator.SetBool("isIdle", _state == (int)ResultPlayerManager.State.Idle);

        m_animator.SetBool("isDance", _state == (int)ResultPlayerManager.State.Dance);
    }
}
