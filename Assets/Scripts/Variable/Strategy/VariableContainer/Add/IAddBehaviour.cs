using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Variable.Strategy {
    public interface IAddBehaviour<T> {
        public void Add(T variable, T value);
    }
}