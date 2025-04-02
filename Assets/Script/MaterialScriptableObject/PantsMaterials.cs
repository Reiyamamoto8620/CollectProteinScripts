using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// パンツのマテリアルを管理するデータベース
/// </summary>
[CreateAssetMenu(fileName = "PantsMaterialsScriptableObject",
    menuName = "PantsMaterialsScriptableObject")]
public class PantsMaterials : ScriptableObject
{
    public List<Material> m_PantsMaterial;        //パンツの変更マテリアルデータベース
}