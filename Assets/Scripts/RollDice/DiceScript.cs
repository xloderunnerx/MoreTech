using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

    static Rigidbody rigidBody;
    public static Vector3 diceVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rigidBody.velocity;

        if (Input.GetMouseButtonDown(0)) {
            DiceNumberTextScript.diceNumber = 0;
            
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            transform.position = new Vector3(0, 2, 0);
            transform.rotation = Quaternion.identity;

            rigidBody.AddForce(transform.up * 3000);
            rigidBody.AddTorque(dirX, dirY, dirZ);
        }

    }
}
