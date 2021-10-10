using ModestTree.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class TurnsController : MonoBehaviour {
    public IndustryInfoPanel industryInfoPanel;
    public DiceCheckZoneScript diceCheckZoneScript;
    public Player current;
    public Player human;
    public Player ai;

    public UnityEvent OnPlayerTurnEnd;
    public UnityEvent OnAITurnEnd;
    public UnityEvent OnPlayerStepsOver;
    public UnityEvent OnAIStepsOver;

    public void StartCurrentTurn() {
        var stepsCount = diceCheckZoneScript.diceNumber;
        current.StartSteps(stepsCount, () => {
            if (current == human) {
                OnPlayerStepsOver?.Invoke();
                industryInfoPanel.Init(human.currentHex.industry);
                Debug.Log("Player steps over");
            }
            else {
                OnAIStepsOver?.Invoke();
                Debug.Log("AI steps over");
                EndAITurn();
            }
        });
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
