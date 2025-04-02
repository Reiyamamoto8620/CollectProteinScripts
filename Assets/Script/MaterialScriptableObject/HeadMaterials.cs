using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ヘッドのマテリアルを管理するデータベース
/// </summary>
[CreateAssetMenu(fileName = "HeadMaterialsScriptableObject",
    menuName = "HeadMaterialsScriptableObject")]
public class HeadMaterials : ScriptableObject
{
    public List<Material> m_HeadMaterial;        //パンツの変更マテリアルデータベース
}
