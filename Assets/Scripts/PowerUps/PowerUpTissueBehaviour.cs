using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTissueBehaviour : PowerUpBehaviourBase {

	protected override void UpdateEffect() {
		player.Heal ();
	}

	protected override void RemoveEffect() {
	}

}
