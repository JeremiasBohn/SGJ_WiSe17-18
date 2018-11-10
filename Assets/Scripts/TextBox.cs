using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using XInputDotNetPure;
public class TextBox : MonoBehaviour {
	IEnumerator coroutine;
	public Text text;
	[SerializeField]
	private string[] script;
	[SerializeField]
	string nextScene;
	int currentText;
    private int startRum;
	// Use this for initialization
	void Start () {
		currentText = 0;
		text.text = script [currentText];
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {	//TODO: or controller input
			currentText++;
       
            StartCoroutine (Rumble(0.1f));
  // GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.1f);

			if (currentText < script.Length) {
				text.text = script [currentText];
			} else {
				SceneManager.LoadScene (nextScene);
			}
		}

	}
    IEnumerator Rumble(float duration) {
        GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
        yield return new WaitForSeconds(duration);
        GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
    }
}
