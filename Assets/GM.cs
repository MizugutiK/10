using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;				//　UnityのUIの機能を継承（使用）します

public class GM : MonoBehaviour
{
    public Text goalText;			//　Text型の変数goalTextを用意します	

    void Start()
    {
        goalText = GameObject.Find("clear").GetComponent<Text>();　//　”Goal”という名のObjectを探して、そのTextコンポネントを入れます
        goalText.gameObject.SetActive(false);	　　　　　//　その入れたTextのgameObjectをfalseにして表示を止めておきます
    }

    public void GoalFlag()			//　他のクラスからアクセス可能なpublicのGaolFlag()というメソッドをつくりました　
    {
        goalText.gameObject.SetActive(true);		//　SetActiveをtrueにするだけのメソッドです	
        return;     				//　戻ります（書かなくても動きますが・・）
    }
}

