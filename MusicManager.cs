using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour {

	// for storing music files
	public List<AudioClip> musicList = new List<AudioClip> ();

	// for playing music files
	private AudioSource audioPlayer;
	public AudioMixer audioMixer;

	// for analyzing music files
	public float musicPitch;
	public float errorTolerance;		// when judging player's matching abilities

	// for setting other objects according to the music
	private NoteActions noteScript;


	void Awake () {
		// start playing the first song
		audioPlayer = transform.GetComponent<AudioSource> ();
		audioPlayer.clip = musicList[0];
		audioPlayer.Play ();
		noteScript = GameObject.FindGameObjectWithTag ("Notes").GetComponent<NoteActions> ();
	}
	

	void Update () {
		// get and set pitch and note speed
		audioMixer.GetFloat("MasterPitch", out musicPitch);
		audioMixer.SetFloat ("MasterPitch", musicPitch + 0.01f*Input.GetAxis("Horizontal"));
		noteScript.speed = Mathf.Clamp (musicPitch * 5, 0f, 100f);
	}


	void OnTriggerEnter2D (Collider2D other) {
		// if note is within the target
		if (other.gameObject.tag == "Notes") {
			// report player's pitch matching success
			if (Mathf.Abs (1f - musicPitch) >= errorTolerance) {
				Debug.Log ("TRY HARDER!");
			} else {
				Debug.Log ("You're PITCHMASTERMASTER!");
			}
		}
	}
}
