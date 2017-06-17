using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
       
        //表示する
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        Vector3 position = Input.mousePosition;
        position.z = 10f;
        position.y -= 10f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        Vector3 screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = screenToWorldPointPosition;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
