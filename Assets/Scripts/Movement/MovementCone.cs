using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCone : MovementLinearAtoB {
    [SerializeField]
    public float angle = 45.0f;

    [SerializeField]
    protected GameObject prefab;

	protected virtual void Start () {
		Split ();
	}

	protected void Split() {
		GameObject left = Instantiate (prefab, transform.position, Quaternion.identity);
		left.GetComponent<Movement> ().SetDirection (Rotate(direction, angle));

		GameObject right = Instantiate (prefab, transform.position, Quaternion.identity);
		right.GetComponent<Movement> ().SetDirection (Rotate(direction, -angle));
	}

	public static Vector2 Rotate(Vector2 v, float degrees) {
		float radians = degrees * Mathf.Deg2Rad;
		float sin = Mathf.Sin(radians);
		float cos = Mathf.Cos(radians);

		float tx = v.x;
		float ty = v.y;

		return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
	}
}