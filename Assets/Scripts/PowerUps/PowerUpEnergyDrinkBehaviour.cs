using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergyDrinkBehaviour : PowerUpBehaviourBase {

	protected override void UpdateEffect() {
		player.onEnergyDrink = true;
	}

	protected override void RemoveEffect() {
		player.onEnergyDrink = false;	
	}

}
