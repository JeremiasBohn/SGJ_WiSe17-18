using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLinearThroughPlayerSpace : Movement {
    void Start() {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector2 pointInPlayerZone = Random.insideUnitCircle;
        pointInPlayerZone.x *= width * (0.4f - 0.1f);
        pointInPlayerZone.y *= height * (0.4f - 0.1f);

        direction = new Vector2(pointInPlayerZone.x - transform.position.x, pointInPlayerZone.y - transform.position.y);
        direction.Normalize();
    }
    
    void Update() {
        transform.Translate(direction.x * Time.deltaTime * movementSpeed,
               direction.y * Time.deltaTime * movementSpeed, 0);
    }
}
