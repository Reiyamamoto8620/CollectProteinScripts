using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Playerの管理
/// </summary>
public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject m_Player;                   //プレイヤーオブジェクト
    [SerializeField] GameObject m_StaminaGauge;             //ダッシュゲージマネージャーオブジェクト                  
    [SerializeField]
    PlaySceneDataScriptableObject m_PlaySceneData;          //Playシーンのデータ共有用のスクリプタブルオブジェクト
    [SerializeField] GameObject m_StaminaGaugeVibration;    //スタミナゲージのバイブレーション制御オブジェクト
    [SerializeField] GameObject m_RunButtonAction;          //ランボタンが押された時の制御オブジェクト
    [SerializeField] GameObject m_SweatAction;              //ゲージに表示する汗の制御

    PlayerInput m_input;                                //入力判定クラス
    PlayerAction m_action;                              //プレイヤーのアクションクラス
    PlayerAnimation m_animation;                        //プレイヤーのアニメーションクラス
    PlayerState m_state;                                //プレイヤーのステートクラス
    PlayerCollider m_collider;                          //プレイヤーのコライダークラス
    PlayerScore m_score;                                //プレイヤーのスコアクラス
    StaminaGaugeVibration m_staminaGaugeVibration;      //スタミナゲージのバイブレーション制御クラス
    RunButtonAction m_runButtonAction;                  //ランボタンが押された時の制御クラス
    SweatAction m_sweatAction;                          //ゲージに表示する汗の制御クラス

    StaminaGauge m_staminaGauge;                        //ダッシュゲージ


    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_input = m_Player.GetComponent<PlayerInput>();
        m_action = m_Player.GetComponent<PlayerAction>();
        m_animation = m_Player.GetComponent<PlayerAnimation>();
        m_state = m_Player.GetComponent<PlayerState>();
        m_collider = m_Player.GetComponent<PlayerCollider>();
        m_score = m_Player.GetComponent<PlayerScore>();
        m_staminaGaugeVibration = m_StaminaGaugeVibration.GetComponent<StaminaGaugeVibration>();
        m_runButtonAction = m_RunButtonAction.GetComponent<RunButtonAction>();
        m_sweatAction= m_SweatAction.GetComponent<SweatAction>();
        m_staminaGauge = m_StaminaGauge.GetComponent<StaminaGauge>();
    }

    /// <summary>
    /// 削除時に実行
    /// </summary>
    void OnDestroy()
    {
        //スクリプタブルオブジェクトにスコアを格納
        m_PlaySceneData.m_score = m_score.GetScore();
        m_PlaySceneData.m_playerPosition = m_Player.transform.position;
        m_PlaySceneData.m_playerRotation = m_Player.transform.rotation;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //入力の更新
        m_input.ManagedUpdate();
        //スタミナゲージの増減値を設定
        m_staminaGauge.SetNowStaminaGaugeIncreaseValue(
            m_input.GetRunBarrageSpeed(), m_state.GetState());
        //スコアの更新
        m_score.ManagedUpdate(m_collider.GetIsHitProtein());
        //アクションの更新
        m_action.ManagedUpdate(m_input.GetStickInputValue(), m_state.GetState());
        //コライダーの更新
        m_collider.ManagedUpdate();
        //Playerの状態を更新
        m_state.ManagedUpdate(m_input.GetStickInputValue(), m_input.GetIsRun(),
            m_staminaGauge.GetIsStaminaGaugeMax(), m_collider.GetIsHitBarbell());
        //スタミナゲージの更新
        m_staminaGauge.ManagedUpdate(m_state.GetState());
        //スタミナゲージのバイブレーションの更新
        m_staminaGaugeVibration.ManagedUpdate(m_state.GetState());
        //ランボタンが押されたときのアクションを更新
        m_runButtonAction.ManagedUpdate(m_state.GetState());
        //汗の制御を更新
        m_sweatAction.ManagedUpdate(m_state.GetState());
        //アニメーションの更新
        m_animation.ManagedUpdate((int)m_state.GetState());
    }
}
