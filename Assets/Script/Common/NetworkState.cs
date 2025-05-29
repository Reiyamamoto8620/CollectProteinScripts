using UnityEngine;

/// <summary>
/// ネットワークの接続状態判定クラス
/// </summary>
public class NetworkState
{
    /// <summary>
    /// ネットワーク接続判定
    /// </summary>
    public static bool CheckNetworkState()
    {
        return !(Application.internetReachability == NetworkReachability.NotReachable);
    }
}
