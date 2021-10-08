using Hexagon.Component;
using Hexagon.Data;
using Hexagon.SO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Hexagon.Behaviour {
    public interface IHexagonalLoopGenerationBehaviour {
        public List<Hex> Generate(DiContainer diContainer, HexagonalLoopGeneratorData data, HexagonalLoopGeneratorSettings settings);
    }
}