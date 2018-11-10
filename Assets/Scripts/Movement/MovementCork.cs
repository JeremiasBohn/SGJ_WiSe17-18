using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCork : Movement {
    [SerializeField]
    public float radius;

    private float interp = 0;

	private Vector2 linePos = new Vector2();

	void Start() {
		linePos.x = transform.position.x;
		linePos.y= transform.position.y;
	}

    // Update is called once per frame
    void Update() {
        interp = (interp + Time.deltaTime * movementSpeed*0.5f) % 1;

		linePos.x += direction.x * movementSpeed * Time.deltaTime;
		linePos.y += direction.y * movementSpeed * Time.deltaTime;

		transform.localRotation = Quaternion.Euler (0, 0,transform.localEulerAngles.z -movementSpeed);

		Vector3 pos = new Vector3(Mathf.Cos(interp * Mathf.PI * 2) * radius + linePos.x, 
			Mathf.Sin(interp * Mathf.PI * 2) * radius + linePos.y, 0);
        transform.position = pos;
    }
}
