using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneSlideIn : MonoBehaviour {

	[SerializeField] float slideToPointX;
	[SerializeField] float movementSpeed;
	[SerializeField] bool comesFromRight;

	IEnumerator SlideIn() {
		yield return new WaitForSeconds (0.8f);
		while (true) {
			float vert = 0;
			if (transform.position.x < slideToPointX && !comesFromRight) {
				vert = movementSpeed * Time.deltaTime;
			} else if (transform.position.x > slideToPointX && comesFromRight) {
				vert = -movementSpeed * Time.deltaTime;
			}
			transform.Translate (vert, 0, 0);
			yield return new WaitForEndOfFrame ();
		}

	}

	// Use this for initialization
	void Start () {
		StartCoroutine (SlideIn ());
	}
	
	// Update is called once per frame
	void Update () {
		


	}
}