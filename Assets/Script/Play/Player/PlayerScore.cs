using System.Drawing;
using TMPro;
using UnityEngine;

/// <summary>
/// プレイヤーのスコア
/// </summary>
public class PlayerScore : MonoBehaviour
{
    int m_score;                                  //現在のスコア
    bool m_isScoreChange;                         //スコアが加算されているかの判定

    [SerializeField] GameObject m_ScoreText;      //スコアのテキストオブジェクト
    TextMeshProUGUI m_scoreText;                  //テキストクラス

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        m_score = 0;
        m_scoreText = m_ScoreText.GetComponent<TextMeshProUGUI>();
        m_isScoreChange = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool _isHitProtein)
    {
        //スコアを表示
        m_scoreText.text = "<size=50>x</size> <size=80>" +m_score+ "</size>";

        //プロテインに当たっていないときに処理を実行
        if(!_isHitProtein)
        {
            //スコアの加算済み判定をFalseにする
            m_isScoreChange = false;
        }

        //isScoreChangeがTRUEの場合下の処理を飛ばす。
        if (m_isScoreChange) return;

        //プロテインに当たっている場合
        if (_isHitProtein)
        {
            //スコアを[1]加算
            m_score++;
            //スコアの加算済み判定をTRUEにする
            m_isScoreChange=true;
        }
    }

    /// <summary>
    /// スコアを獲得
    /// </summary>
    public int GetScore()
    {
        return m_score;
    }
}
