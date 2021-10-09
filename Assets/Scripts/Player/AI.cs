using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AI : Player
{
    public override void StartSteps(int count, Action onStepsCompleted) {
        base.StartSteps(count, onStepsCompleted);
    }
}
