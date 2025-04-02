using UnityEngine;

/// <summary>
/// 汗の表示制御
/// </summary>
public class SweatAction : MonoBehaviour
{
    [SerializeField] GameObject m_HeadSweat;    //頭部分の汗オブジェクト
    [SerializeField] GameObject m_LegSweat;     //足部分の汗オブジェクト
    bool m_isHeadSweat;                         //頭部分の汗の表示判定
    bool m_isLegSweat;                          //足部分の汗表示判定
    int m_changeSweatDrawCount;                 //汗の表示位置の変更カウント

    const int m_ChangeSweatDrawCountMax = 30;   //汗の表示位置の変更カウントの最大値

    /// <summary>
    /// 生成時に初期化
    /// </summary>
    void Awake()
    {
        m_isHeadSweat = true;
        m_isLegSweat = false;
        m_changeSweatDrawCount = m_ChangeSweatDrawCountMax;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(PlayerState.State _state)
    {
        //ステートがTiredの場合実行
        if (_state == PlayerState.State.Tired)
        {
            //汗の表示位置の変更カウントが最大値より大きい時実行
            if (m_changeSweatDrawCount > m_ChangeSweatDrawCountMax)
            {
                //頭の汗を有効化
                m_HeadSweat.SetActive(m_isHeadSweat);
                //足の汗を有効化
                m_LegSweat.SetActive(m_isLegSweat);
                //足の汗の表示判定を反転
                m_isLegSweat = !m_isLegSweat;
                //頭の汗の表示判定を反転
                m_isHeadSweat = !m_isHeadSweat;
                //汗の表示位置の変更カウントをリセット
                m_changeSweatDrawCount = 0;
            }
            //汗の表示位置の変更カウントを進める
            m_changeSweatDrawCount++;
        }
        //それ以外の時実行
        else
        {
            m_HeadSweat.SetActive(false);   //頭の汗を無効化
            m_LegSweat.SetActive(false);    //足の汗を無効化
        }
    }
}
