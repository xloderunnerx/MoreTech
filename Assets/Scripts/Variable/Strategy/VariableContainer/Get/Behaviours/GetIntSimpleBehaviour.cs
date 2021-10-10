using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;
using Variable.Strategy;

namespace Variable.Strategy {
    public class GetIntSimpleBehaviour : IGetBehaviour<IntVariable> {
        public IntVariable Get(IntVariable variable) {
            return variable;
        }
    }
}