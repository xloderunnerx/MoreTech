using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;
using Variable.SO;
using Variable.Strategy;

[CreateAssetMenu(fileName = "VariableContainerInt", menuName = "SO/Variable/VariableContainerInt")]
public class VariableContainerInt : VariableContainer<IntVariable>
{
    [OdinSerialize] private IAddBehaviour<IntVariable> addBehaviour;
    [OdinSerialize] private ITrySubtractBehaviour<IntVariable> trySubtractBehaviour;

    public void Add(int value) {
        var variableValue = CreateInstance<IntVariable>();
        variableValue.Value = value;
        addBehaviour.Add(variable, variableValue);
    }
    public bool TrySubtract(int value) {
        var variableValue = CreateInstance<IntVariable>();
        variableValue.Value = value;
        return trySubtractBehaviour.TrySubtract(variable, variableValue);
    }
}
