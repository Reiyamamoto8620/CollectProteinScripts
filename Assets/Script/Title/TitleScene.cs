using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    bool m_isNext;      //次のシーン判定
    bool m_isGacha;     //ガチャ判定
    bool m_isEnd;       //エンド判定

    //UIのセレクト番号
    enum UISelectNumber
    {
        Start,
        Gacha,
        End
    }

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_isNext = false;
        m_isGacha = false;
        m_isEnd = false;
    }
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue, bool _isEnter, bool _isFadeOutEnd)
    {
        //次のシーン判定がtrueでフェードアウトが終了している時実行
        if (m_isNext && _isFadeOutEnd)
        {
            //ガチャ判定がtrueの時実行
            if (m_isGacha)
            {
                SceneManager.LoadScene("Gacha");
            }
            //エンド判定がtrueの時実行
            if (m_isEnd)
            {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
            }
        }
        //それ以外の時実行
        else
        {
            //決定ボタンが押された時実行
            if (_isEnter)
            {
                //セレクト番号がStartの時実行
                if (_selectValue == (int)UISelectNumber.Start)
                {
                    SceneManager.LoadScene("TitleToPlay");
                }
                //セレクト番号がGachaの時実行
                if (_selectValue == (int)UISelectNumber.Gacha)
                {
                    m_isGacha = true;
                    m_isNext = true;
                }
                //セレクト番号がEndの時実行
                if (_selectValue == (int)UISelectNumber.End)
                {
                    m_isEnd = true;
                    m_isNext = true;
                }
            }
        }
    }

    /// <summary>
    /// 次のシーン判定を取得
    /// </summary>
    /// <returns></returns>
    public bool GetIsNext()
    {
        return m_isNext;
    }
}
