using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAnimation : MonoBehaviour {
    Animator animator;
    int raincnt;
    bool rainflag;
    // Use this for initialization
    void Start () {
        this.animator = GetComponent<Animator>();
        rainflag = false;
        //表示する
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        Vector3 position = Input.mousePosition;
        position.z = 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = screenToWorldPointPosition;
       GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update () {


  

       
            raincnt++;
            if (raincnt > 15)
            {
                Destroy(gameObject);
            }
             
        
    }
}
