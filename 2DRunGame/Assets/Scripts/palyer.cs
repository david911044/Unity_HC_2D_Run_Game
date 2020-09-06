﻿using UnityEngine;
using UnityEngine.UI;

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

    [Header("金幣數量")]
    public Text textCoin;

    public Animator ani;
    public Rigidbody2D rig; 
    public CapsuleCollider2D cap;
    public AudioSource aud;
    #endregion

    #region 方法
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // Time.deltaTime 一幀的時間
        // Update 內移動、旋轉、運動 * Time.deltaTime
        // 避免不同裝置執行速度不同
        transform.Translate(speed * Time.deltaTime, 0, 0);  // 變形.位移(x, y, z)
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        // true 玩家是否按下空白鍵
        // 布林值 = 輸入.按下按鍵(按鍵列舉. 空白鍵)
        bool space = Input.GetKeyDown(KeyCode.Space);

        // 2D 射線碰撞物件 = 2D 物理.射線碰撞(起點，方向，長度，圖層）
        // 圖層語法：1 << 圖層編號
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.05f, -1.1f), -transform.up, 0.01f, 1 << 8);

        if (hit)
        {
            isGround = true;      // 如果 碰到地板 是否在地板上 = 是
            ani.SetBool("跳躍開關", false);
        }
        else
        {
            isGround = false;     // 否則 是否在地板上 = 否
        }

        // 如果 在地板上
        if (isGround)
        {
            if (space)
            {
                // 動畫控制器.設定布林值("參數名稱，布林值")
                ani.SetBool("跳躍開關", true);
                // 剛體.添加推力(二維向量)
                rig.AddForce(new Vector2(0, jump));
                // 音效來源.播放一次(音效，音量)
                aud.PlayOneShot(soundJump, 0.3f);

            }
        }


    }

    /// <summary>
    /// 滑行
    /// </summary>
    private void Slide()
    {
        // Ctrl 滑行動畫
        bool ctrl = Input.GetKey(KeyCode.LeftControl);
        ani.SetBool("滑行開關", ctrl);

        // 如果 按下 左邊 ctrl 播放一次音效
        // 判斷式如果只有一行程式可以省略大括號
        if (Input.GetKeyDown(KeyCode.LeftControl)) aud.PlayOneShot(soundSlide, 0.8f);

        // 如果 按下 ctrl
        if (ctrl)
        {
            // 滑行 位移  -0.1 -1.4 尺寸 1.35 1.5
            cap.offset = new Vector2(-0.1f, -1.5f);
            cap.size = new Vector2(1.35f, 1.35f); 
        }
         // 否則
        else
        {
            // 站立 位移  -0.1 -0.4 尺寸 1.35 3.6
            cap.offset = new Vector2(-0.1f, -0.4f);
            cap.size = new Vector2(1.35f, 3.6f);

        }
        
       
        
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void EatCoin()
    {
        coin++;                                       // 遞增1
        aud.PlayOneShot(soundCoin, 1.2f);             // 播放音效
        textCoin.text = "金幣數量：" + coin;          // 文字介面.文字 = 字串 + 整數
        Destroy(obj);
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
    
    #endregion



    #region 事件
    private void Start()
    {
     
    }

    private void Update()
    {
        Jump();
        Slide();
        Move();
    }

    // 碰撞事件 ：
    

    // 繪製圖示事件：繪製輔助線條，僅在 Scene 看得到
    private void OnDrawGizmos()
    {
        // 圖示.顏色 = 顏色.紅色
        Gizmos.color = Color.red;
        // 圖示.繪製射線(起點，方向)
        // transform 此物件的變形元件
        // transform.position 此物件的座標
        // transform.up 此物件上方      Y 預設為1
        // transform.right 此物件右方   X 預設為1
        // transform.forward 此物件前方 Z 預設為1
        Gizmos.DrawRay(transform.position + new Vector3(-0.05f, -1.1f), -transform.up * 0.01f);
    }
    #endregion 
}