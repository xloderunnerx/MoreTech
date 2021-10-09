using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AI : Player
{
    public override void StartSteps(int count) {
        base.StartSteps(count);
        turnsController.EndAITurn();
    }
}
