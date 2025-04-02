using UnityEngine;

/// <summary>
/// ゲームシステムマネージャークラス
/// </summary>
public class GameSistemManager : MonoBehaviour
{
    [SerializeField] GameObject m_GameSistem;           //ゲームシステムのオブジェクト
    [SerializeField] GameObject m_PointItemManager;     //ポイントアイテムマネージャーのオブジェクト
    [SerializeField] GameObject m_Timer;                //タイマーオブジェクト

    GameSistem m_gameSistem;                            //ゲームシステムクラス
    PointItemManager m_pointItemManager;                //ポイントアイテムマネージャークラス
    Timer m_timer;                                      //タイマークラス
    
    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Start()
    {
        m_gameSistem = m_GameSistem.GetComponent<GameSistem>();
        m_pointItemManager = m_PointItemManager.GetComponent<PointItemManager>();
        m_timer = m_Timer.GetComponent<Timer>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        //ゲームシステムの更新
        m_gameSistem.ManagedUpdate();
        //ポイントアイテムマネージャーの更新
        m_pointItemManager.SetTimeCount(m_gameSistem.GetTime());
        //タイマーの更新
        m_timer.ManagedUpdate(m_gameSistem.GetTime());
    }
}
