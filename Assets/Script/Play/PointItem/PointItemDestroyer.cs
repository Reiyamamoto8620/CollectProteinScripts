using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムの削除処理
/// </summary>
public class PointItemDestroyer : MonoBehaviour
{
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool isHit,List<GameObject> CreateObject,int objectIndex)
    {
        //オブジェクトに当たっている場合、処理を実行
        if(isHit)
        {
            //該当オブジェクトを削除
            Destroy(CreateObject[objectIndex].gameObject);
            //該当オブジェクトをリストから削除
            CreateObject.Remove(CreateObject[objectIndex]);
        }
    }
}
