using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの生成座標
/// </summary>
public class PointItemGeneratePos : MonoBehaviour
{
    //生成座標の最大と最小
    readonly Vector2 m_FirstGeneratePosMin = new Vector2(-3f, 4.5f);          //地点1の最少座標
    readonly Vector2 m_FirstGeneratePosMax = new Vector2(0f, 3f);             //地点1の最大座標

    readonly Vector2 m_SecondGeneratePosMin = new Vector2(0f, 4.5f);          //地点2の最少座標
    readonly Vector2 m_SecondGeneratePosMax = new Vector2(3f, 3f);            //地点2の最大座標

    readonly Vector2 m_ThirdGeneratePosMin = new Vector2(-4.5f, 3f);          //地点3の最少座標
    readonly Vector2 m_ThirdGeneratePosMax = new Vector2(-3f, 0f);            //地点3の最大座標

    readonly Vector2 m_FouthGeneratePosMin = new Vector2(-2f, 2f);            //地点4の最少座標
    readonly Vector2 m_FouthGeneratePosMax = new Vector2(-0.5f, 0.5f);        //地点4の最大座標

    readonly Vector2 m_FifthGeneratePosMin = new Vector2(0.5f, 2f);           //地点5の最少座標
    readonly Vector2 m_FifthGeneratePosMax = new Vector2(2f, 0.5f);           //地点5の最大座標

    readonly Vector2 m_SixthGeneratePosMin = new Vector2(3f, 3f);             //地点6の最少座標
    readonly Vector2 m_SixthGeneratePosMax = new Vector2(4.5f, 0f);           //地点6の最大座標

    readonly Vector2 m_SeventhGeneratePosMin = new Vector2(-4.5f, 0f);        //地点7の最少座標
    readonly Vector2 m_SeventhGeneratePosMax = new Vector2(-3f, -3f);         //地点7の最大座標

    readonly Vector2 m_EiguthGeneratePosMin = new Vector2(-2f, -0.5f);         //地点8の最少座標
    readonly Vector2 m_EiguthGeneratePosMax = new Vector2(-0.5f, -2f);         //地点8の最大座標

    readonly Vector2 m_NinthGeneratePosMin = new Vector2(0.5f, -0.5f);        //地点9の最少座標
    readonly Vector2 m_NinthGeneratePosMax = new Vector2(2f, -2f);            //地点9の最大座標

    readonly Vector2 m_TentheneratePosMin =  new Vector2(3f, 0f);             //地点１0の最少座標
    readonly Vector2 m_TentheneratePosMax =  new Vector2(4.5f, -3f);          //地点１0の最大座標

    readonly Vector2 m_EleventhGeneratePosMin = new Vector2(-3f, -3f);        //地点１1の最少座標
    readonly Vector2 m_EleventhGeneratePosMax = new Vector2(0f, -4.5f);       //地点１1の最大座標

    readonly Vector2 m_TwelfthGeneratePosMin = new Vector2(0f, -3f);          //地点１2の最少座標
    readonly Vector2 m_TwelfthGeneratePosMax =  new Vector2(3f, -4.5f);        //地点１2の最大座標


    List<Vector2> m_GeneratePosMin = new List<Vector2>();         //生成座標の最小座標を保存するリスト
    List<Vector2> m_GeneratePosMax = new List<Vector2>();         //生成座標の最大座標を保存するリスト

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        //地点1の座標をリストに格納
        m_GeneratePosMin.Add(m_FirstGeneratePosMin);
        m_GeneratePosMax.Add(m_FirstGeneratePosMax);
        //地点2の座標をリストに格納
        m_GeneratePosMin.Add(m_SecondGeneratePosMin);
        m_GeneratePosMax.Add(m_SecondGeneratePosMax);
        //地点3の座標をリストに格納
        m_GeneratePosMin.Add(m_ThirdGeneratePosMin);
        m_GeneratePosMax.Add(m_ThirdGeneratePosMax);
        //地点4の座標をリストに格納
        m_GeneratePosMin.Add(m_FouthGeneratePosMin);
        m_GeneratePosMax.Add(m_FouthGeneratePosMax);
        //地点5の座標をリストに格納
        m_GeneratePosMin.Add(m_FifthGeneratePosMin);
        m_GeneratePosMax.Add(m_FifthGeneratePosMax);
        //地点6の座標をリストに格納
        m_GeneratePosMin.Add(m_SixthGeneratePosMin);
        m_GeneratePosMax.Add(m_SixthGeneratePosMax);
        //地点7の座標をリストに格納
        m_GeneratePosMin.Add(m_SeventhGeneratePosMin);
        m_GeneratePosMax.Add(m_SeventhGeneratePosMax);
        //地点8の座標をリストに格納
        m_GeneratePosMin.Add(m_EiguthGeneratePosMin);
        m_GeneratePosMax.Add(m_EiguthGeneratePosMax);
        //地点9の座標をリストに格納
        m_GeneratePosMin.Add(m_NinthGeneratePosMin);
        m_GeneratePosMax.Add(m_NinthGeneratePosMax);
        //地点10の座標をリストに格納
        m_GeneratePosMin.Add(m_TentheneratePosMin);
        m_GeneratePosMax.Add(m_TentheneratePosMax);
        //地点11の座標をリストに格納
        m_GeneratePosMin.Add(m_EleventhGeneratePosMin);
        m_GeneratePosMax.Add(m_EleventhGeneratePosMax);
        //地点12の座標をリストに格納
        m_GeneratePosMin.Add(m_TwelfthGeneratePosMin);
        m_GeneratePosMax.Add(m_TwelfthGeneratePosMax);
    }

    /// <summary>
    /// GeberatePosMinリストを取得
    /// </summary>
    public List<Vector2> GetGeneratePosMin()
    {
        return m_GeneratePosMin;
    }
    /// <summary>
    /// GeberatePosMaxリストを取得
    /// </summary>
    public List<Vector2> GetGeneratePosMax()
    {
        return m_GeneratePosMax;
    }
}