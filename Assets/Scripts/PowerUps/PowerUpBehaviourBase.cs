using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBehaviourBase : MonoBehaviour {
    protected bool moveMode;
    protected PlayerBehaviour player;

    [SerializeField]
    float effectDuration;

    float durationLeft;

    private void Start() {
        moveMode = true;
    }

    private void Update() {
        if (!moveMode) {
            // we' re attached to a player and gotta do sth 
            UpdateEffect();
            durationLeft -= Time.deltaTime;

            if (durationLeft <= 0) {
                RemoveEffect();
                Destroy(gameObject);
            }
        }
    }

    protected abstract void UpdateEffect();

    protected abstract void RemoveEffect();

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            moveMode = false;
            durationLeft = effectDuration;
            // hide visually
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.GetComponent<Movement>().enabled = false;

            this.player = collision.gameObject.GetComponent<PlayerBehaviour>();
        }
    }
}
