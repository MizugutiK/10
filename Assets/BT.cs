using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT : MonoBehaviour
{
    public GameObject obj;                      //　出したいObjectを変数objに格納します
    public int points;          		//　ゴールに入れるボールの数

    GameObject gameCtrl;		//　GameObject型の変数　gameCtrlを用意します、このオブジェクトにGoalManagerクラスが入れられています
    GM script;      //　GoalManagert型の変数　scriptを用意します　各クラス（スクリプト）はその型として変数を作ることができます

    private void Start()         //　Start()時に、各変数に本体を呼び込みます
    {
        gameCtrl = GameObject.Find("GameObject"); 	//　変数gameCtrlに　GameControllerオブジェクトを見つけてきて入れます
        script = gameCtrl.GetComponent<GM>();   //　変数scriptに　gameCtrlに入れられたGameControllerにあるGameManagerスクリプトを入れます
        obj.SetActive(false);                       //Strat時にobjに格納されたものを非表示にします
    }

    void OnTriggerEnter2D(Collider2D other)  //　トリガーに当たって、そこを抜けたら（Exit）
    {
        if (other.gameObject.tag == "Player")　　//　もし出ていった相手(other)のtagが”Player”ならば
        {
            obj.SetActive(true);            //　objに入れられてるオブジェクトを、表示させます
            script.GoalFlag();		 //　壊される直前に変数scriptに入ったGameManagerスクリプトにあるGoalFlag()メソッドを呼び、実行します

            this.gameObject.SetActive(false);   　　　//　このオブジェクトをScene から消します（setを「止めます」）
        }
        return;                                             //　プログラムの先頭へ戻ります
    }
}
