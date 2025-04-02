using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// アイテムの当たり判定
/// </summary>
public class PointItemCollider : MonoBehaviour
{
    bool m_isHit;         //オブジェクトにヒットしたかの判定
    bool m_isHitPlayer;   //プレイヤーとの衝突判定
    
    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        m_isHit = false;
        m_isHitPlayer = false;
    }

    /// <summary>
    /// isHitを取得
    /// </summary>
    public bool GetIsHit()
    {
        return m_isHit;
    }
    /// <summary>
    /// isHitPlayerを取得
    /// </summary>
    public bool GetIsHitPlayer()
    {
        return m_isHitPlayer;
    }

    /// <summary>
    /// オブジェクトに当たった時の判定
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        m_isHit = true;
        //当たったのがPlayerだった時実行
        if(collision.gameObject.tag == "Player1" && 
            SceneManager.GetActiveScene().name == "Play")
        {
            m_isHitPlayer = true;
        }
    }
}
