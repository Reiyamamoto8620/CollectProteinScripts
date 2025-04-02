using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ログインシーンクラス
/// </summary>
public class LoginScene : MonoBehaviour
{
    bool m_isInputName;     //名前の入力判定
    
    bool m_isNext;          //シーン移行判定

    /// <summary>
    /// UIのセレクト番号
    /// </summary>
    enum UISelectNumber
    {
        InputName,
        Title
    }

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_isInputName = false;
        m_isNext = false;
    }
    
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue,bool _isEnter,bool _isFadeOutEnd)
    {
        //シーン移行判定がtrueの時実行
        if (m_isNext)
        {
            //フェードアウトが終了している時実行
            if (_isFadeOutEnd)
            {
                //タイトルへ
                SceneManager.LoadScene("Title");
            }
        }
        //それ以外の時実行
        else
        {
            //決定ボタンが押された時実行
            if (_isEnter)
            {
                //セレクト番号がInputNameで、名前の入力判定がfalseの時実行
                if (_selectValue == (int)UISelectNumber.InputName && !m_isInputName)
                {
                    //名前の入力判定をtrue
                    m_isInputName = true;
                }
                //セレクト番号がInputNameで、名前の入力判定がtrueの時実行
                else if (_selectValue == (int)UISelectNumber.InputName && m_isInputName)
                {
                    //名前の入力判定をfalse
                    m_isInputName = false;
                }
                //セレクト番号がTitleの時実行
                if (_selectValue == (int)UISelectNumber.Title)
                {
                    //シーンの移行判定をtrue
                    m_isNext = true;
                }
            }
        }
    }
    /// <summary>
    /// 名前の入力判定を取得
    /// </summary>
    public bool GetIsInputName()
    {
        return m_isInputName;
    }

    /// <summary>
    /// シーンの移行判定を取得
    /// </summary>
    public bool GetIsNext()
    {
        return m_isNext;
    }
}
