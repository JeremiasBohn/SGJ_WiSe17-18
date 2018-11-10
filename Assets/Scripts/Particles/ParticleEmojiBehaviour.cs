using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmojiBehaviour : ParticleBehaviourBase {
    protected override void ExecuteEffect() {
		player.IncreaseSocializing ();
    }
}
