using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : SerializedMonoBehaviour {
    [OdinSerialize] private List<Action> onAwake;
    [OdinSerialize] private List<Action> onStart;
    
    private void Awake() {
        onAwake.ForEach(a => a?.Invoke());
    }

    void Start() {
        onStart.ForEach(a => a?.Invoke());
    }


    void Update() {

    }
}
