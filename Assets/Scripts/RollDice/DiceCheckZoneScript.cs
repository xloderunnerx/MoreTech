using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityUtils;

public class DiceCheckZoneScript : MonoBehaviour
{
    public GameObject dice;
    Vector3 diceVelocity;
    public int diceNumber;
    public bool settled;
    public int waitFrames;
    public UnityEvent onDiceSettled;

    private void Start() {
        waitFrames = 60;
        settled = true;
    }

    private void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    private void OnTriggerStay(Collider other)
    {
        waitFrames--;
        if (waitFrames > 0)
            return;
        if (settled)
            return;
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f) {
            settled = true;
            var maxY = dice.GetChildren().ToList().Select(c => c.transform.position.y).Max();
            var maxDiceSide = dice.GetChildren().ToList().Where(c => c.transform.position.y == maxY).FirstOrDefault();
            diceNumber = maxDiceSide.GetComponent<DiceSide>().value;
            onDiceSettled?.Invoke();
            Debug.Log("Settled = " + maxDiceSide.gameObject.name);
        }        
    }

    public void ResetSettled() {
        settled = false;
        waitFrames = 60;
    }
}
