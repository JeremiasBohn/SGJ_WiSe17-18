using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTeleport : Movement {
    float timer;
    [SerializeField] public float teleportAfterSeconds;

    void Start () {
        timer = 0;		
	}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > teleportAfterSeconds)
        {
            float randomX = 0.0f, randomY = 0.0f;
            while (randomX < 4.0f && randomY < 2.25 && randomY > -2.25f && randomX > -4.0f)
            {
                randomX = Random.Range(-8.5f, 8.5f);
           
                randomY = Random.Range(-4.25f, 4.25f);

              
            }
            transform.position=new Vector3(randomX, randomY, 0);
            timer = 0.0f;
        }
    }

   
}
