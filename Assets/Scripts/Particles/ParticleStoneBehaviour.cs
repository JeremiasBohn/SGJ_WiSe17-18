using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStoneBehaviour : ParticleBehaviourBase {
    protected override void ExecuteEffect() {
        player.OnHit();
    }
}
