using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// セーブデータスクリプタブルオブジェクト
/// </summary>
[CreateAssetMenu(fileName = "SaveDataScriptableObject", menuName = "SaveDataScriptableObject")]
public class SaveDataScriptableObject : ScriptableObject
{
    public Data m_data = new Data();        //セーブデータ
}

/// <summary>
/// セーブデータクラス
/// </summary>
[System.Serializable]
public class Data
{
    public string playerName;       //プレイヤーネーム
    public int protein;             //今まで獲得したプロテイン数
    public int highScore;           //ハイスコア 
    public int nowSkin;             //現在のスキン
    public bool gold;               //ゴールドスキンの開放判定
    public bool silver;             //シルバースキンの開放判定
    public bool red;                //レッドスキンの開放判定
    public bool blue;               //ブルースキンの開放判定
    public bool green;              //グリーンスキンの開放判定
    public bool yellow;             //イエロースキンの開放判定
    public bool normal;             //ノーマルスキンの開放判定
    public bool black;              //ブラックスキンの開放判定
    public bool purple;             //パープルスキンの開放判定
    public bool orange;             //オレンジスキンの開放判定
}