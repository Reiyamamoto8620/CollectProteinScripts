using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲームシステムクラス
/// </summary>
public class GameSistem : MonoBehaviour
{
    [SerializeField] int m_GameTimeMax = 60;            //ゲームのプレイ時間の最大
    const int m_IncreaseDifficultTime = 5;              //ゲームの難易度が上昇する時間

    [SerializeField] GameObject m_GameTimeText;         //スコアのテキストオブジェクト

    float m_timeCount;                  //ゲームのプレイ時間

    bool m_isSetTime;                   //ゲームのプレイ時間をPointItemManagerに渡したかの判定

    TextMeshProUGUI m_gameTimeText;     //ゲーム内時間の数字表記用テキスト


    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        //ゲーム時間を初期化
        m_timeCount = m_GameTimeMax * FPSFixed.FPS;

        m_gameTimeText = m_GameTimeText.GetComponent<TextMeshProUGUI>();

        m_isSetTime = true;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        m_gameTimeText.text = ((int)m_timeCount/FPSFixed.FPS).ToString();
        //ゲームの終了判定
        if (m_timeCount / FPSFixed.FPS <= 0)
        {
            Debug.Log("End");
            SceneManager.LoadScene("PlayToResult");
        }
        //ゲーム時間が5秒進むごとに難易度を上げる、
        //５秒ごとに判定を取って、PointItemManagerに渡す。
        if((m_timeCount / FPSFixed.FPS) % m_IncreaseDifficultTime == 0)
        {
            //まだ、PointItemManagerに時間を渡していない場合、処理を実行
            if (m_isSetTime)
            {
                m_isSetTime = false;
            }
        }
        //それ以外の時実行
        else
        {
            m_isSetTime = true;
        }
        //ゲームのプレイ時間を１フレーム減らす
        if (m_timeCount >= 0)
        {
            m_timeCount--;
        }
    }
    /// <summary>
    /// Timeを取得
    /// </summary>
    public float GetTime()
    {
        return m_timeCount / FPSFixed.FPS;
    }
}
