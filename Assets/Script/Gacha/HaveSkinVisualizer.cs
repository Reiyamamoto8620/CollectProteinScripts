using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スキンのUI表示制御クラス
/// </summary>
public class HaveSkinVisualizer : MonoBehaviour
{
    [SerializeField] SaveDataScriptableObject m_SaveData;   //セーブデータ
    [SerializeField] List<GameObject> m_SkinList;           //スキンのUIリスト
    [SerializeField] List<Sprite> m_SkinTexture;            //スキンUIテクスチャ
    [SerializeField] Sprite m_Unknown;                      //未所持のスキンUIテクスチャ

    List<bool> m_haveSkin;                                  //所持スキンの判定リスト

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_haveSkin = new List<bool>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        //所持スキンを取得
        SetHaveSkin();
        //スキンの数だけ回す
        for (int i = 0; i < m_SkinList.Count; i++)
        {
            //スキンを持っていない時実行
            if (!m_haveSkin[i])
            {
                //未所持のテクスチャを表示
                m_SkinList[i].GetComponent<Image>().sprite = m_Unknown;
            }
            //スキンを持っている時実行
            if (m_haveSkin[i])
            {
                //対応したスキンテクスチャを表示
                m_SkinList[i].GetComponent<Image>().sprite = m_SkinTexture[i];
            }
        }
    }

    /// <summary>
    /// セーブデータから所持しているスキンのデータをリストに保存
    /// </summary>
    void SetHaveSkin()
    {
        //リストの中身を空にする。
        m_haveSkin.Clear();

        //以下、それぞれの判定をリストに格納
        m_haveSkin.Add(m_SaveData.m_data.normal);
        m_haveSkin.Add(m_SaveData.m_data.gold);
        m_haveSkin.Add(m_SaveData.m_data.silver);
        m_haveSkin.Add(m_SaveData.m_data.black);
        m_haveSkin.Add(m_SaveData.m_data.red);
        m_haveSkin.Add(m_SaveData.m_data.blue);
        m_haveSkin.Add(m_SaveData.m_data.green);
        m_haveSkin.Add(m_SaveData.m_data.yellow);
        m_haveSkin.Add(m_SaveData.m_data.purple);
        m_haveSkin.Add(m_SaveData.m_data.orange);
        //ここまで
    }

    /// <summary>
    /// 所持スキンのリストを取得
    /// </summary>
    public List<bool>GetHaveSkin()
    {
        return m_haveSkin;
    }
}
