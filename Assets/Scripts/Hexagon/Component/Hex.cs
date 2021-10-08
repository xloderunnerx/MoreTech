using Hexagon.Data;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.Component {
    public class Hex : SerializedMonoBehaviour {
        [OdinSerialize] private HexData data;
        public VectorHexagonal HexagonalPosition { get => data.hexagonalPosition; set => data.hexagonalPosition = value; }

        private void Awake() {
            Init();
        }
        public void Init() {
            data = new HexData();
        }

        
    }
}