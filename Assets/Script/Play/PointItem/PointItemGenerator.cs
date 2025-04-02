using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

/// <summary>
/// アイテムを生成
/// </summary>
public class PointItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_ProteinModel;             //プロテインのモデル
    [SerializeField] GameObject m_BarbellModel;             //バーベルのモデル
    [SerializeField] GameObject m_ParentCreatePointItem;    //アイテムを格納するオブジェクト

    const int m_ItemGeneratePosY = 10;                      //アイテム生成時のY座標
    const int m_GeneratePlaceValue = 12;                    //生成地点の数
    const int m_GenerateItemProbability = 5;                //生成アイテムの生成率

    //アイテムの生成間隔
    const float m_FirstGenerateInterval = 4f;           //1段階目の生成間隔
    const float m_SecondGenerateInterval = 3.2f;        //2段階目の生成間隔
    const float m_ThirdGenerateInterval = 2.56f;        //3段階目の生成間隔
    const float m_FouthGenerateInterval = 2.05f;        //4段階目の生成間隔
    const float m_FifthGenerateInterval = 1.64f;        //5段階目の生成間隔
    const float m_SixthGenerateInterval = 1.31f;        //6段階目の生成間隔
    const float m_SeventhGenerateInterval = 1.05f;      //7段階目の生成間隔
    const float m_EiguthGenerateInterval = 0.84f;       //8段階目の生成間隔
    const float m_NinthGenerateInterval = 0.67f;        //9段階目の生成間隔
    const float m_TenthGenerateInterval = 0.54f;        //10段階目の生成間隔
    const float m_EleventhGenerateInterval = 0.43f;     //11段階目の生成間隔
    const float m_TitleGenerateItemInterval = 0.2f;     //タイトル画面での生成間隔

    //難易度が上昇するゲーム時間
    const int m_FirstIncreaseDifficultyTime = 60;       //難易度が1段階目になる時間
    const int m_SecondIncreaseDifficultyTime = 55;      //難易度が2段階目になる時間
    const int m_ThirdIncreaseDifficultyTime = 50;       //難易度が3段階目になる時間
    const int m_FouthIncreaseDifficultyTime = 45;       //難易度が4段階目になる時間
    const int m_FifthIncreaseDifficultyTime = 40;       //難易度が5段階目になる時間
    const int m_SixthIncreaseDifficultyTime = 35;       //難易度が6段階目になる時間
    const int m_SeventhIncreaseDifficultyTime = 30;     //難易度が7段階目になる時間
    const int m_EiguthIncreaseDifficultyTime = 25;      //難易度が8段階目になる時間
    const int m_NinthIncreaseDifficultyTime = 20;       //難易度が9段階目になる時間
    const int m_TenthIncreaseDifficultyTime = 15;       //難易度が10段階目になる時間
    const int m_EleventhIncreaseDifficultyTime = 10;    //難易度が11段階目になる時間
    const int m_TwelfthIncreaseDifficultyTime = 5;      //生成を終了する時間

    List<GameObject> m_createProtein = new List<GameObject>();      //生成したプロテインのリスト
    List<GameObject> m_createBarbell = new List<GameObject>();      //生成したバーベルのリスト

    bool m_isGenerate;                    //生成する判定
    bool m_isFinishGenerate;              //生成終了判定
    float m_waitGenerateCount;              //生成間隔の計測
    float m_generateInterval;     //生成の間隔

    /// <summary>
    /// 起動時更新
    /// </summary>
    void Awake()
    {
        m_isGenerate = true;
        m_isFinishGenerate = false;
        m_waitGenerateCount = 0;
        m_generateInterval = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(float _nowTime,
        List<Vector2> _generatePosMin,
        List<Vector2> _generatePosMax)
    {
        //ゲームの残り時間でアイテムそれぞれの最大値を決めて、場所をランダムで決める。
        //時間による最大値にもパターンを数個用意して、そこからランダムで選ぶ
        //アイテムが落ちる時間は幅を決めて、ランダムにする。
        if (m_isGenerate)
        {
            float x = 0f;
            float z = 0f;
            Vector2 min = Vector2.zero;     //生成座標の最小
            Vector2 max = Vector2.zero;     //生成座標の最大
            int generatePlace;              //生成場所

            //生成判定をリセット
            m_isGenerate = false;
            //生成間隔の計測値をリセット
            m_waitGenerateCount = 0;
            //生成場所をランダムで決定
            generatePlace = UnityEngine.Random.Range(0, m_GeneratePlaceValue);

            //アイテムの生成インターバルを設定
            m_generateInterval = SetGenerateInterval(_nowTime);

            //生成座標のXを決定
            x = UnityEngine.Random.Range(
                _generatePosMin[generatePlace].x,
                _generatePosMax[generatePlace].x);
            //生成座標のZ座標を決定
            z = UnityEngine.Random.Range(
                _generatePosMin[generatePlace].y,
                _generatePosMax[generatePlace].y);

            //生成するオブジェクトを決定
            int witch = UnityEngine.Random.Range(0, m_GenerateItemProbability);
            //バーベルの生成
            if (witch == 0)
            {
                m_createBarbell.Add(Instantiate(m_BarbellModel, new Vector3(x, m_ItemGeneratePosY, z),
                    Quaternion.identity, m_ParentCreatePointItem.transform));
            }
            //プロテインの生成
            else
            {
                m_createProtein.Add(Instantiate(m_ProteinModel, new Vector3(x, m_ItemGeneratePosY, z),
                    Quaternion.identity, m_ParentCreatePointItem.transform));
            }
        }
        //生成判定がFalseの時実行
        if (!m_isGenerate)
        {
            m_waitGenerateCount++;
            //生成待機のカウントが生成間隔を越していて、生成が終了していない時実行
            if (m_waitGenerateCount / FPSFixed.FPS >= m_generateInterval && !m_isFinishGenerate)
            {
                m_isGenerate = true;
            }
        }
    }
    /// <summary>
    /// ゲーム時間を参照して、アイテムの生成間隔を決定する
    /// </summary>
    float SetGenerateInterval(float _nowTime)
    {
        float generateInterval = 0;     //生成間隔
        //難易度1
        if (_nowTime <= m_FirstIncreaseDifficultyTime && _nowTime > m_SecondIncreaseDifficultyTime)
        {
            generateInterval = m_FirstGenerateInterval;
        }
        //難易度2
        else if (_nowTime <= m_SecondIncreaseDifficultyTime && _nowTime > m_ThirdIncreaseDifficultyTime)
        {
            generateInterval = m_SecondGenerateInterval;
        }
        //難易度3
        else if (_nowTime <= m_ThirdIncreaseDifficultyTime && _nowTime > m_FouthIncreaseDifficultyTime)
        {
            generateInterval = m_ThirdGenerateInterval;
        }
        //難易度4
        else if (_nowTime <= m_FouthIncreaseDifficultyTime && _nowTime > m_FifthIncreaseDifficultyTime)
        {
            generateInterval = m_FouthGenerateInterval;
        }
        //難易度5
        else if (_nowTime <= m_FifthIncreaseDifficultyTime && _nowTime > m_SixthIncreaseDifficultyTime)
        {
            generateInterval = m_FifthGenerateInterval;
        }
        //難易度6
        else if (_nowTime <= m_SixthIncreaseDifficultyTime && _nowTime > m_SeventhIncreaseDifficultyTime)
        {
            generateInterval = m_SixthGenerateInterval;
        }
        //難易度7
        else if (_nowTime <= m_SeventhIncreaseDifficultyTime && _nowTime > m_EiguthIncreaseDifficultyTime)
        {
            generateInterval = m_SeventhGenerateInterval;
        }
        //難易度8
        else if (_nowTime <= m_EiguthIncreaseDifficultyTime && _nowTime > m_NinthIncreaseDifficultyTime)
        {
            generateInterval = m_EiguthGenerateInterval;
        }
        //難易度9
        else if (_nowTime <= m_NinthIncreaseDifficultyTime && _nowTime > m_TenthIncreaseDifficultyTime)
        {
            generateInterval = m_NinthGenerateInterval;
        }
        //難易度10
        else if (_nowTime <= m_TenthIncreaseDifficultyTime && _nowTime > m_EleventhIncreaseDifficultyTime)
        {
            generateInterval = m_TenthGenerateInterval;
        }
        //難易度11
        else if (_nowTime <= m_EleventhIncreaseDifficultyTime && _nowTime > m_TwelfthIncreaseDifficultyTime)
        {
            generateInterval = m_EleventhGenerateInterval;
        }
        //残り５秒で生成を終了
        else if (_nowTime <= m_TwelfthIncreaseDifficultyTime && _nowTime != 0)
        {
            m_isFinishGenerate = true;
        }
        //エラー時
        else if(SceneManager.GetActiveScene().name != "Title")
        {
            m_isGenerate = false;
            Debug.Log("生成間隔のエラー");
        }
        //シーンがタイトルの時実行
        if(SceneManager.GetActiveScene().name == "Title")
        {
            generateInterval = m_TitleGenerateItemInterval;
        }
        //生成のインターバルを返す
        return generateInterval;
    }


    /// <summary>
    /// 生成したプロテインオブジェクトのリストを取得
    /// </summary>
    public List<GameObject> GetCreateProtein()
    {
        return m_createProtein;
    }

    /// <summary>
    /// 生成したバーベルオブジェクトのリストを取得
    /// </summary>
    public List<GameObject> GetCreateBarbell()
    {
        return m_createBarbell;
    }
}
