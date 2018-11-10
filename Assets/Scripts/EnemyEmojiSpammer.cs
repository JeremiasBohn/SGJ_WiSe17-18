using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEmojiSpammer : EnemyBase {
	int emojis = 6;

	IEnumerator SpawnEmojis(int count, Vector2 direction) {
		for (int i = 0; i < count; i++) {
			yield return new WaitForSeconds (0.2f);
			GameObject o = Instantiate (damageParticle, transform.position, Quaternion.identity);
			o.GetComponent<Movement> ().SetDirection (direction);
		}
	}
	protected override void Start() {
		base.Start();
		GetComponent<MovementCircle> ().startAngle = Mathf.PI;
	}

	protected override void SpawnParticle() {
		StartCoroutine (SpawnEmojis (emojis, GetDirectionOntoPlayer()));
	}
}
