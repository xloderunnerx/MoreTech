using Hexagon.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.Data {
    public class HexagonalLoopGeneratorData {
        public List<Hex> loop;
        public HexagonalLoopGeneratorData() {
            loop = new List<Hex>();
        }
    }
}