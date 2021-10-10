using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variable.Strategy {
    public interface ITrySubtractBehaviour<T> {
        public bool TrySubtract(T variable, T value);
    }
}