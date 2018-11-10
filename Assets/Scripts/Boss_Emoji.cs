using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Emoji : MonoBehaviour {
	int phase = 0;

	IEnumerator SpiralSpam(GameObject particle,  int space, float timeOut, int count,float div, float fac, int direction ) {
		int rand = Random.Range (0, 2);
		if(direction == 0){
		direction = 1;
		if (rand == 0)
				direction = -1;}

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
				yield return StartCoroutine (SpiralSpam (stone, 80, 0.025f, 300, 40, 1,0));
				break;
			case 5: 
				yield return StartCoroutine (SpiralSpam (emoji , 80, 0.1f, 75, 40, 1,0));
				break;
			case 3:
				yield return StartCoroutine (SpiralSpam (stone , 80, 0.05f, 100, 79, -1,1));
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
		this.GetComponent<SpriteRenderer> ().sprite = blushedFace;
		Vector2 spawnPoint;

		for (int i = 0; i < bitchSquad.Length; i++) {

			spawnPoint.x = 0f;
			spawnPoint.y = 0f;
			while (spawnPoint.x > -1.25 && spawnPoint.x < 1.25 && spawnPoint.y > -1.75 && spawnPoint.y < 1.75) {
				spawnPoint.x = Random.Range (-8f, 8f);
				spawnPoint.y = Random.Range (-4.25f, 4.25f);
			}

			GameObject o = Instantiate (bitchSquad [i], spawnPoint, Quaternion.identity);
		}

		while (true) {
			
				int rand = Random.Range (0, 3);
				GameObject o;
				if (rand == 0) {
					o = Instantiate (heart, transform.position, Quaternion.identity);
				} else {
					o = Instantiate (kiss, transform.position, Quaternion.identity);
				}

			o.GetComponent<Movement> ().SetDirection (Random2Ddirection());
				yield return new WaitForSeconds (0.3f);
			}


		
	}

	public void setPhase(int phase) {
		this.phase = phase;
	}
	public int getPhase() {
		return phase;
	}

	[SerializeField]
	GameObject stone;
	[SerializeField]
	GameObject emoji;
	[SerializeField]
	GameObject kiss;
	[SerializeField]
	GameObject heart;
	[SerializeField]
	GameObject heart_uwu;
	[SerializeField]
	GameObject stone_2;
	[SerializeField]
	GameObject[] bitchSquad;
	[SerializeField]
	Sprite blushedFace;

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

	public Vector2 Random2Ddirection(){
		float x = 0f;
		float y = 0f;
		while(x==0 && y == 0){
			x =Random.Range (-1f,1f);
			y =Random.Range (-1f,1f);
		}
		return new Vector2 (x, y);
	}

}
