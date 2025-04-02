using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランボタンが押されたときの制御
/// </summary>
public class RunButtonAction : MonoBehaviour
{
    [SerializeField] GameObject m_RunButtonImage;       //ランボタンの画像
    [SerializeField] Sprite m_ButtonOFFImage;           //ボタンが押されていない画像
    [SerializeField] Sprite m_ButtonONImage;            //ボタンが押されている画像

    const int m_ButtonChangeCountMax = 5;               //ボタンの表示変更の最大カウント
    int m_buttonChangeCount;                            //ボタンの表示変更のカウント
    bool m_isButton;                                    //表示するボタンの判定
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_buttonChangeCount = 0;
        m_isButton = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(PlayerState.State _state)
    {
        //ステートがRun状態の時実行
        if (_state == PlayerState.State.Run)
        {
            //ボタンの表示変更カウントが最大値を越えている時実行
            if (m_buttonChangeCount > m_ButtonChangeCountMax)
            {
                //表示するボタンの判定を反転
                m_isButton = !m_isButton;
                //ボタンの表示変更カウントをリセット
                m_buttonChangeCount = 0;
            }
            //ボタンの表示変更カウントを増やす。
            m_buttonChangeCount++;
        }
        //それ以外の時実行
        else
        {
            m_isButton = false;
        }
        //表示するボタンがtrueの時実行
        if (m_isButton)
        {
            m_RunButtonImage.GetComponent<Image>().sprite = m_ButtonONImage;
        }
        //表示するボタンがfalseの時実行
        else if(!m_isButton)
        {
            m_RunButtonImage.GetComponent<Image>().sprite = m_ButtonOFFImage;
        }
        //ステートがRunの時、ボタンを表示する
        m_RunButtonImage.SetActive(_state == PlayerState.State.Run);
    }
}
