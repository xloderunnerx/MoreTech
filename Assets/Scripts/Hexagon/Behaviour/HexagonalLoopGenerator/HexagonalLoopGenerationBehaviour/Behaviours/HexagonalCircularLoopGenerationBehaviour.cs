using Hexagon.Component;
using Hexagon.Data;
using Hexagon.SO;
using Shapes;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Hexagon.Behaviour {
    public class HexagonalCircularLoopGenerationBehaviour : IHexagonalLoopGenerationBehaviour {
        [OdinSerialize] private GameObject hexPrefab;
        [OdinSerialize] private int circleRadius;
        public List<Hex> Generate(DiContainer diContainer, HexagonalLoopGeneratorData data, HexagonalLoopGeneratorSettings settings) {
            var result = new List<Hex>();
            var oddRadius = circleRadius * 2 + 1;
            for (int y = 0; y < oddRadius; y++) {
                for (int x = 0; x < oddRadius; x++) {
                    var hexagonalPosition = new VectorHexagonal(x - circleRadius, y - circleRadius, -x - y + circleRadius * 2);
                    var distanceFromCenter = VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), hexagonalPosition);
                    if (distanceFromCenter > circleRadius || distanceFromCenter < circleRadius)
                        continue;

                    var hexGameObject = diContainer.InstantiatePrefab(hexPrefab);
                    var hexTransform = hexGameObject.transform;
                    var hexRegularPolygon = hexGameObject.GetComponent<RegularPolygon>();
                    var hexRegularPolygonSize = new Vector2(hexRegularPolygon.Radius * 1.75f, hexRegularPolygon.Radius * 1.5f);
                    var hex = hexGameObject.GetComponent<Hex>();
                    hexTransform.position = new Vector3(x * hexRegularPolygonSize.x + y * hexRegularPolygonSize.x * 0.5f, y * hexRegularPolygonSize.y, 0);
                    hex.HexagonalPosition = hexagonalPosition;
                    result.Add(hex);
                }
            }
            return result;
        }
    }
}