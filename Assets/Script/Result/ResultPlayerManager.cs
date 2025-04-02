using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルトのプレイヤー制御マネージャー
/// </summary>
public class ResultPlayerManager : MonoBehaviour
{
    ResultPlayerAnimation m_animation;                  //プレイヤーのアニメーションクラス

    [SerializeField] GameObject m_player;               //プレイヤーオブジェクト                 

    [SerializeField]
    PlaySceneDataScriptableObject m_scriptableObject;   //Playシーンのスクリプタブルオブジェクト

    /// <summary>
    /// ステート
    /// </summary>
    public enum State
    {
        None,
        Idle,
        Dance
    }
    
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_animation = m_player.GetComponent<ResultPlayerAnimation>();

        //スクリプタブルオブジェクトから座標と回転値を獲得
        m_player.transform.position = m_scriptableObject.m_playerPosition;
        m_player.transform.rotation = m_scriptableObject.m_playerRotation;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //シーンがResultの時実行
        if (SceneManager.GetActiveScene().name == "Result")
        {
            //アニメーションの更新
            m_animation.ManagedUpdate((int)State.Dance);
        }
        //それ以外の時実行
        else
        {
            //アニメーションの更新
            m_animation.ManagedUpdate((int)State.Idle);
        }
    }
}
