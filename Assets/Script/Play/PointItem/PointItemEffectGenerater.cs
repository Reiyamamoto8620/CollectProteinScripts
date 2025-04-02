using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポイントアイテムのエフェクト生成クラス
/// </summary>
public class PointItemEffectGenerater : MonoBehaviour
{
    [SerializeField] GameObject m_ProteinHitEffect;         //プロテインのヒットエフェクト
    [SerializeField] GameObject m_BarbellHitEffect;         //バーベルのヒットエフェクト
    [SerializeField] Transform m_ParentCreateEffect;        //生成したエフェクトを格納するオブジェクト

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool _isHitPlayer,Transform _pointItemTransform,string _tag)
    {
        //モデルがプレイヤーにヒットしている場合実行
        if (_isHitPlayer)
        {
            //モデルがプロテインの場合実行
            if (_tag == "Protein")
            {
                Instantiate(m_ProteinHitEffect, _pointItemTransform.position,
                        Quaternion.identity, m_ParentCreateEffect.transform);
            }
            //モデルがバーベルの場合実行
            if(_tag == "Barbell")
            {
                Instantiate(m_BarbellHitEffect, _pointItemTransform.position,
                        Quaternion.identity, m_ParentCreateEffect.transform);
            }
        }
    }
}
