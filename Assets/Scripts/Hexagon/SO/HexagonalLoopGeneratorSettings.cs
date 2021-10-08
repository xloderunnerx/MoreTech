using Hexagon.Behaviour;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexagon.SO {
    [CreateAssetMenu(fileName = "HexagonalLoopGeneratorSettings", menuName = "SO/Hexagon/HexagonalLoopGeneratorSettings")]
    public class HexagonalLoopGeneratorSettings : SerializedScriptableObject {
        [OdinSerialize] public IHexagonalLoopGenerationBehaviour hexagonalLoopGenerationBehaviour;
    }
}