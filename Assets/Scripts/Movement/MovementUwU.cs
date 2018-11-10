using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUwU : Movement {

    public Vector2 startingPoint;
    public float frequency;
    public float magnitude;
    private float radius=1;
    private Vector3 pos;

    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

		pos += new Vector3(direction.x,direction.y, 0) * Time.deltaTime * (movementSpeed* (Mathf.Abs(Mathf.Sin(Time.time * frequency))+0.01f)*2);
		transform.position = pos +new Vector3(-direction.y, direction.x,0) * Mathf.Abs(Mathf.Sin(Time.time * frequency)) * magnitude;


    }
}
