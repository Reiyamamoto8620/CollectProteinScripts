using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Playerの入力管理
/// </summary>
public class PlayerInput : MonoBehaviour
{

    [SerializeField] int m_RunTimeMaxCount = 30;            //Run状態の最大継続時間

    GetInput m_Input;                                       //プレイヤーの入力

    Vector2 m_stickInputValue;                              //スティック入力の値
    bool m_isRun;                                           //Run判定

    int m_runBarrageSpeed;                                  //Runボタンの連打速度
    int m_runTimeCount;                                     //現在のRun継続時間

    /// <summary>
    /// 起動時初期化
    /// </summary>
    void Awake()
    {
        // Actionスクリプトのインスタンス生成
        m_Input = new GetInput();

        m_isRun = false;

        // Actionイベント登録
        m_Input.Player.Move.started += OnMove;
        m_Input.Player.Move.performed += OnMove;
        m_Input.Player.Move.canceled += OnMove;
        m_Input.Player.Run.started += OnRun;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        m_Input.Enable();
    }

    void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        m_Input?.Dispose();
    }
    /// <summary>
    /// 更新
    /// </summary>
    public void ManagedUpdate()
    {
        //フレームのカウントが上限より下の場合フレームを計測する
        if (m_runTimeCount < m_RunTimeMaxCount)
        {
            m_runTimeCount++;
        }
        else
        {
            m_isRun = false;
        }
    }

    /// <summary>
    /// スティック入力の受け取り
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        m_stickInputValue = context.ReadValue<Vector2>();
    }
    /// <summary>
    /// ダッシュボタン入力の受け取り
    /// </summary>
    /// <param name="context"></param>
    public void OnRun(InputAction.CallbackContext context)
    {
        m_isRun = true;

        //ボタンが押されてから次の入力までのフレームを計測
        m_runBarrageSpeed = m_runTimeCount;
        //フレームのカウントをリセット
        m_runTimeCount = 0;
    }

    /// <summary>
    ///スティック入力を取得
    /// </summary>
    public Vector2 GetStickInputValue()
    {
        return m_stickInputValue;
    }

    /// <summary>
    /// ダッシュ入力を取得
    /// </summary>
    public bool GetIsRun()
    {
        return m_isRun;
    }

    /// <summary>
    /// 連打速度を取得
    /// </summary>
    public int GetRunBarrageSpeed()
    {
        return m_runBarrageSpeed;
    }
}
