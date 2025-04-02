using TMPro;
using UnityEngine;

/// <summary>
/// 所持プロテイン表示クラス
/// </summary>
public class HaveProtein : MonoBehaviour
{
    [SerializeField] 
    SaveDataScriptableObject m_SaveData;                       //セーブデータ
    [SerializeField] GameObject m_ProteinValueText;            //所持プロテイン表示用Textオブジェクト
    TextMeshProUGUI m_proteinValueText;                        //所持プロテイン表示用Text
    
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_proteinValueText = m_ProteinValueText.GetComponent<TextMeshProUGUI>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        m_proteinValueText.text = "<size=80>x</size> <size=120>"
            +m_SaveData.m_data.protein+"</size>";
    }
}
