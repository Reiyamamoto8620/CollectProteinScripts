using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ガチャのUI制御クラス
/// </summary>
public class GachaUI : MonoBehaviour
{
    [SerializeField] List<GameObject> m_SkinUIObject;       //スキンのUIオブジェクト
    [SerializeField] List<GameObject> m_MenuUIObject;       //メニューのUIオブジェクト
    [SerializeField] int m_RowValue;                        //横列
    [SerializeField] int m_ColumnValue;                     //縦列

    const int m_SelectValueShift = 1;                       //UIオブジェクトのカウントがセレクト番号と1ズレるため、
                                                            //その調整用

    const int m_SelectValueMin = 0;                         //セレクトナンバーの最低値

    int m_selectValue;                                      //UIのセレクト番号
    bool m_isMenu;                                          //メニューの判定
    bool m_isSkin;                                          //スキンの判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_selectValue = 0;
        m_isMenu = true;
        m_isSkin = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(UIInput.StickInput _stickInput)
    {
        if (m_isSkin)
        {
            SkinUI(_stickInput);
        }
        else if (m_isMenu)
        {
            MenuUI(_stickInput);
        }
    }
    /// <summary>
    /// UIのセレクト番号を取得
    /// </summary>
    public int GetSelectValue()
    {
        return m_selectValue;
    }
    /// <summary>
    /// スキンUIの制御
    /// </summary>
    void SkinUI(UIInput.StickInput _stickInput)
    {
        //m_selectValueが0以下のとき実行
        if (m_selectValue <= m_SelectValueMin - m_SelectValueShift)
        {
            //m_selectValueが0より小さいとき実行
            if (m_selectValue < m_SelectValueMin - m_SelectValueShift)
            {
                //列を下にずらす
                m_selectValue += m_RowValue * m_ColumnValue;
            }
            //それ以外の時実行
            else
            {
                //反対側にずらす。
                m_selectValue = m_SkinUIObject.Count - m_SelectValueShift;
            }
        }
        //m_selectValueがスキンのUIオブジェクトの数以上のとき実行
        if (m_selectValue >= m_SkinUIObject.Count)
        {
            //m_selectValueがスキンのUIオブジェクトの数より大きいとき実行
            if (m_selectValue > m_SkinUIObject.Count)
            {
                //列を上にずらす
                m_selectValue -= m_RowValue * m_ColumnValue;
            }
            //それ以外の時実行
            else
            {
                //反対側にずらす
                m_selectValue = 0;
            }
        }

        //スティックの右入力
        if (_stickInput.m_isRight)
        {
            //セレクト番号がスキンUIの右端の場合実行
            if (m_selectValue == m_RowValue- m_SelectValueShift || 
                m_selectValue == (m_RowValue * m_ColumnValue)- m_SelectValueShift)
            {
                //制御するUIを切り替える
                m_isMenu = true;
                m_isSkin = false;
                //セレクト番号をリセット
                m_selectValue = 0;
            }
            //それ以外の時実行
            else
            {
                //選択UIを右に移動
                m_selectValue++;
            }
        }
        //スティックの左入力
        if (_stickInput.m_isLeft)
        {
            //セレクト番号がスキンUIの左端の場合実行
            if (m_selectValue == 0 || m_selectValue == m_RowValue)
            {
                //制御するUIを切り替える
                m_isMenu = true;
                m_isSkin = false;
                //セレクト番号をリセット
                m_selectValue = 0;
            }
            //それ以外の時実行
            else
            {
                //選択UIを左に移動
                m_selectValue--;
            }
        }
        //スティックの上入力
        if (_stickInput.m_isUp)
        {
            //選択UIを上に移動
            m_selectValue -= m_RowValue;
        }
        //スティックの下入力
        if (_stickInput.m_isDown)
        {
            //選択UIを下に移動
            m_selectValue += m_RowValue;
        }
    }

    /// <summary>
    /// メニューUIの制御
    /// </summary>
    void MenuUI(UIInput.StickInput _stickInput)
    {
        //セレクト番号が0以下の場合実行
        if (m_selectValue < 0)
        {
            //セレクト番号にメニューUIの最大数を代入
            m_selectValue = m_MenuUIObject.Count - m_SelectValueShift;
        }
        //セレクト番号がメニューUIの数より大きい場合実行
        if (m_selectValue > m_MenuUIObject.Count - m_SelectValueShift)
        {
            //セレクト番号に0を代入
            m_selectValue = 0;
        }
        //スティックの右入力
        if (_stickInput.m_isRight)
        {
            //制御するUIを切り替える
            m_isMenu = false;
            m_isSkin = true;
            //セレクト番号をリセット
            m_selectValue = 0;
        }
        //スティックの左入力
        if(_stickInput.m_isLeft)
        {
            //制御するUIを切り替える
            m_isMenu = false;
            m_isSkin = true;
            //セレクト番号をリセット
            m_selectValue = m_RowValue- m_SelectValueShift;
        }
        //スティックの上入力
        if (_stickInput.m_isUp)
        {
            //上に移動
            m_selectValue--;
        }
        //スティックの下入力
        if (_stickInput.m_isDown)
        {
            //下に移動
            m_selectValue++;
        }
    }

    /// <summary>
    /// メニューUIの制御フラグを取得
    /// </summary>
    public bool GetIsMenu()
    {
        return m_isMenu;
    }

    /// <summary>
    /// スキンUIの制御フラグを取得
    /// </summary>
    public bool GetIsSkin()
    {
        return m_isSkin;
    }
}