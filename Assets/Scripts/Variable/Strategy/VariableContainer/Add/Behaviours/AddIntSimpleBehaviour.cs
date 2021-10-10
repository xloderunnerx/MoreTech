using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;
using Variable.Strategy;

namespace Variable.Strategy {
    public class AddIntSimpleBehaviour : IAddBehaviour<IntVariable> {
        public void Add(IntVariable variable, IntVariable value) {
            variable.Value += value.Value;
        }
    }
}