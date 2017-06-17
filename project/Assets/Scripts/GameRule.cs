using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRule : MonoBehaviour {
	//インスペクターから設定
	public GameTimerScript gameTimer;
	public Text startText;
	public Text successText;
	public Text failText;
	public Text leftEnemyText;
	public Text scoreText;



	public string enemyTag="Enemy";
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

	private int leftEnemy;
	private int defaultLeftEnemy;

	// Use this for initialization
	void Start () {
		startTimeCount = 1.0f;
		nowFlow = Flow.START;
		startText.enabled = true;
		successText.enabled = false;
		failText.enabled = false;
		leftEnemyText.enabled = true;
		scoreText.enabled = false;
		butoonToTitle = GameObject.Find("ButtonToTitle");
		butoonToTitle.SetActive(false);
		randomEnemy();
		updateLeftEnemy();
		defaultLeftEnemy = leftEnemy;
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
		visibleAllEnemy();
	}

	public void toFlowSuccess() {
		nowFlow = Flow.SUCCESS;
		successText.enabled = true;
		butoonToTitle.SetActive(true);
		scoreText.enabled = true;
		scoreText.text = (defaultLeftEnemy * 100 + gameTimer.countTime * 100).ToString("F0");
	}


	void flowStart() {
		updateLeftEnemy();
		leftEnemyText.text = "残り：" + leftEnemy.ToString() + "体";

		startTimeCount -= Time.deltaTime;
		// Debug.Log(startTimeCount);
		if(startTimeCount < 0.0f) {
			nowFlow = Flow.PLAYING;
			startText.enabled = false;
		}
	}

	void flowPlaying() {
		//入力
		if (Input.GetMouseButtonDown(0)) {
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
			if (collition2d) {
				RaycastHit2D hitObject = Physics2D.Raycast(tapPoint,-Vector2.up);
				if (hitObject.collider.gameObject.CompareTag(enemyTag)) {
					Debug.Log("hit object is " + hitObject.collider.gameObject.name);
					hitObject.collider.gameObject.GetComponent<InvisibleManController>().ChangeStateToHold();
				}
			}
		}

		//残り更新
		updateLeftEnemy();
		leftEnemyText.text = "残り：" + leftEnemy.ToString() + "体";

		//全員死んでたら
		if(leftEnemy <= 0) {
			toFlowSuccess();
		}

	}

	void flowSuccess() {

	}

	void flowFail() {

	}

	void updateLeftEnemy() {
		//シーン内の敵を検索
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		int _cnt = enemies.Length;
		foreach(var en in enemies) {
			if(en.GetComponent<InvisibleManController>().isDead()) 
			{
				_cnt--;
			}
		}
		leftEnemy = _cnt;
		// Debug.Log(_enemy_count.ToString());
	}

	//敵をランム配置
	void randomEnemy() {
		//シーン内の敵を検索
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		int _cnt = enemies.Length;
		float _ox = -8.0f;
		float _oy = -4.0f;
		float _range_x = 14.0f;
		float _range_y = 9.0f;
		int i = 0;
		foreach(var en in enemies) {
			Vector3 _pos = en.transform.position;
			_pos.x = _ox + ((_range_x / _cnt+1) * i) + Random.Range(-1.0f,1.0f);
			_pos.y = _oy + Random.Range(0.0f,_range_y);
			en.transform.position = _pos;
			i++;
		}
	}

	//敵を全表示
	void visibleAllEnemy() {
		//シーン内の敵を検索
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		foreach(var en in enemies) {
			en.GetComponent<InvisibleManController>().ChangeTransparency(1.0f);
		}
	}

}
