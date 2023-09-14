using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPM : MonoBehaviour
{
    public GameObject enemy;	 	//　エネミーのオブジェクトを入れる変数を用意します
    private Vector2 enePos;		 //　現在のポジションを格納する変数を用意します
    private Vector3 targetPos;		 //　Playerオブジェクトのポジションを格納する変数を用意します
    private float rad;			 //　向かう方向のラジアンを格納する変数を用意します
    public float speed;      //　エネミーの移動速度(かける値)を格納する変数を用意します

    void Start()
    {
        //　変数targetPosにプレイヤーオブジェクトをの位置データを探して入れます
        targetPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        //　目標となるオブジェクトのｙ座標の差とx座標の差を用いて、その2つの線の作る角度のラジアンを求めます
        rad = Mathf.Atan2(targetPos.y - enemy.transform.position.y, targetPos.x - enemy.transform.position.x);
    }
    void Update()
    {
        enePos = enemy.transform.position;          //　変数enePosに現在のエネミーの位置を入れます 
        enePos.x += speed * Mathf.Cos(rad);        　//　変数enePosのx値に「x軸方向の大きさ×speed」を入れます  
        enePos.y += speed * Mathf.Sin(rad);　　　 //　変数enePosのx値に「y軸方向の大きさ×speed」を入れます 
        enemy.transform.position = enePos;　　 //　現在の位置に、計算して得られたposition値を入れます
    }
}

