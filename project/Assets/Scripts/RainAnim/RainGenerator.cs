using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainGenerator : MonoBehaviour {

    public GameObject RainPrefab;

    public GameObject puddlePrefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
           
                GameObject go = Instantiate(RainPrefab) as GameObject;


            GameObject go2 = Instantiate(puddlePrefab) as GameObject;
            //   GetComponent<AudioSource>().Play();



        }
     
        
	}
}
