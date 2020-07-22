using UnityEngine;

public class car : MonoBehaviour
    {
    //欄位 field : 储存資料
    //***** 欄位語法
    //修飾詞 欄位類型 欄位名稱 (指定 值) 結束符號
    //* 欄位值以 unity 屬性 (Inspector) 面板為主

    //
    //
    //
    //

    //修飾詞:預設為私人
    //私人 private: 不顯示
    //公開 public:不顯示

    // 資料  
    // 品牌 、C數 、重量 、顏色 、是否有天窗
    //欄位的屬性
    [Header("品牌")]
    public string brand = "賓士";
    [Header("CC 數"), Tooltip("汽車的 CC 數量")]
    public int cc = 1500;
    [Header("重量"), Range(0, 100)]
    public float weight = 20.5f;
    [Header("是否有天窗"), Tooltip("打勾代表有, 取消代表沒有")]
    public bool window = true;
    [Header("速度"), Range(0, 200)]
    public float speed = 60.5f;

    // 補充 : Unity 常用資料類型
    // 顏色 , 座標(2, 3, 4)
    // Color, Vector234
    public Color red = Color.red;
    public Color myColor = new Color(0.5f, 0.5f, 0.9f);

    public Vector2 posZero = Vector2.zero;
    public Vector2 posOne = Vector2.one;
    public Vector2 posCustom = new Vector2(9, 20);

    public Vector3 pos3 = new Vector3(3, 2, 1);

    public Vector4 pos4 = new Vector4(1, 2, 3, 4);

    // 儲存物件，元件
    // 物件：
    //
    public GameObject cam;
    public Transform traCam;
    public Camera cam1;
}
