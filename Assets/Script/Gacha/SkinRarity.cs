using UnityEngine;

/// <summary>
/// スキンのレアリティ管理クラス
/// </summary>
public class SkinRarity : MonoBehaviour
{
    [SerializeField] SaveDataScriptableObject m_SaveData;       //セーブデータ
    [SerializeField] GameObject m_CenterRarityStar;             //真ん中の星
    [SerializeField] GameObject m_LeftRarityStar;               //左の星
    [SerializeField] GameObject m_RightRarityStar;              //右の星

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //現在のスキンがゴールドの時実行
        if (m_SaveData.m_data.nowSkin == (int)SkinIndex.Gold)
        {
            //星を3つ表示
            m_CenterRarityStar.SetActive(true);
            m_LeftRarityStar.SetActive(true);
            m_RightRarityStar.SetActive(true);
        }
        //現在のスキンがシルバーの時実行
        else if (m_SaveData.m_data.nowSkin == (int)SkinIndex.Silver)
        {
            //星を2つ表示
            m_CenterRarityStar.SetActive(false);
            m_LeftRarityStar.SetActive(true);
            m_RightRarityStar.SetActive(true);
        }
        //それ以外のスキンの場合実行
        else
        {
            m_CenterRarityStar.SetActive(true);
            m_LeftRarityStar.SetActive(false);
            m_RightRarityStar.SetActive(false);
        }
    }
}
