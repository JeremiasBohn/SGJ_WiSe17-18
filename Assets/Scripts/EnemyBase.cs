using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    [SerializeField]
    Vector3 targetPos;

    Vector3 startPosition;

	bool moveIntoViewMode;
    float moveIntoMovementSpeed = 0.5f;

    float interp = 0;

    Movement movement;

    [SerializeField]
    int heartsFraction = 10; // out of 100%
    [SerializeField]
    float shootingCooldown = 0.05f;

    [SerializeField]
    protected GameObject heartParticle, damageParticle;

    float currentCooldown;

	protected virtual void Start() {
        movement = GetComponent<Movement>();
		movement.SetDirection (new Vector2(1,0));
        startPosition = transform.position;
		moveIntoViewMode = true;

    }

	void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player")) {
			GameManagerBehaviour.instance.player.IncreaseSocializing (5);
		}
	}

    void Update() {
        if (moveIntoViewMode) {
            interp += (Time.deltaTime * moveIntoMovementSpeed);
            transform.position = Vector3.Lerp(startPosition, targetPos, interp);

            if (interp >= 1) {
                moveIntoViewMode = false;
                movement.enabled = true;
                currentCooldown = shootingCooldown;
            }
        } else {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0) {
				SpawnParticle ();

				currentCooldown = shootingCooldown;
            }
        }
    }

	protected Vector2 GetDirectionOntoPlayer() {
		Vector3 playerPos = GameManagerBehaviour.instance.player.transform.position;
		Vector2 dir = new Vector2 (playerPos.x - transform.position.x, playerPos.y - transform.position.y);
		dir.Normalize ();
		return dir;
	}

	protected virtual void SpawnParticle() {
		GameObject obj = null;
		if (Random.Range (0, 100) > heartsFraction) {
			obj = Instantiate (damageParticle, transform.position, Quaternion.identity);
		} else {
			obj = Instantiate (heartParticle, transform.position, Quaternion.identity);
		}

		obj.GetComponent<Movement> ().SetDirection (GetDirectionOntoPlayer());
	}
	public void SetMoveIntoViewMode(bool boolean){
		moveIntoViewMode = boolean;
	}
}
