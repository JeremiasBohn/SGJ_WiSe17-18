using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStar : Movement {
	
	bool isFirst = true;
	[SerializeField]
	public float Angle = 72.0f;

	[SerializeField]
	GameObject Particle_prefab;

	private GameObject CloneLB = null;
	private GameObject CloneRB = null;
	private GameObject CloneLT = null;
	private GameObject CloneRT = null;
	private GameObject CloneT = null;

	void Start () {
		if (isFirst)
		{
			GameObject obj = Instantiate(Particle_prefab, transform.position, Quaternion.identity);

			obj.GetComponent<MovementStar>().isFirst = false;

			GameObject obj2 = Instantiate(Particle_prefab, transform.position, Quaternion.identity);

			obj2.GetComponent<MovementStar>().isFirst = false;

			GameObject obj3 = Instantiate(Particle_prefab, transform.position, Quaternion.identity);

			obj3.GetComponent<MovementStar>().isFirst = false;

			GameObject obj4 = Instantiate(Particle_prefab, transform.position, Quaternion.identity);

			obj4.GetComponent<MovementStar>().isFirst = false;


			CloneLB = obj;
			CloneRB= obj2;
			CloneLT = obj3;
			CloneRT = obj4;
		}
		this.GetComponent<MovementStar>().isFirst = false;
	}

	private float RadAngle = 0.0f;
	// Update is called once per frame
	void Update()

	{
		RadAngle = (Angle * Mathf.Deg2Rad);

		this.transform.Translate(direction.x * Time.deltaTime * movementSpeed, direction.y * Time.deltaTime * movementSpeed, 0);

		if(CloneLB != null){
			CloneLB.transform.Translate(direction.x * Time.deltaTime * movementSpeed * RadAngle, direction.y * Time.deltaTime * movementSpeed * RadAngle, 0);
		}
		if(CloneRB != null){
			CloneRB.transform.Translate(direction.x * Time.deltaTime * movementSpeed * -RadAngle, direction.y * Time.deltaTime * movementSpeed * RadAngle, 0);
		}
		if(CloneLT != null){
			CloneRB.transform.Translate(direction.x * Time.deltaTime * movementSpeed * RadAngle, direction.y * Time.deltaTime * movementSpeed * -RadAngle, 0);
		}
		if(CloneRT != null){
			CloneRB.transform.Translate(direction.x * Time.deltaTime * movementSpeed * -RadAngle, direction.y * Time.deltaTime * movementSpeed * -RadAngle, 0);
		}
}
}