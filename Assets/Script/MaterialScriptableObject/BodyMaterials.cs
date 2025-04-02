using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボディのマテリアルを管理するデータベース
/// </summary>
[CreateAssetMenu(fileName = "BodyMaterialsScriptableObject",
    menuName = "BodyMaterialsScriptableObject")]
public class BodyMaterials : ScriptableObject
{
    public List<Material> m_BodyMaterial;         //ボディの変更マテリアルデータベース
}
