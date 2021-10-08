using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.Data {
    public class HexData {
        public VectorHexagonal hexagonalPosition;
        public HexData() {
            hexagonalPosition = new VectorHexagonal();
        }
    }
}