using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ガチャリザルトクラス
/// </summary>
public class GachaResult : MonoBehaviour
{
    [SerializeField] SaveDataScriptableObject m_SaveData;   //セーブデータ
    [SerializeField] GameObject m_GachaResultObject;        //ガチャリザルトオブジェクト
    [SerializeField] GameObject m_GetSkin;                  //獲得したスキン
    [SerializeField] GameObject m_CenterRarityStar;         //真ん中の星
    [SerializeField] GameObject m_LeftRarityStar;           //左の星
    [SerializeField] GameObject m_RightRarityStar;          //右の星
    [SerializeField] List<Sprite> m_SkinList;               //スキンのテクスチャリスト

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool _isGetGachaResult)
    {
        //ガチャリザルトの表示判定がtrueの時実行
        if(_isGetGachaResult)
        {
            //獲得したスキンをオブジェクトに格納
            m_GetSkin.GetComponent<Image>().sprite = m_SkinList[m_SaveData.m_data.nowSkin];
            //獲得したスキンがゴールドの時実行
            if (m_SaveData.m_data.nowSkin == (int)SkinIndex.Gold)
            {
                //星を3つ表示
                m_CenterRarityStar.SetActive(true);
                m_LeftRarityStar.SetActive(true);
                m_RightRarityStar.SetActive(true);
            }
            //獲得したスキンがシルバーの時実行
            else if (m_SaveData.m_data.nowSkin == (int)SkinIndex.Silver)
            {
                //星を2つ表示
                m_CenterRarityStar.SetActive(false);
                m_LeftRarityStar.SetActive(true);
                m_RightRarityStar.SetActive(true);
            }
            //それ以外の時実行
            else
            {
                //星を1つ表示
                m_CenterRarityStar.SetActive(true);
                m_LeftRarityStar.SetActive(false);
                m_RightRarityStar.SetActive(false);
            }
            //ガチャリザルトオブジェクトを有効化
            m_GachaResultObject.SetActive(true);
        }
        //それ以外の時実行
        else
        {
            //ガチャリザルトオブジェクトを無効化
            m_GachaResultObject.SetActive(false);
        }
    }
}