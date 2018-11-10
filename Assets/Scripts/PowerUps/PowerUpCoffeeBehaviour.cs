using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoffeeBehaviour : PowerUpBehaviourBase {

    
    protected override void UpdateEffect() {

        player.onCoffee = true;
        player.movementSpeed = 2 * PlayerBehaviour.defaultMovementSpeed;
    }

    protected override void RemoveEffect() {
        player.onCoffee = false;
        player.movementSpeed = PlayerBehaviour.defaultMovementSpeed;
    }
}
