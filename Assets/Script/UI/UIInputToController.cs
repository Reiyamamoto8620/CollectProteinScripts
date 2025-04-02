using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI入力をコントローラーに変換するクラス
/// </summary>
public class UIInputToController : MonoBehaviour
{
    [SerializeField] List<GameObject> m_UIObject;       //UIオブジェクト
    int m_selectValue;                                  //セレクト番号
    const int m_SelectValueShift = 1;                   //セレクト番号調整用

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_selectValue = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(UIInput.StickInput _stickInput)
    {
        //上入力判定がtrueの時実行
        if (_stickInput.m_isUp)
        {
            m_selectValue--;
        }
        //下入力判定がtrueの時実行
        if (_stickInput.m_isDown)
        {
            m_selectValue++;
        }
        //セレクト番号が0より小さい時実行
        if (m_selectValue < 0)
        {
            m_selectValue = m_UIObject.Count - m_SelectValueShift;
        }
        //セレクト番号がUIオブジェクトの数より大きい場合実行
        if (m_selectValue > m_UIObject.Count - m_SelectValueShift)
        {
            m_selectValue = 0;
        }
    }
    /// <summary>
    /// セレクト番号を取得
    /// </summary>
    /// <returns></returns>
    public int GetSelectValue()
    {
        return m_selectValue;
    }
}
