using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSine : Movement {

    void Update()
    {
        //movement
        float hor = direction.x * Time.deltaTime * movementSpeed;
		float ver = direction.y * Time.deltaTime * movementSpeed;

        transform.Translate(hor, ver, 0);


    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "InnerBoundary")
        {
			direction.x *= -1;
			direction.y *= -1;
        }
    }
    public override void OnTriggerExit2D(Collider2D coll)
    {
		base.OnTriggerExit2D (coll);

        if (coll.tag == "OuterBoundary")
        {
			direction.x *= -1;
			direction.y *= -1;
        }
    }
}
