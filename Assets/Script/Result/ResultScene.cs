using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// リザルトシーン制御
/// </summary>
public class ResultScene : MonoBehaviour
{
    bool m_isNext;      //次のシーン判定
    bool m_isTitle;     //タイトル判定
    bool m_isRetry;     //リトライ判定

    //UIのセレクト番号
    enum UISelectNumber
    {
        Title,
        Retry
    }
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_isNext = false;
        m_isRetry = false;
        m_isTitle = false;
    }
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue, bool _isEnter,bool _isFadeOutEnd)
    {
        //次のシーン判定がtrueかつ、フェードアウトが終了している時実行
        if (m_isNext && _isFadeOutEnd)
        {
            //タイトル判定がtrueの時実行
            if(m_isTitle)
            {
                SceneManager.LoadScene("Title");
            }
            //リトライ判定がtrueの時実行
            if(m_isRetry)
            {
                SceneManager.LoadScene("ResultToPlay");
            }
        }
        //それ以外の時実行
        else
        {
            //決定ボタンの判定がtrueの時実行
            if (_isEnter)
            {
                //UIのセレクト番号がTitleの時実行
                if (_selectValue == (int)UISelectNumber.Title)
                {
                    m_isNext = true;
                    m_isTitle = true;
                }
                //UIのセレクト番号がRetryの時実行
                if (_selectValue == (int)UISelectNumber.Retry)
                {
                    m_isNext = true;
                    m_isRetry = true;
                }
            }
        }
    }
    /// <summary>
    /// 次のシーン判定を取得
    /// </summary>
    public bool GetIsNext()
    {
        return m_isNext;
    }
}
