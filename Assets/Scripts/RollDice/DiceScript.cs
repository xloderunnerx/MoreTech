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
    void FixedUpdate()
    {
        diceVelocity = rigidBody.velocity;
    }

    public void RollDice() {
        DiceNumberTextScript.diceNumber = 0;

        float dirX = Random.Range(0, 100);
        float dirY = Random.Range(0, 100);
        float dirZ = Random.Range(0, 100);


        rigidBody.AddForce(Vector3.up * Random.Range(30, 50), ForceMode.Impulse);
        rigidBody.AddTorque(dirX, dirY, dirZ, ForceMode.Impulse);
        diceVelocity = rigidBody.velocity;
    }
}
