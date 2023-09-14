using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UnityのUIをプログラムで動かせるようにします

public class EnemyManege : MonoBehaviour
{
   
    //体力関係
    public int EnemyHP = 0; //オブジェクトの体力値となります　publicにすることで、Unity内で調整・設定できるようになります
    public int damage = 0; //攻撃を受けた時のダメージ値となります

    //スライダーのオブジェクト関係
    public GameObject sliderobj; //体力ゲージのオブジェクトを収納する場所
    Slider HPGauge; //体力ゲージを収納する場所（参照される場所）

    //その他演出
    public GameObject sprite; //イラストのAnimatorを取得するためにspriteを参照します
    Animator anime; //Animatorを動かすために使います　ここではBodyのアニメーションとは関係なく、体の部分自身にアニメーションを加えます

   
    void Start()
    {
        HPGauge = sliderobj.GetComponent<Slider>(); //収納した体力ゲージのオブジェクトのSlider機能を取得します
        HPGauge.maxValue = EnemyHP;　//体力ゲージの最大値を設定した体力にします（Unity内で設定した値）

        //その他
        anime = sprite.GetComponent<Animator>();　//spriteのAnimatorを取得します
    }
    void Update()
    {
        HPGauge.value = EnemyHP; //体力ゲージの値はオブジェクトの体力値とずっと同じにします　つまり、体力値が減ると体力ゲージも削られます

        if (EnemyHP <= 0)//もし、体力値が0になったら
        {
            Destroy(gameObject, 0.1f);//このオブジェクトを破壊します
        }
    }

    void OnTriggerEnter2D(Collider2D collision) //他のオブジェクトと判定が衝突した時
    {
        if (collision.gameObject.tag == "Player") //もし、ぶつかったオブジェクトのタグが、”Player”だった場合
        {
            EnemyHP -= damage; //damageで設定した値を体力値から減らします

            //その他演出
            anime.SetTrigger("damaged"); //Animatorのトリガーパラメーター（”damaged”）を呼びます
         
        }
    }
}