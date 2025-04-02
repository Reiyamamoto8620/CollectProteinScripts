using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ポイントアイテムエフェクト制御クラス
/// </summary>
public class PointItemEffect : MonoBehaviour
{
    const int m_DeleteCountMax = 3;       //エフェクトを削除するまでの時間
    float m_deleteCount;                  //エフェクトを削除するまでのカウント
    
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_deleteCount = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        m_deleteCount++;
        if (m_deleteCount == m_DeleteCountMax * FPSFixed.FPS)
        {
            Object.Destroy(this.GameObject());
        }
    }
}
