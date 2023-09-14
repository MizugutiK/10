using UnityEngine;

public class MP : MonoBehaviour
{
    public GameObject ballObj;        // 生成したいPrefab
    private Vector3 clickPos;             // クリックした位置座標
    public int rapid;                              //　ボールを出せるようになるまでの時間
    private int oriRapid;                       //   元のrapidに入れられていた値を格納しておく変数
    public bool gameOn;          //   ゲームが進行中か終わってるか、の2択のフラグ
    public float speed;                //　飛ばす力の大きさの値です
    public Vector2 ballDir;            //　飛ばす方向の２Dベクトル、（ｘ、ｙ）となります
    bool mouseOn;       //     MouseでTriggerを（このObjectを）クリックされたかどうか

    private void Start()
    {
        oriRapid = rapid;               //editorでrapidに入れた値をoriRapidに格納します
        gameOn = true;                //gameOnをtrueにします
        mouseOn = false;             //mouseOnをfalseにしておきます
    }

    void Update()
    {
        if (gameOn == true)
        {
            rapid -= 1;             //rapidから1を引きます

            if (rapid <= 0 && mouseOn == true)     //もしrapidの値が０以下で、mouseOnフラグがtrueなら・・・
            {
                if (Input.GetMouseButtonDown(0))        // マウスで左クリック("0"が左クリックに初期設定してあります)したら・・
                {
                    clickPos = Input.mousePosition;          // Vector3でマウスがクリックした位置座標を取得する
                    clickPos.z = 10.0f;                                   // ｚ軸の値に適当な値を入れます
                    GameObject ball = Instantiate(ballObj, Camera.main.ScreenToWorldPoint(clickPos), ballObj.transform.rotation);
                    ball.GetComponent<Rigidbody2D>().AddForce(ballDir * speed);
                    //ボールにRigidbodyを入れてAddForceで物理的な力を加えます
                    mouseOn = false;        //mouseOnフラグをfalseにして、押されてない状態に戻します
                    rapid = oriRapid;           //　rapidにもとのoriRapidの値を入れて戻します　
                }
            }
        }
        else return;
    }

    private void OnMouseDown()  //　マウスでクリックしたかどうかを判断するメソッドです
    {
        mouseOn = true;      //　mouseOnフラグをtrueにします
    }
}

