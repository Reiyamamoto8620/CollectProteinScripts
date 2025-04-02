using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スタミナゲージの管理
/// </summary>
public class StaminaGauge : MonoBehaviour
{
    [SerializeField] GameObject m_StaminaGaugeBar;       //スタミナゲージゲージのオブジェクト

    //ゲージ総量　100F
    //最低ダッシュ継続時間　2秒
    //最大ダッシュ継続時間　10秒


    //段階別の連打速度のゲージの増加量
    const float m_FirstSpeed = -0.1667f;       //最高速
    const float m_SecondSpeed = -0.2083f;      //高速
    const float m_ThirdSpeed = -0.2778f;       //通常速
    const float m_FourthSpeed = -0.4167f;      //準低速
    const float m_FifthSpeed = -0.5556f;       //低速
    const float m_SixthSpeed = -0.8333f;       //最低速

    //連打速度のフレームの段階
    const int m_FirstBarrageSpeed = 6;        //最高速
    const int m_SecondBarrageSpeed = 8;       //高速
    const int m_ThirdBarrageSpeed = 10;       //通常速
    const int m_FourthBarrageSpeed = 15;      //準低速
    const int m_FifthBarrageSpeed = 20;       //低速
    const int m_SixthBarrageSpeed = 30;       //最低速

    const float m_GaugeRecoverySpeed = 0.2f;         //ゲージの回復速度
    const float m_TiredGaugeRecoverySpeed = 0.5f;    //Tired時のゲージの回復速度

    const int m_StaminaGaugeMax = 100;               //スタミナゲージの最大値

    const int m_StaminaGaugeAdjust = 100;            //スタミナゲージの値を調整


    //変数
    float m_nowStaminaGaugeIncreaseValue;    //現在のゲージの増減量
    bool m_isStaminaGaugeMax;                //ゲージが最大に達したかの判定

    bool m_isGaugeDown;                      //ゲージが減少したかの判定



    Image m_staminaGaugeBar;                 //スタミナゲージの画像

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_staminaGaugeBar = m_StaminaGaugeBar.GetComponent<Image>();
        m_staminaGaugeBar.fillAmount = m_StaminaGaugeMax / m_StaminaGaugeAdjust;
        m_nowStaminaGaugeIncreaseValue = 0;
        m_isStaminaGaugeMax = false;
        m_isGaugeDown = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(PlayerState.State _state)
    {
        //ゲージに現在のゲージの増減量を足して値を操作
        m_staminaGaugeBar.fillAmount += m_nowStaminaGaugeIncreaseValue/ m_StaminaGaugeAdjust;
        //ステートがTiredの時実行
        if(_state == PlayerState.State.Tired)
        {
            //スタミナゲージの色を赤に変更
            m_staminaGaugeBar.color = Color.red;
        }
        //それ以外の時実行
        else
        {
            //スタミナゲージの色を緑に変更
            m_staminaGaugeBar.color = Color.green;
        }

        //ゲージの値が最大になった時実行
        if (m_staminaGaugeBar.fillAmount >= m_StaminaGaugeMax / m_StaminaGaugeAdjust)
        {
            //スタミナを最大に固定
            m_staminaGaugeBar.fillAmount = m_StaminaGaugeMax / m_StaminaGaugeAdjust;
            //スタミナゲージの最大判定をfalse
            m_isStaminaGaugeMax = false;
        }
        //ゲージの値が0以下に達した時実行
        if (m_staminaGaugeBar.fillAmount <= 0)
        {
            //スタミナゲージを0で固定
            m_staminaGaugeBar.fillAmount = 0;
            //スタミナゲージの最大判定をtrueにする
            m_isStaminaGaugeMax = true;
        }
    }

    /// <summary>
    /// スタミナゲージの値の増減値を設定
    /// </summary>
    public void SetNowStaminaGaugeIncreaseValue(int dashBarrageSpeed, PlayerState.State _state)
    {
        //スクワット中はゲージの増減なし
        if (_state == PlayerState.State.Squat)
        {
            m_nowStaminaGaugeIncreaseValue = 0;
        }
        //Run中の場合はゲージを減らす
        else if (_state == PlayerState.State.Run && !m_isStaminaGaugeMax)
        {
            //最高速
            if (dashBarrageSpeed <= m_FirstBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_FirstSpeed;
            }
            //高速
            else if (dashBarrageSpeed <= m_SecondBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_SecondSpeed;
            }
            //普通
            else if (dashBarrageSpeed <= m_ThirdBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_ThirdSpeed;
            }
            //準低速
            else if (dashBarrageSpeed <= m_FourthBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_FourthSpeed;
            }
            //低速
            else if (dashBarrageSpeed <= m_FifthBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_FifthSpeed;
            }
            //最低速
            else if (dashBarrageSpeed <= m_SixthBarrageSpeed)
            {
                m_nowStaminaGaugeIncreaseValue = m_SixthSpeed;
            }
        }
        //Tired状態の場合、専用の値でゲージを増やすらす。
        else if(_state == PlayerState.State.Tired)
        {
            m_nowStaminaGaugeIncreaseValue = m_TiredGaugeRecoverySpeed;
        }
        //Run状態ではなく、isGaugeDownがfalseの場合はゲージを増やす
        else if(!m_isGaugeDown)
        {
            m_nowStaminaGaugeIncreaseValue = m_GaugeRecoverySpeed;
        }
        //上記のどれも当てはまらない時はゲージは増減しない
        else
        {
            m_nowStaminaGaugeIncreaseValue = 0;
        }
    }

    /// <summary>
    /// スタミナゲージがマックスかの判定を取得
    /// </summary>
    public bool GetIsStaminaGaugeMax()
    {
        return m_isStaminaGaugeMax;
    }
}