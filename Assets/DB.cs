using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")　//　もし相手(other)のtagが”Enemy”ならば
        {
            Destroy(this.gameObject);                 //　このオブジェクトを壊します
        }
    }
}

