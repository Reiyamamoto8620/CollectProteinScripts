using UnityEngine;

/// <summary>
/// プレイヤーデータを一時保存するスクリプタブルオブジェクト
/// </summary>
[CreateAssetMenu(fileName = "PlaySceneDataScriptableObject", 
    menuName = "PlaySceneDataScriptableObject")]
public class PlaySceneDataScriptableObject : ScriptableObject
{
    public int m_score;                 //スコア
    public Vector3 m_playerPosition;    //プレイヤーの座標
    public Quaternion m_playerRotation; //プレイヤーの回転値
}