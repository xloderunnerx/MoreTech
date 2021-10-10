using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variable.Strategy {
    public interface IGetBehaviour<T> {
        public T Get(T variable);
    }
}