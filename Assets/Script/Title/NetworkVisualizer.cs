using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �l�b�g���[�N�ڑ���Ԃ�\������N���X
/// </summary>
public class NetworkVisualizer : MonoBehaviour
{
    
    [SerializeField] Sprite m_OnlineTexture;                //�I�����C����Ԃ̃e�N�X�`��
    [SerializeField] Sprite m_OfflineTexture;               //�I�t���C����Ԃ̃e�N�X�`��
    [SerializeField] GameObject m_NetworkStateImage;        //�l�b�g���[�N�̏�Ԃ�\������I�u�W�F�N�g
    [SerializeField] GameObject m_GachaStopImage;           //�K�`���V�[���̈ڍs�\�������������I�u�W�F�N�g
    void Awake()
    {
        Sprite nowNetWorkStateTexture;                                  //���݂̃l�b�g���[�N��Ԃ̃e�N�X�`��
        //�l�b�g���[�N�̏�Ԃ��ڑ���Ԃ̎����s
        if (NetworkState.CheckNetworkState())
        {
            //���݂̃l�b�g���[�N��Ԃ̃e�N�X�`�����I�����C���ɂ���B
            nowNetWorkStateTexture = m_OnlineTexture;
            //�K�`���V�[���̈ڍs�\������\���ɂ���
            m_GachaStopImage.SetActive(false);
        }
        //�l�b�g���[�N�̏�Ԃ��ؒf��Ԃ̎����s
        else
        {
            //���݂̃l�b�g���[�N��Ԃ̃e�N�X�`�����I�t���C���ɂ���B
            nowNetWorkStateTexture = m_OfflineTexture;
            //�K�`���V�[���̈ڍs�\�����\���ɂ���
            m_GachaStopImage.SetActive(true);
        }
        //�l�b�g���[�N��Ԃ�
        m_NetworkStateImage.GetComponent<Image>().sprite = nowNetWorkStateTexture;
    }
}
