using Hexagon.Data;
using Hexagon.SO;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Hexagon.Component {
    public class HexagonalLoopGenerator : SerializedMonoBehaviour {
        [Inject] private DiContainer diContainer;
        [OdinSerialize] private HexagonalLoopGeneratorSettings settings;
        [OdinSerialize] private HexagonalLoopGeneratorData data;

        private void Awake() {
            Init();
        }

        private void Start() {
            
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                data.loop = Generate();
        }

        public void Init() {
            if (data == null)
                data = new HexagonalLoopGeneratorData();
        }

        public List<Hex> Generate() {
            var result = new List<Hex>();
            result = settings.hexagonalLoopGenerationBehaviour.Generate(diContainer, data, settings);
            return result;
        }
    }
}