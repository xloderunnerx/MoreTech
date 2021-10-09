using Hexagon.Component;
using Hexagon.Data;
using Hexagon.SO;
using Shapes;
using Sirenix.Serialization;
using Sirenix.Utilities;
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
                    if (distanceFromCenter > circleRadius || distanceFromCenter < circleRadius - 4)
                        continue;

                    var hexGameObject = diContainer.InstantiatePrefab(hexPrefab);
                    var hexTransform = hexGameObject.transform;
                    var hexRegularPolygon = hexGameObject.GetComponent<RegularPolygon>();
                    var hexRegularPolygonSize = new Vector2(hexRegularPolygon.Radius * 1.75f, hexRegularPolygon.Radius * 1.5f);
                    var hex = hexGameObject.GetComponent<Hex>();
                    hexTransform.position = new Vector3(x * hexRegularPolygonSize.x + y * hexRegularPolygonSize.x * 0.5f - hexRegularPolygonSize.x * circleRadius * 1.5f, 0, y * hexRegularPolygonSize.y - hexRegularPolygonSize.y * circleRadius);
                    hex.HexagonalPosition = hexagonalPosition;
                    result.Add(hex);
                }
            }
            var sortedLoop = GetSortedLoop(result.Where(h => VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), h.HexagonalPosition) == circleRadius - 2).ToList(), false);
            var smartRandomizedLoop = GetSmartRandomizedLoop(result, sortedLoop);
            var smartRandomizedSortedLoop = GetSortedLoop(smartRandomizedLoop, true);
            result = result.Except(smartRandomizedSortedLoop).ToList();
            result.ForEach(h => GameObject.Destroy(h.gameObject));
            result.Clear();
            result = smartRandomizedSortedLoop;
            return result;
        }

        public List<Hex> GetSortedLoop(List<Hex> unsortedLoop, bool smartRandomizedSort) {
            var sortedLoop = new List<Hex>();
            var startHex = unsortedLoop[Random.Range(0, unsortedLoop.Count)];
            var currentHex = startHex;
            sortedLoop.Add(currentHex);
            var index = 0;
            while (index < 50) {
                index++;
                currentHex.gameObject.name = index.ToString();
                var neighbours = unsortedLoop.Except(sortedLoop).Where(h => VectorHexagonal.Distance(h.HexagonalPosition, currentHex.HexagonalPosition) == 1).ToList();

                if (neighbours.Count == 2 && smartRandomizedSort) {
                    var minRadius = neighbours.Select(h => VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), h.HexagonalPosition)).Min();
                    var closestHexToCenter = neighbours.Where(h => VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), h.HexagonalPosition) == minRadius).FirstOrDefault();
                    neighbours.Remove(closestHexToCenter);
                }
                if (neighbours.Count == 0) {
                    if (smartRandomizedSort) {
                        var startHexNeighbours = unsortedLoop.Where(h => VectorHexagonal.Distance(h.HexagonalPosition, startHex.HexagonalPosition) == 1).ToList();
                        if (startHexNeighbours.Count == 3) {
                            var minRadius = startHexNeighbours.Select(h => VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), h.HexagonalPosition)).Min();
                            var closestHexToCenter = startHexNeighbours.Where(h => VectorHexagonal.Distance(new VectorHexagonal(0, 0, 0), h.HexagonalPosition) == minRadius).FirstOrDefault();
                            sortedLoop.Remove(closestHexToCenter);
                        }
                    }
                    break;
                }
                currentHex = neighbours[Random.Range(0, neighbours.Count)];
                sortedLoop.Add(currentHex);
            }
            return sortedLoop;
        }

        public List<Hex> GetSmartRandomizedLoop(List<Hex> bigLoop, List<Hex> sortedLoop) {
            var sortedLoopRadius = VectorHexagonal.Distance(sortedLoop.FirstOrDefault().HexagonalPosition, new VectorHexagonal(0, 0, 0));
            var newHexes = new List<Hex>();
            var result = new List<Hex>();
            sortedLoop.ForEach(sh => {
                if (sortedLoop.IndexOf(sh) == 0)
                    return;
                if (sortedLoop.IndexOf(sh) == sortedLoop.Count - 1)
                    return;
                var previousSortedHex = sortedLoop[sortedLoop.IndexOf(sh) - 1];
                var nextSortedHex = sortedLoop[sortedLoop.IndexOf(sh) + 1];
                var previousSortedHexNeighbours = bigLoop.Where(h => VectorHexagonal.Distance(h.HexagonalPosition, previousSortedHex.HexagonalPosition) <= 1).ToList();
                var allCurrentSortedHexNeighbours = bigLoop.Except(previousSortedHexNeighbours).Where(h => VectorHexagonal.Distance(h.HexagonalPosition, sh.HexagonalPosition) == 1).ToList();
                allCurrentSortedHexNeighbours.Remove(nextSortedHex);
                var neighbour = allCurrentSortedHexNeighbours[Random.Range(0, allCurrentSortedHexNeighbours.Count)];
                newHexes.Add(neighbour);

            });

            var outerHexList = newHexes.Where(h => VectorHexagonal.Distance(h.HexagonalPosition, new VectorHexagonal(0, 0, 0)) > sortedLoopRadius).ToList();
            newHexes = newHexes.Except(outerHexList).ToList();

            result.AddRange(newHexes);

            sortedLoop.ForEach(sh => {
                var neighbours = bigLoop.Where(h => VectorHexagonal.Distance(h.HexagonalPosition, new VectorHexagonal(0, 0, 0)) < sortedLoopRadius).Where(h => VectorHexagonal.Distance(h.HexagonalPosition, sh.HexagonalPosition) == 1).ToList();
                neighbours = neighbours.Except(newHexes).ToList();
                if (neighbours.Count > 0) {
                    result.Add(sh);
                }
            });
            return result;
        }
    }
}