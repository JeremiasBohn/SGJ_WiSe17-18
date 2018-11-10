using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Porting : EnemyBase {
	

	IEnumerator Crossfire( Vector2 direction) {
		Vector3 old_pos = transform.position;
		while(true){
			if (old_pos != transform.position) {
				old_pos = transform.position;
				yield return new WaitForSeconds (0.8f);
			}
			for (int i = 0; i < 4; i++) {
				
				switch (i) {
				case 0:
					direction = new Vector2 (1, 0);
					break;
				case 1:
					direction = new Vector2 (0, 1);
					break;
				case 2:
					direction = new Vector2 (-1, 0);
					break;
				case 3:
					direction = new Vector2 (0, -1);
					break;
				}

				GameObject o = Instantiate (damageParticle, transform.position, Quaternion.identity);
				o.GetComponent<Movement> ().SetDirection (direction);
				yield return new WaitForSeconds (0.2f);
			}

		}
	}
	protected override void Start() {
		base.Start();
	//	base.SetMovement(GetComponent<Movement>());
	//	base.SetMovementDirection(new Vector2(1,0));
	//	base.SetStartposition(transform.position);
		base.SetMoveIntoViewMode (false); //doesnt work for some reason so i set moveIntoView to public
		//base.moveIntoViewMode = false;


		Vector3 pos = Vector3.right;
		StartCoroutine (Crossfire (new Vector2(pos.x , pos.y)));
	}

	protected override void SpawnParticle() {
		{}
	}
}
