using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRule : MonoBehaviour {
	//インスペクターから設定
	public Text startText;
	public Text successText;
	public Text failText;



	//
	private GameObject butoonToTitle;

	//フロー設定
	public enum Flow {
		START,
		PLAYING,
		SUCCESS,
		FAIL,
	}

	public Flow nowFlow;

	private float startTimeCount;

	// Use this for initialization
	void Start () {
		startTimeCount = 1.0f;
		nowFlow = Flow.START;
		startText.enabled = true;
		successText.enabled = false;
		failText.enabled = false;
		butoonToTitle = GameObject.Find("ButtonToTitle");
		butoonToTitle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		switch(nowFlow) {
			case Flow.START:
				flowStart();
				break;
			case Flow.PLAYING:
				flowPlaying();
				break;
			case Flow.SUCCESS:
				flowSuccess();
				break;
			case Flow.FAIL:
				flowFail();
				break;
			default:
				break;
		}
	}

	public void toFlowFail() {
		Debug.Log("toFlowFail");
		nowFlow = Flow.FAIL;
		failText.enabled = true;
		butoonToTitle.SetActive(true);
	}

	public void toFlowSuccess() {
		nowFlow = Flow.SUCCESS;
		successText.enabled = true;
		butoonToTitle.SetActive(true);
	}


	void flowStart() {
		startTimeCount -= Time.deltaTime;
		// Debug.Log(startTimeCount);
		if(startTimeCount < 0.0f) {
			nowFlow = Flow.PLAYING;
			startText.enabled = false;
		}
	}

	void flowPlaying() {
		//タグで透明人間検索
		//全員死んでたら
		//toFlowSuccess();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            RaycastHit hit = new RaycastHit();
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.CompareTag(cubeTag))
                {
                    hit.collider.gameObject.GetComponent<CubeControl>().OnUserAction();
                }
            }
        }

	}

	void flowSuccess() {

	}

	void flowFail() {

	}

}
