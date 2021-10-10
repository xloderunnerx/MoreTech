using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Variable.Strategy {
    public interface IUpdateBehaviour<T> {
        public void Update(T variable);
    }
}