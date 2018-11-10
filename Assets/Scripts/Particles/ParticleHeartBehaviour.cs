using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHeartBehaviour : ParticleBehaviourBase {
    protected override void ExecuteEffect() {
        GameManagerBehaviour.instance.increaseLevelProgress();
    }
}
