using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;

namespace Variable.Component {
    public class VariableDisplayInt : VariableDisplay<IntVariable>, IDisposable {
       

        private void Awake() {
            OnChange(variableContainer.Get().Value);
            variableContainer.Get().OnChange += OnChange;
        }

        private void OnChange(int value) {
            var variableValue = ScriptableObject.CreateInstance<IntVariable>();
            variableValue.Value = value;
            updateBehaviour.Update(variableValue);
        }
        private void OnDestroy()
        {
            Dispose();
        }

        public void Dispose()
        {
            variableContainer.Get().OnChange -= OnChange;
        }
    }
}