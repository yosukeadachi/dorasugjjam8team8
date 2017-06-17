using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
	public AudioClip audioClipSeRain;
    public AudioClip audioClipSeEnemy;
    public AudioClip audioClipBgmRain;
    private AudioSource[] sources;

	// Use this for initialization
	void Start () {
		sources = gameObject.GetComponents<AudioSource>();
        sources[0].clip = audioClipBgmRain;
        sources[0].Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playSeRain() {
		sources[1].clip = audioClipSeRain;
		sources[1].PlayOneShot(audioClipSeRain);
	}
}
