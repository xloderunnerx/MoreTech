using DG.Tweening;
using Hexagon.Component;
using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] protected TurnsController turnsController;
    [Inject] protected HexagonalLoopGenerator hexagonalLoopGenerator;
    public float originalScale;
    public Hex currentHex;
    public int signOffset;


    public virtual void StartSteps(int count, Action onStepsCompleted) {
        currentHex.players.Remove(this);
        var meshRenderer = GetComponent<MeshRenderer>();
        var loop = hexagonalLoopGenerator.Loop;
        var sequence = DOTween.Sequence().SetDelay(0.5f);
        for(int i = 0; i < count; i++) {
            currentHex = GetNext(loop, currentHex);
            var storedRotation = transform.rotation;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            sequence.Append(transform.DOJump(currentHex.transform.position + new Vector3(signOffset * meshRenderer.bounds.size.x * 0.75f, meshRenderer.bounds.size.y / 2, signOffset * meshRenderer.bounds.size.z * 0.75f), 0.5f, 1, 0.5f));
            
            transform.rotation = storedRotation;
        }
        sequence.OnComplete(() => onStepsCompleted?.Invoke());
        currentHex.players.Add(this);
    }

    public Hex GetNext(List<Hex> loop, Hex current) {
        if (loop.IndexOf(current) == loop.Count - 1)
            return loop.FirstOrDefault();
        return loop[loop.IndexOf(current) + 1];
    }
}
