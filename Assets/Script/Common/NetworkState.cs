using UnityEngine;

/// <summary>
/// �l�b�g���[�N�̐ڑ���Ԕ���N���X
/// </summary>
public class NetworkState
{
    /// <summary>
    /// �l�b�g���[�N�ڑ�����
    /// </summary>
    public static bool CheckNetworkState()
    {
        return !(Application.internetReachability == NetworkReachability.NotReachable);
    }
}
