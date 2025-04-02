using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 得点アイテムのマネージャー
/// </summary>
public class PointItemManager : MonoBehaviour
{
    [SerializeField] GameObject m_PointItemGenerator;           //PointItemGeneratorオブジェクト
    [SerializeField] GameObject m_PointItemDestroyer;           //PointItemDestroyerオブジェクト
    [SerializeField] GameObject m_PointItemGeneratePos;         //PointItemGeneratePosオブジェクト
    [SerializeField] GameObject m_PointItemEffectGenerator;     //PointItemEffectGeneratorオブジェクト

    List<GameObject> m_createProtein = new List<GameObject>();  //生成したプロテインオブジェクトを格納するリスト
    List<GameObject> m_createBarbell = new List<GameObject>();  //生成したバーベルオブジェクトを格納するリスト

    PointItemGenerator m_pointItemGenerator;                    //PointItemGeneratorのクラス
    PointItemDestroyer m_pointItemDestroyer;                    //PointItemDestroyerのクラス
    PointItemGeneratePos m_pointItemGeneratePos;                //PointItemGeneratePosのクラス
    PointItemEffectGenerater m_pointItemEffectGenerator;        //PointItemEffectGeneratorのクラス

    float m_timeCount;              //ゲーム時間

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        m_pointItemGenerator 
            = m_PointItemGenerator.GetComponent<PointItemGenerator>();
        m_pointItemDestroyer 
            = m_PointItemDestroyer.GetComponent<PointItemDestroyer>();
        m_pointItemGeneratePos 
            = m_PointItemGeneratePos.GetComponent<PointItemGeneratePos>();
        m_pointItemEffectGenerator 
            = m_PointItemEffectGenerator.GetComponent<PointItemEffectGenerater>();
        m_timeCount = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //アイテムの生成
        m_pointItemGenerator.ManagedUpdate(m_timeCount,
            m_pointItemGeneratePos.GetGeneratePosMin(),
            m_pointItemGeneratePos.GetGeneratePosMax());

        //プロテインオブジェクトのリストを取得
        m_createProtein = m_pointItemGenerator.GetCreateProtein();
        //バーベルオブジェクトのリストを取得
        m_createBarbell = m_pointItemGenerator.GetCreateBarbell();

        //プロテインオブジェクトのアップデート
        ProteinUpdate();
        //バーベルオブジェクトのアップデート
        BarbellUpdate();
    }

    /// <summary>
    /// プロテインオブジェクトの更新
    /// </summary>
    void ProteinUpdate()
    {
        //プロテインオブジェクトの数だけ回す。
        for (int i = 0; i < m_createProtein.Count; i++)
        {
            //Actionのスクリプトをリストから入手
            PointItemAction action = m_createProtein[i].GetComponent<PointItemAction>();
            //Colliderのスクリプトをリストから入手
            PointItemCollider collider = m_createProtein[i].GetComponent<PointItemCollider>();
            //アクションの更新
            action.ManagedUpdate();
            
            //エフェクトジェネレーターの更新
            m_pointItemEffectGenerator.ManagedUpdate(collider.GetIsHitPlayer(),
                m_createProtein[i].transform, 
                m_createProtein[i].tag);
            //デストロイヤーの更新
            m_pointItemDestroyer.ManagedUpdate(collider.GetIsHit(), m_createProtein, i);
        }
    }

    /// <summary>
    /// バーベルオブジェクトの更新
    /// </summary>
    void BarbellUpdate()
    {
        //バーベルオブジェクトの数だけ回す
        for (int i = 0; i < m_createBarbell.Count; i++)
        {
            //Actionのスクリプトをリストから入手
            PointItemAction action = m_createBarbell[i].GetComponent<PointItemAction>();
            //Colliderのスクリプトをリストから入手
            PointItemCollider collider = m_createBarbell[i].GetComponent<PointItemCollider>();

            //アクションの更新
            action.ManagedUpdate();
            //エフェクトジェネレーターの更新
            m_pointItemEffectGenerator.ManagedUpdate(collider.GetIsHitPlayer(), 
                m_createBarbell[i].transform, 
                m_createBarbell[i].tag);
            //デストロイヤーの更新
            m_pointItemDestroyer.ManagedUpdate(collider.GetIsHit(), m_createBarbell, i);
        }
    }

    /// <summary>
    /// ゲーム時間の取得
    /// </summary>
    public void SetTimeCount(float _timeCount)
    {
        m_timeCount = _timeCount;
    }
}
