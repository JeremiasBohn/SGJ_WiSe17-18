using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParticleBehaviourBase : MonoBehaviour {
    protected PlayerBehaviour player;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            player = collision.gameObject.GetComponent<PlayerBehaviour>();

			if((!player.onEnergyDrink) || GetComponent<ParticleHeartBehaviour>() != null){
				ExecuteEffect();
			}
            Destroy(gameObject);
        }
    }

    protected abstract void ExecuteEffect();
}
