using UnityEngine;

/// <summary>
/// スタミナゲージのバイブレーション制御
/// </summary>
public class StaminaGaugeVibration : MonoBehaviour
{
    [SerializeField] GameObject m_Gauge;                            //スタミナゲージオブジェクト

    const int m_VibrationMax = 5;                                   //バイブレーションする幅の最大
    const float m_VibrationSpeed = 2.5f;                            //バイブレーションするスピード
    readonly Vector3 m_StartAddValue = new Vector3(1.0f,0f,0f);     //オブジェクトの座標に追加する値の初期値
    Vector3 m_basePosition;                                         //元のポジション
    Vector3 m_addPosition;                                          //加算する座標値
    Vector3 m_addValue;                                             //加算する値

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_addPosition = Vector3.zero;
        m_addValue = m_StartAddValue;
        m_basePosition = m_Gauge.transform.position;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(PlayerState.State _state)
    {
        //ステートがRun状態の時実行
        if (_state == PlayerState.State.Run)
        {
            //加算するポジションがバイブレーションの最大幅より大きい時実行
            if (m_addPosition.x > m_VibrationMax)
            {
                //加算する値をスピード分マイナスする
                m_addValue.x = -m_VibrationSpeed;
            }
            //加算するポジションがバイブレーションの最小幅より小さい時実行
            if (m_addPosition.x < -m_VibrationMax)
            {
                //加算する値をスピード分プラスする
                m_addValue.x = m_VibrationSpeed;
            }
            //加算する座標に加算値を加える
            m_addPosition += m_addValue;

            //オブジェクトに加算した座標を加える。
            m_Gauge.GetComponent<RectTransform>().transform.position += m_addValue;
        }
        //それ以外の時実行
        else
        {
            //オブジェクトの座標を元に戻す
            m_Gauge.GetComponent<RectTransform>().transform.position = m_basePosition;
            //加算する座標をリセット
            m_addPosition = Vector3.zero;
        }
    }
}
