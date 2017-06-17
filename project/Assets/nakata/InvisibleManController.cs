using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleManController : MonoBehaviour {
    //死亡フラグ
    bool m_death_flag;
    // Use this for initialization
    void Start () {
        //初期化処理
        m_death_flag = false;
        
        ChangeTransparency(0.0f);
    }

    // Update is called once per frame
    void Update () {
    }

    public void ChangeTransparency (float alpha) 
    {
        float changeRed = 1.0f;
        float changeGreen = 1.0f;
        float cahngeBlue = 1.0f;
        float cahngeAlpha = alpha;
        // 元の画像の色のまま、半透明になって表示される。
        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);
    }


    //状態変更
    public void ChangeStateToHold()
    {
        Debug.Log("ChangeStateToHold");

        if (m_death_flag == false)
        {
            m_death_flag = true;
            //表示する
            ChangeTransparency(1.0f);
        }
    }

    public bool isDead() {
        return m_death_flag;
    }
}
