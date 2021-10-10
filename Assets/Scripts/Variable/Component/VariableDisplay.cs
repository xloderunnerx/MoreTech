using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variable.SO;
using Variable.Strategy;

namespace Variable.Component {
    public class VariableDisplay<T> : SerializedMonoBehaviour {
        [OdinSerialize] protected VariableContainer<T> variableContainer;
        [OdinSerialize] protected IUpdateBehaviour<T> updateBehaviour;

        public virtual void UpdateDisplay() {
            updateBehaviour.Update(variableContainer.Get());
        }
    }
}