using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 現在のスキンをゲームに反映するクラス
/// </summary>
public class SkinApply : MonoBehaviour
{
    [SerializeField] SaveDataScriptableObject m_SaveData;   //セーブデータ

    [SerializeField] GameObject m_BodyObject;               //マテリアルを変更するモデルのボディ
    [SerializeField] GameObject m_PantsObject;              //マテリアルを変更sルモデルのパンツ
    [SerializeField] BodyMaterials m_BodyMaterial;          //ボディの変更マテリアルデータベース
    [SerializeField] HeadMaterials m_HeadMaterial;          //ヘッドの変更マテリアルデータベース
    [SerializeField] PantsMaterials m_PantsMaterial;        //パンツの変更マテリアルデータベース

    Material[] m_body;                                      //変更するモデルのボディマテリアル
    Material[] m_pants;                                     //変更するモデルのパンツマテリアル
    const int m_BodyMaterialIndex = 0;                      //ボディマテリアルのインデックス
    const int m_HeadMaterialIndex = 1;                      //ヘッドマテリアルのインデックス
    const int m_PantsMaterialIndex = 0;                     //パンツマテリアルのインデックス

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_body = m_BodyObject.GetComponent<SkinnedMeshRenderer>().materials;
        m_pants = m_PantsObject.GetComponent<SkinnedMeshRenderer>().materials;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //適用するボディマテリアルを格納
        m_body[m_BodyMaterialIndex] = m_BodyMaterial.m_BodyMaterial[m_SaveData.m_data.nowSkin];
        //適用するヘッドマテリアルを格納
        m_body[m_HeadMaterialIndex] = m_HeadMaterial.m_HeadMaterial[m_SaveData.m_data.nowSkin];
        //適用するパンツマテリアルを格納
        m_pants[m_PantsMaterialIndex] = m_PantsMaterial.m_PantsMaterial[m_SaveData.m_data.nowSkin];

        //ボディマテリアルを適用
        m_BodyObject.GetComponent<SkinnedMeshRenderer>().materials = m_body;
        //パンツマテリアルを適用
        m_PantsObject.GetComponent<SkinnedMeshRenderer>().materials = m_pants;
    }
}
