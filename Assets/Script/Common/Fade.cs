using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// フェードイン・フェードアウトクラス
/// </summary>
public class Fade : MonoBehaviour
{
    [SerializeField] GameObject m_FadePanel;    //フェードするオブジェクト
    const float m_FadeSpeed = 0.1f;             //フェードするスピード
    const int m_FadeOutAlfaMax = 1;             //フェードアウトのアルファ値の最大

    Color m_fadePanelColor;                     //フェードするオブジェクトのカラー
    bool m_isFadeInEnd;                         //フェードインの終了判定
    bool m_isFadeOutEnd;                        //フェードアウトの終了判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        //フェードさせるオブジェクトのカラーを取得
        m_fadePanelColor = m_FadePanel.GetComponent<Image>().color;
        //フェードするオブジェクトを有効化
        m_FadePanel.SetActive(true);
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool _isFadeIn, bool _isFadeOut)
    {
        //フェードイン
        FadeIn(_isFadeIn);
        //フェードアウト
        FadeOut(_isFadeOut);
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    void FadeIn(bool _isFadeIn)
    {
        //フェードインが終了しておらず、フェードインが実行中の時実行
        if (!m_isFadeInEnd && _isFadeIn)
        {
            //フェードインオブジェクトのアルファ値を減らす
            m_fadePanelColor.a -= m_FadeSpeed;
            //減らしたアルファ値をオブジェクトに適用
            m_FadePanel.GetComponent<Image>().color = m_fadePanelColor;
            //オブジェクトのアルファ値が0以下の時実行
            if (m_fadePanelColor.a <= 0)
            {
                //フェードインの終了判定をTRUEにする。
                m_isFadeInEnd = true;
            }
        }
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    void FadeOut(bool _isFadeOut)
    {
        //フェードアウトが終了しておらず、フェードアウトが実行中の時実行
        if (!m_isFadeOutEnd && _isFadeOut)
        {
            //フェードアウトオブジェクトのアルファ値を増やす
            m_fadePanelColor.a += m_FadeSpeed;
            //増やしたアルファ値をオブジェクトに適用
            m_FadePanel.GetComponent<Image>().color = m_fadePanelColor;
            //アルファ値が[m_FadeOutAlfaMax]以上の時実行
            if (m_fadePanelColor.a >= m_FadeOutAlfaMax)
            {
                //フェードアウトの終了判定をtrueにする。
                m_isFadeOutEnd = true;
            }
        }
    }

    /// <summary>
    /// フェードインの終了判定を取得
    /// </summary>
    public bool GetIsFadeOutEnd()
    {
        return m_isFadeOutEnd;
    }

    /// <summary>
    /// フェードアウトの終了判定を取得
    /// </summary>
    public bool GetIsFadeInEnd()
    {
        return m_isFadeInEnd;
    }
}
