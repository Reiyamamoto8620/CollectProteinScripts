using TMPro;
using UnityEngine;

/// <summary>
/// リザルトのスコア制御
/// </summary>
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_NowScoreText;    //今回のスコア表示テキスト
    [SerializeField] TextMeshProUGUI m_TotalScoreText;  //トータルスコアの表示テキスト

    [SerializeField]
    PlaySceneDataScriptableObject m_playSceneData;      //Playシーンのスクリプタブルオブジェクト
    [SerializeField]
    SaveDataScriptableObject m_saveData;                //ネット保存用のセーブデータオブジェクト

    TextMeshProUGUI m_nowScoreText;                     //テキストクラス
    TextMeshProUGUI m_totalScoreText;                   //テキストクラス
    bool m_isSaveProtein;                               //プロテインのセーブ判定
    bool m_isSaveHighScore;                             //ハイスコアのセーブ判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_nowScoreText = m_NowScoreText.GetComponent<TextMeshProUGUI>();
        m_totalScoreText = m_TotalScoreText.GetComponent<TextMeshProUGUI>();
        m_isSaveProtein = false;
        m_isSaveHighScore = false;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        //スコアを表示
        m_nowScoreText.text = "<size=100>x</size> <size=150>"
            + m_playSceneData.m_score.ToString() + "</size>";
        m_totalScoreText.text = "<size=100>x</size> <size=150>"
            + m_saveData.m_data.protein + "</size>";
        //プロテインをセーブ
        SetSaveProtein();
        //ハイスコアをセーブ
        SaveHighScore();
    }

    /// <summary>
    /// プロテインをセーブ
    /// </summary>
    void SetSaveProtein()
    {
        if (!m_isSaveProtein)
        {
            //所持プロテインに今回のスコアを足して、ネットのセーブデータ用に格納
            m_saveData.m_data.protein += m_playSceneData.m_score;
            Debug.Log("TotalProtein :" + m_saveData.m_data.protein);
            m_isSaveProtein = true;
        }
    }

    /// <summary>
    /// ハイスコアをセーブ
    /// </summary>
    void SaveHighScore()
    {
        //セーブされてるハイスコアより今回のスコアが大きい場合は格納
        if (m_saveData.m_data.highScore < m_playSceneData.m_score && !m_isSaveHighScore)
        {
            m_saveData.m_data.highScore = m_playSceneData.m_score;
            m_isSaveHighScore = true;
        }
    }
}
