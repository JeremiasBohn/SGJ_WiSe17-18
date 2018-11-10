using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWave : Movement
{
    public Vector2 startingPoint;
    public float frequency;
    public float magnitude;
    private float radius = 1;
    private Vector3 pos;
	private float startTime;

    void Start()
    {
		startTime = Time.time;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {


		pos += new Vector3(direction.x,direction.y, 0) * Time.deltaTime * movementSpeed;
		transform.position = pos + new Vector3(-direction.y, direction.x,0) * Mathf.Sin((Time.time-startTime) * frequency) * magnitude;


    }
}
