using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeaveFall : Movement {

	[SerializeField] public float distancePerSwing;
	private float startingPoint;
	private bool goLeft;
	public float magnitude;
	private float counter;
	private bool counterDir = true;
	Vector3 pos;

	void Start() {
		pos = transform.position;
		direction = new Vector3 (1,-1 , 0);
//		startingPoint=transform.position;
	}

	// Update is called once per frame
	void Update () {

		//	if (transform.position.x >= startingPoint. + distancePerSwing || transform.position.x <= startingPointX) {
		////		goLeft = !goLeft;
		//	}

		//	float hor = 0;
		//	if (goLeft) {

		//	pos += new Vector3(Mathf.Sin(counter*Time.deltaTime)*movementSpeed,Mathf.Cos(counter*Time.deltaTime*2*Mathf.PI)*Time.deltaTime*movementSpeed*-0.5f*Mathf.PI,0);
		//Debug.Log(transform.position.y);
		counter = (counter + Time.deltaTime) % (2 * Mathf.PI);
		Vector3 pos1 = new Vector3 (pos.x + Mathf.Sin (counter) *2.4f, transform.position.y - 0.5f * Time.deltaTime, 0);
		transform.position = pos1;
	}
		//pos += new Vector3(direction.x,direction.y, 0) * Time.deltaTime * (movementSpeed* ((Mathf.Sin(Time.time * distancePerSwing*Mathf.PI))+0.01f)*2);
		//transform.position = pos +new Vector3(direction.x, direction.y* magnitude,0) * (Mathf.Sin(Time.time * distancePerSwing*Mathf.PI)) ;
			//hor = Mathf.Sin(Time.deltaTime * movementSpeed);
	//	}
	//	else {
	//		hor = -Mathf.Sin(Time.deltaTime * movementSpeed);
	//	}
	//	float ver = -Time.deltaTime * movementSpeed/8;
	//	transform.Translate(hor, ver, 0);
		

}
