using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLinearAtoB : Movement {
    void Update() {
        transform.Translate(direction.x * Time.deltaTime * movementSpeed,
               direction.y * Time.deltaTime * movementSpeed, 0);
    }
}
