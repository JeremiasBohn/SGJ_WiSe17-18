using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	AudioSource fadeInto;
    AudioSource src;
    [SerializeField]
    AudioSource boost;

	bool hasPlayedIntro;

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
        //boost.volume = 0;
	}
   
	// Update is called once per frame
	void Update () {
		if (src.time>=21.9f && !hasPlayedIntro) {
            fadeInto.mute = false;
			fadeInto.Play ();
            boost.mute = true;
            boost.Play();
			//StartCoroutine (CrossFade());
			hasPlayedIntro = true;
		}
		if (GameManagerBehaviour.instance.player.onCoffee)
        {
            fadeInto.mute = true;
            boost.mute = false; 
        }
        else
        {
            fadeInto.mute = false;
            boost.mute = true;

        }
    }
}
