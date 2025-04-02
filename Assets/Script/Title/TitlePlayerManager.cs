using UnityEngine;

/// <summary>
/// Playerの管理
/// </summary>
public class TitlePlayerManager : MonoBehaviour
{
    [SerializeField] GameObject m_Player;               //プレイヤーオブジェクト                 

    PlayerAnimation m_animation;                        //プレイヤーのアニメーションクラス

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_animation = m_Player.GetComponent<PlayerAnimation>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //アニメーションの更新
        m_animation.ManagedUpdate((int)PlayerState.State.Idle);
    }
}