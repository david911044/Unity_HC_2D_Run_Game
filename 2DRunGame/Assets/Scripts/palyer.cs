using UnityEngine;

public class palyer : MonoBehaviour
{
    #region  欄位
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 5;
    [Header("跳躍高度"), Range(0, 1000)]
    public int jump = 350;
    [Header("血量"), Range(0, 1000)]
    public float hp = 500;

    public bool isGround;
    public int coin;

    [Header("音效區域")]
    public AudioClip soundHit;
    public AudioClip soundSlide;
    public AudioClip soundJump;
    public AudioClip soundCoin;

    public Animator ani;
    public Rigidbody2D rid;
    public CapsuleCollider2D cap;
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {

    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // true 玩家是否按下空白鍵
        // 布林值 = 輸入.按下按鍵(按鍵列舉. 空白鍵)
        bool space = Input.GetKeyDown(KeyCode.Space);
        // 動畫控制器.設定布林值("參數名稱，布林值")
        ani.SetBool("跳躍開關", space);
    }

    /// <summary>
    /// 滑行
    /// </summary>
    private void Slide()
    {
        // Ctrl 滑行動畫
        bool ctrl = Input.GetKey(KeyCode.LeftControl);

        ani.SetBool("滑行開關", ctrl);

        // 如果 按下 ctrl
        // 滑行 位移  -0.1 -1.4 尺寸 1.35 1.5
        // 否則
        // 站立 位移  -0.1 -0.4 尺寸 1.35 3.6
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void EatCoin()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    private void Hit()
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {

    }

    /// <summary>
    /// 過關
    /// </summary>
    private void Pass()
    {

    }
    #endregion 事件


    #region 事件
    private void Start()
    {
     
    }

    private void Update()
    {
        Jump();
        Slide();
    }
    #endregion 
}