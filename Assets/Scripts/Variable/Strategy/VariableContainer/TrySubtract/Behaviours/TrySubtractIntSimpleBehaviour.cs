using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;
using Variable.Strategy;

namespace Variable.Strategy {
    public class TrySubtractIntSimpleBehaviour : ITrySubtractBehaviour<IntVariable> {
        public bool TrySubtract(IntVariable variable, IntVariable value) {
            if (variable.Value < value)
                return false;
            variable.Value -= value;
            return true;
        }
    }
}