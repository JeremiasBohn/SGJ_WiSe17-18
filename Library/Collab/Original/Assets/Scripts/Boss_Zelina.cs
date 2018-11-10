using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Zelina : MonoBehaviour {
	int phase = 0;

	IEnumerator BoobiePunch() {
		float move = 0;

		while (move < 0.75f) {
			float delta = 0.75f * Time.deltaTime;
			transform.Translate (0, delta, 0);
			move += delta;
			yield return new WaitForFixedUpdate ();
		}

		move = 0;
		while (move > -4f) {
			float delta = -30f * Time.deltaTime;
			transform.Translate (0, delta, 0);
			move += delta;
			yield return new WaitForFixedUpdate ();
		}

		yield return new WaitForSeconds (0.2f);

		while (move < 0) {
			float delta =6f * Time.deltaTime;
			transform.Translate (0, delta, 0);
			move += delta;
			yield return new WaitForFixedUpdate ();
		}
	}
	/*
	[SerializeField]
	int direction = 1;
	[SerializeField]
	int space = 40;
	[SerializeField]
	float timeOut = 0.01f;
	[SerializeField]
	int count = 300;
	[SerializeField]
	float div = 170f;
	[SerializeField]
	float fac = 1;
*/
	IEnumerator SpiralSpam(GameObject particle,  int space, float timeOut, int count,float div, float fac ) {
		int rand = Random.Range (0, 2);
		int direction = 1;
		if (rand == 0)
			direction = -1;

		for(int i = 0; i < count;i++) {
			GameObject o = Instantiate(particle, transform.position, Quaternion.identity);
			o.GetComponent<Movement>().SetDirection(new Vector2(Mathf.Cos(direction * i / div * Mathf.PI * space + i * fac), Mathf.Sin(direction * i / div * Mathf.PI * space + i * fac)));
			yield return new WaitForSeconds(timeOut);
		}
	}
	IEnumerator HalfCircleAttackEmoji (GameObject emoji){
		int dir = 1;
		int rand = Random.Range (3, 10);
		for (int i = 0; i < rand; i++) {
			HalfCircleAttackHelper (emoji,  dir, 80, 35, 79, -1);
			yield return new WaitForSeconds (2.25f);
			dir *= -1;
		}
	}
	IEnumerator HalfCircleAttackStone (GameObject stone){
		
		int dir = 1;
		int rand = Random.Range (3, 10);
		for (int i = 0; i < rand; i++) {
			HalfCircleAttackHelper (stone, dir, 80, 35, 79, -1);
			yield return new WaitForSeconds (0.75f);
			dir *= -1;
		}
	}

	IEnumerator AutoAttack(GameObject damage, GameObject heart) {
		int amount = Random.Range (8, 21);
		for (int i = 0; i < amount; i++) {
			int rand = Random.Range (0, 10);
			GameObject o;
			if (rand == 0) {
				o = Instantiate (heart, transform.position, Quaternion.identity);
			} else {
				o = Instantiate (damage, transform.position, Quaternion.identity);
			}
		
			o.GetComponent<Movement> ().SetDirection (GetDirectionOntoPlayer());
			yield return new WaitForSeconds (0.3f);
		}
		yield return new WaitForSeconds (0.75f);
	}

	IEnumerator Phase0() {
		yield return new WaitForSeconds (2f);
		while (phase==0) {
			int lastRand = -1;
			int rand = -1;
			while (lastRand == rand) {
				rand = Random.Range (0, 7);
			}
			lastRand = rand;
			if (rand != 0) {
				yield return new WaitForSeconds (1f);
			}


			switch (rand) {
			case 0:
				CircleAttack(heart,120,40,1);
				break;
			case 1:
				yield return StartCoroutine (HalfCircleAttackEmoji (emoji));
				break;
			case 4:
				yield return StartCoroutine (HalfCircleAttackStone (stone));
				break;
			case 2: 
				yield return StartCoroutine (SpiralSpam (stone, 80, 0.025f, 300, 40, 1));
				break;
			case 5: 
				yield return StartCoroutine (SpiralSpam (emoji , 80, 0.1f, 75, 40, 1));
				break;
			case 3:
				yield return StartCoroutine (SpiralSpam (stone , 80, 0.05f, 100, 79, -1));
				break;
			case 6:
				yield return StartCoroutine (AutoAttack (stone_2, heart_uwu));
				break;
			default:
				Debug.Log ("Defaultcase; Zelina phase 1");
				break;
			}
		}
		StartCoroutine (Phase1 ());
	}

	IEnumerator Phase1() {
		yield return new WaitForSeconds (2f);
		Vector2 spawnPoint;
		for (int i = 0; i < bitchSquad.Length; i++) {

			spawnPoint.x = Random.Range (0f, 1f);
			spawnPoint.y = Random.Range (0f, 1f);

			GameObject o = Instantiate (bitchSquad [i], spawnPoint, Quaternion.identity);
		}

		
	}

	public void setPhase(int phase) {
		this.phase = phase;
	}

	[SerializeField]
	GameObject stone;
	[SerializeField]
	GameObject emoji;
	[SerializeField]
	GameObject heart;
	[SerializeField]
	GameObject heart_uwu;
	[SerializeField]
	GameObject stone_2;
	[SerializeField]
	GameObject[] bitchSquad;

	void Start() {
		//StartCoroutine (BoobiePunch());
		StartCoroutine(Phase0());

		// SpiralSpam()
	}

	void Update() {
		
	}
	public void CircleAttack(GameObject particle, int count,float div, float fac ) {
		int direction = 1;
		int space = 360 / count;

		for( int i = 0; i<count ;i++){
			GameObject o = Instantiate (particle, transform.position, Quaternion.identity);
			o.GetComponent<Movement> ().SetDirection (new Vector2 (Mathf.Cos (direction * i / div * Mathf.PI * space ), Mathf.Sin (direction * i / div * Mathf.PI * space 	)));
		}
	}	

	public void HalfCircleAttackHelper(GameObject particle, int direction, int space, int count,float div, float fac ) {
		for (int i = 0; i < count; i++) {
			GameObject o = Instantiate (particle, transform.position, Quaternion.identity);
			o.GetComponent<Movement> ().SetDirection (new Vector2 (Mathf.Cos (direction * i / div * Mathf.PI * space ), Mathf.Sin (direction * i / div * Mathf.PI * space 	)));
		}
	}
	protected Vector2 GetDirectionOntoPlayer() {
		Vector3 playerPos = GameManagerBehaviour.instance.player.transform.position;
		Vector2 dir = new Vector2 (playerPos.x - transform.position.x, playerPos.y - transform.position.y);
		dir.Normalize ();
		return dir;
			}

}
