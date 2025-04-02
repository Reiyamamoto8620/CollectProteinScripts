using UnityEngine;

/// <summary>
/// プレイヤーの当たり判定
/// </summary>
public class PlayerCollider : MonoBehaviour
{
    const float m_SquatTimeMax = 3f;          //スクワット状態の継続時間(秒)
    const int m_WaitHitProteinFrame = 1;      //プロテインのHit判定をリセットする待機フレーム

    bool m_isHitBarbell;                      //バーベルに当たったかの判定
    bool m_isHitProtein;                      //プロテインに当たったかの判定

    float m_waitSquatTimeCount;               //スクワット状態の待ち時間の計測
    float m_waitHitProteinTimeCount;          //プロテインのHit判定をリセットする時間カウント

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        m_isHitBarbell = false;
        m_isHitProtein = false;
        m_waitSquatTimeCount = 0;               
        m_waitHitProteinTimeCount = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        //スクワットの待機判定
        if(m_isHitBarbell)
        {
            //スクワットの獲得待機時間をカウント
            m_waitSquatTimeCount++;
            //スクワットの獲得待機時間カウントがスクワットの継続時間を越えた時実行
            if(m_waitSquatTimeCount/FPSFixed.FPS >= m_SquatTimeMax)
            {
                m_isHitBarbell=false;
            }
        }
        //プロテインのHit判定の待機判定
        if(m_isHitProtein)
        {
            //プロテインの獲得待機時間をカウント
            m_waitHitProteinTimeCount++;
            //プロテインの獲得待機時間カウントがプロテインの継続時間を越えた時実行
            if (m_waitHitProteinTimeCount >=  m_WaitHitProteinFrame)
            {
                m_isHitProtein = false;
            }
        }
    }

    /// <summary>
    /// 当たり判定
    /// </summary>
    void OnCollisionEnter(Collision _collision)
    {
        //バーベルの当たり判定
        HitBarbell(_collision);
        //プロテインの当たり判定
        HitProtein(_collision);
    }

    /// <summary>
    /// バーベルとの当たり判定
    /// </summary>
    void HitBarbell(Collision _collision)
    {
        //バーベルにあたった時に処理をする
        if (_collision.gameObject.tag == "Barbell")
        {
            //Hit判定をTRUE
            m_isHitBarbell = true;
            //待機時間のカウントをリセット
            m_waitSquatTimeCount = 0;
        }
    }

    /// <summary>
    /// プロテインとの当たり判定
    /// </summary>
    void HitProtein(Collision _collision)
    {
        //プロテインに当たったときに処理をする
        if (_collision.gameObject.tag == "Protein")
        {
            //プロテインのHit判定をTRUE
            m_isHitProtein = true;
            //待機時間のカウントをリセット
            m_waitHitProteinTimeCount = 0;
        }
    }

    /// <summary>
    /// バーベルとの当たり判定を取得
    /// </summary>
    public bool GetIsHitBarbell()
    {
        return m_isHitBarbell;
    }

    /// <summary>
    /// プロテインとの当たり判定を取得
    /// </summary>
    public bool GetIsHitProtein()
    {
        return m_isHitProtein;
    }
}