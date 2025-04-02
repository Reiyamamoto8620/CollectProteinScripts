using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI制御クラス
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] List<GameObject> m_UIObject;               //UIオブジェクトリスト
    List<Vector3> m_uiScaleBase;                                //元のUIのサイズリスト

    readonly Vector3 m_SelectUIScale =                          //選択されたUIのサイズ
        new Vector3(0.2f, 0.2f, 0.2f);                          
    const float SelectUIAlpha = 1f;                             //選択されたUIのアルファ値
    const float NotSelectUIAlpha = 0.5f;                        //選択されていないUIのアルファ値

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_uiScaleBase = new List<Vector3>();
        for (int i = 0; i < m_UIObject.Count; i++)
        {
            m_uiScaleBase.Add(m_UIObject[i].GetComponent<RectTransform>().localScale);
        }
    }
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue)
    {
        SetUIScale(_selectValue);
    }
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(int _selectValue,bool _isActive)
    {
        SetUIScale(_selectValue,_isActive);
    }

    /// <summary>
    /// UIのサイズを調整
    /// </summary>
    void SetUIScale(int _selectUIValue)
    {
        for (int i = 0; i < m_UIObject.Count; i++)
        {
            Color color = m_UIObject[i].GetComponent<Image>().color;
            Vector3 uiScale = m_uiScaleBase[i];

            //セレクト番号とforの回転数が同じ時に実行
            if (_selectUIValue == i)
            {
                color.a = SelectUIAlpha;
                uiScale += m_SelectUIScale;
            }
            //それ以外の時実行
            else
            {
                color.a = NotSelectUIAlpha;
            }
            //上で設定した値を代入
            m_UIObject[i].GetComponent<Image>().color = color;
            m_UIObject[i].GetComponent<Transform>().localScale = uiScale;
        }
    }

    /// <summary>
    /// UIのサイズを調整
    /// </summary>
    void SetUIScale(int _selectUIValue,bool _isActive)
    {
        for (int i = 0; i < m_UIObject.Count; i++)
        {
            Color color = m_UIObject[i].GetComponent<Image>().color;
            Vector3 uiScale = m_uiScaleBase[i];

            //セレクト番号とforの回転数が同じ、
            //UIがアクティブ状態の時実行
            if (_selectUIValue == i && _isActive)
            {
                color.a = SelectUIAlpha;
                uiScale += m_SelectUIScale;
            }
            //それ以外の時実行
            else
            {
                color.a = NotSelectUIAlpha;
            }
            //上で設定した値を代入
            m_UIObject[i].GetComponent<Image>().color = color;
            m_UIObject[i].GetComponent<Transform>().localScale = uiScale;
        }
    }
}
