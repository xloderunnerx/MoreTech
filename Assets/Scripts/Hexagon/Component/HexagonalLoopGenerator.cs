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

        public List<Hex> Loop { get => data.loop; set => data.loop = value; }

        private void Awake() {
            Init();
        }

        private void Start() {
            
        }

        private void Update() {
            
        }

        public void Init() {
            if (data == null)
                data = new HexagonalLoopGeneratorData();
        }

        public void GenerateVoid() {
            ClearDestroy();
            data.loop = Generate();
        }

        public List<Hex> Generate() {
            var result = new List<Hex>();
            result = settings.hexagonalLoopGenerationBehaviour.Generate(diContainer, data, settings);
            return result;
        }

        public void ClearDestroy() {
            data.loop.ForEach(h => Destroy(h.gameObject));
            data.loop.Clear();
        }
    }
}