using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCircle : Movement {
    [SerializeField]
    public float radius;

	public float startAngle;

    private float interp = 0;

    // Update is called once per frame
    void Update() {
        interp = (interp + Time.deltaTime * movementSpeed) % 1;

		Vector3 pos = new Vector3(Mathf.Cos(startAngle + interp * Mathf.PI * 2) * radius, Mathf.Sin(startAngle + interp * Mathf.PI * 2) * radius, 0);
        transform.position = pos;
    }
}
