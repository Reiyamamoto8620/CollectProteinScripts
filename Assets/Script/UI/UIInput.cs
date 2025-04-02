using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// UIの入力制御クラス
/// </summary>
public class UIInput : MonoBehaviour
{
    GetInput m_input;           //入力制御

    //スティックの入力値管理クラス
    public class StickInput
    {
        public bool m_isUp;
        public bool m_isDown;
        public bool m_isLeft;
        public bool m_isRight;
    }
    StickInput m_stickInput;        //スティックの入力値管理クラス
    bool m_isEnter;                 //決定ボタンの入力判定
    bool m_isInputName;             //名前入力判定
    bool m_isSpace;                 //スペースキーの入力判定

    /// <summary>
    /// 生成時に実行
    /// </summary>
    void Awake()
    {
        m_isEnter = false;
        m_isInputName = false;
        m_isSpace = false;
        
        m_stickInput = new StickInput();
        m_stickInput.m_isUp = false;
        m_stickInput.m_isDown = false;
        m_stickInput.m_isLeft = false;
        m_stickInput.m_isRight = false;

        m_input = new GetInput();
        m_input.Menu.Select.started += OnSelect;
        m_input.Menu.Enter.started += OnEnter;

        m_input.Menu.Space.started += OnSpace;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        m_input.Enable();
    }
    /// <summary>
    /// 削除時に実行
    /// </summary>
    void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        m_input?.Dispose();
    }

    /// <summary>
    /// セレクトの入力受け取り
    /// </summary>
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (!m_isInputName)
        {
            //スティックの入力値を獲得
            Vector2 stickInputValue = context.ReadValue<Vector2>();
            //スティックのY入力が+の時実行
            if (stickInputValue.y > 0)
            {
                m_stickInput.m_isUp = true;
            }
            //スティックのY入力が-の時実行
            if (stickInputValue.y < 0)
            {
                m_stickInput.m_isDown = true;
            }
            //スティックのX入力が+の時実行
            if (stickInputValue.x > 0)
            {
                m_stickInput.m_isRight = true;
            }
            //スティックのX入力が-の時実行
            if (stickInputValue.x < 0)
            {
                m_stickInput.m_isLeft = true;
            }
        }
    }
    /// <summary>
    /// 決定ボタンの入力受け取り
    /// </summary>
    public void OnEnter(InputAction.CallbackContext context)
    {
        m_isEnter = true;
    }
    /// <summary>
    /// スペースキーの入力受け取り
    /// </summary>
    public void OnSpace(InputAction.CallbackContext context)
    {
        m_isSpace = true;
    }
    /// <summary>
    /// スティック入力を取得
    /// </summary>
    public StickInput GetStickInput()
    {
        return m_stickInput;
    }
    /// <summary>
    /// 決定入力を取得
    /// </summary>
    public bool GetIsEnter()
    {
        return m_isEnter;
    }
    /// <summary>
    /// スペースキー入力を取得
    /// </summary>
    public bool GetIsSpace()
    {
        return m_isSpace;
    }
    /// <summary>
    /// 決定入力をセット
    /// </summary>
    public void SetIsEnter(bool _isEnter)
    {
        m_isEnter = _isEnter;
    }
    /// <summary>
    /// スペース入力をセット
    /// </summary>
    public void SetIsSpace(bool _isSpace)
    {
        m_isSpace = _isSpace;
    }
    /// <summary>
    /// スティック入力をセット
    /// </summary>
    public void SetStickInput(bool _input)
    {
        m_stickInput.m_isDown = _input;
        m_stickInput.m_isLeft = _input;
        m_stickInput.m_isUp = _input;
        m_stickInput.m_isRight= _input;
    }
    /// <summary>
    /// 名前入力判定をセット
    /// </summary>
    public void SetIsInputName(bool _isInputName)
    {
        m_isInputName = _isInputName;
    }
}
