using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイマーの制御クラス
/// </summary>
public class Timer : MonoBehaviour
{
    [SerializeField] GameObject m_Timer;        //タイマーオブジェクト
    Image m_timerImg;                           //タイマーゲージの画像
    
    /// <summary>
    /// 生成時に初期化
    /// </summary>
    void Awake()
    {
        m_timerImg = m_Timer.GetComponent<Image>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(float _timer)
    {
        //タイマーの残量をタイマーの値に合わせて増減させる
        m_timerImg.fillAmount = _timer/FPSFixed.FPS;
    }
}
