using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// テキスト入力制御クラス
/// </summary>
public class InputText : MonoBehaviour
{
    TMP_InputField m_inputField;                            //テキスト入力用クラス
    [SerializeField] GameObject m_InputField;               //テキスト入力オブジェクト

    [SerializeField] SaveDataScriptableObject m_SaveData;   //セーブデータ

    bool m_isInputText;                                     //テキスト入力判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_isInputText = false;
        //InputFieldコンポーネントを取得
        m_inputField = m_InputField.GetComponent<TMP_InputField>();
        m_inputField.text = m_SaveData.m_data.playerName;
    }

    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate(bool _isInputName)
    {
        //テキストの入力判定がtrueの時実行
        if (_isInputName)
        {
            //テキスト入力を有効化
            ActiveInputName();
        }
        //テキストの入力判定がfalseの時実行
        if (!_isInputName)
        {
            //テキスト入力を無効化
            DeactivaInputName();
        }
    }
    /// <summary>
    /// 入力された名前情報を読み取ってコンソールに出力する関数
    /// </summary>
    public void GetInputName()
    {
        //InputFieldからテキスト情報を取得する
        m_SaveData.m_data.playerName = m_inputField.text;
        Debug.Log(m_SaveData.m_data.playerName);
    }

    /// <summary>
    /// テキスト入力を有効化
    /// </summary>
    void ActiveInputName()
    {
        //入力を開始
        m_inputField.ActivateInputField();
        //入力判定をtrue
        m_isInputText = true;
    }
    /// <summary>
    /// テキスト入力を無効化
    /// </summary>
    void DeactivaInputName()
    {
        //入力を終了
        m_inputField.DeactivateInputField();
        EventSystem.current.SetSelectedGameObject(null);

        //入力判定をfalse
        m_isInputText = false;
    }
}
