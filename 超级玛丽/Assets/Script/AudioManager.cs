using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static AudioManager Instance;
	public AudioSource MusicPlayer;
	public AudioSource SoundPlayer;
	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	public void PlayMusic(string name){
		// 如果没播放音乐，播放
		if (MusicPlayer.isPlaying == false)
		{
			AudioClip clip = Resources.Load<AudioClip>(name);
			MusicPlayer.clip = clip;
			MusicPlayer.Play();
		}
	}

	public void StopMusic()
	{
		MusicPlayer.Stop();
	}

	public void PlaySound(string name){
		AudioClip clip = Resources.Load<AudioClip>(name);
		SoundPlayer.PlayOneShot(clip);
	}
}
