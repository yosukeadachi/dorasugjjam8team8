using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleManController : MonoBehaviour {
    //死亡フラグ
    bool m_death_flag;
    //透明人間
    GameObject InvisibleMan;
    // Use this for initialization
    void Start () {
        //初期化処理
        m_death_flag = false;
        
        InvisibleMan = GameObject.Find("InvisibleMan");
    }

    // Update is called once per frame
    void Update () {
    }




    //状態変更
    void ChangeStateToHold()
    {
        if (m_death_flag == false)
        {
            m_death_flag = true;
            //表示する
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
