using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerScript : MonoBehaviour {
	public GameRule gaameRule;
	public Text leftTimeText;

	private float countTime;

	// Use this for initialization
	void Start () {
		countTime = 10.0f;
		leftTimeText.text = countTime.ToString("F2");
	}
	
	// Update is called once per frame
	void Update () {
		switch (gaameRule.nowFlow)
		{
			case GameRule.Flow.PLAYING:
				countTime -= Time.deltaTime;
				if(countTime < 0.0f) {
					countTime = 0.0f;
					gaameRule.toFlowFail();
				}
				leftTimeText.text = countTime.ToString("F2");
				break;

			default:
				break;
		}
	}
}
