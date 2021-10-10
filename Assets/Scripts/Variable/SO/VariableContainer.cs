using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variable.Strategy;

namespace Variable.SO {
    public class VariableContainer<T> : SerializedScriptableObject {
        [OdinSerialize] protected T variable;        
        [OdinSerialize] protected IGetBehaviour<T> getBehaviour;

        public virtual T Get() => getBehaviour.Get(variable);
    }
}