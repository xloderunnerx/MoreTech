using DG.Tweening;
using Hexagon.Component;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PlayersGenerator : SerializedMonoBehaviour
{
    [Inject] private DiContainer diContainer;
    [Inject] private HexagonalLoopGenerator hexagonalLoopGenerator;
    [Inject] private TurnsController turnsController;
    [OdinSerialize] private GameObject humanPrefab;
    [OdinSerialize] private GameObject aiPrefab;

    public void Generate() {
        var firstHex = hexagonalLoopGenerator.Loop.FirstOrDefault();

        var aiGameObject = diContainer.InstantiatePrefab(aiPrefab);
        var aiMeshrenderer = aiGameObject.GetComponent<MeshRenderer>();
        var aiPlayer = aiGameObject.GetComponent<Player>();
        aiPlayer.originalScale = aiGameObject.transform.localScale.x;
        aiGameObject.transform.localScale *= 0.5f;
        aiGameObject.transform.position = firstHex.transform.position + new Vector3(aiMeshrenderer.bounds.size.x * 0.75f, aiMeshrenderer.bounds.size.y / 2, aiMeshrenderer.bounds.size.z * 0.75f);
        aiGameObject.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0,360), 0));
        aiPlayer.currentHex = firstHex;
        aiPlayer.signOffset = 1;
        turnsController.ai = aiPlayer;

        var humanGameObject = diContainer.InstantiatePrefab(humanPrefab);
        var humanMeshRenderer = humanGameObject.GetComponent<MeshRenderer>();
        var humanPlayer = humanGameObject.GetComponent<Player>();
        humanPlayer.originalScale = humanGameObject.transform.localScale.x;
        humanGameObject.transform.localScale *= 0.5f;
        humanGameObject.transform.position = firstHex.transform.position + new Vector3(-humanMeshRenderer.bounds.size.x * 0.75f, humanMeshRenderer.bounds.size.y / 2, -humanMeshRenderer.bounds.size.z * 0.75f);
        humanGameObject.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        humanPlayer.currentHex = firstHex;
        humanPlayer.signOffset = -1;
        turnsController.human = humanPlayer;
        turnsController.current = humanPlayer;

        firstHex.players.Add(humanPlayer);
    }
}
