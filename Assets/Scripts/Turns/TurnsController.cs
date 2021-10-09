using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnsController : MonoBehaviour
{
    public DiceCheckZoneScript diceCheckZoneScript;
    public Player current;
    public Player human;
    public Player ai;

    public UnityEvent OnPlayerTurnEnd;
    public UnityEvent OnAITurnEnd;

    public void StartCurrentTurn() {
        var stepsCount = diceCheckZoneScript.diceNumber;
        current.StartSteps(stepsCount);
    }

    public void EndPlayerTurn() {
        current = ai;
        OnPlayerTurnEnd?.Invoke();
    }

    public void EndAITurn() {
        current = human;
        OnAITurnEnd?.Invoke();
    }
}
