﻿using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random; 

public class SoundManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	private float lowPitchRange = 0.95f;
	private float highPitchRange = 1.05f;

	// Use this for initialization
	void Awake  () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip){
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	public void RandomizeSfx(params AudioClip [] clips){
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		sfxSource.pitch = randomPitch;
		sfxSource.clip = clips [randomIndex];
		sfxSource.Play (); 
	}

}
