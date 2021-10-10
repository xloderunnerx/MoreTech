using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using System.Threading.Tasks;

public class Entry : SerializedMonoBehaviour {

    [OdinSerialize] private List<Action> onAwake;
    [OdinSerialize] private List<Action> onStart;

    public static Firebase.FirebaseApp app;
    private bool firebaseInitialized;

    private void Awake() {
        onAwake.ForEach(a => a?.Invoke());
    }

    void Start() {
        onStart.ForEach(a => a?.Invoke());
        this.InitializeFirebaseComponents();
    }

    private void InitializeFirebaseComponents()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        Firebase.AppOptions ops = new Firebase.AppOptions();
        app = Firebase.FirebaseApp.Create(ops);

        Firebase.Analytics.FirebaseAnalytics
         .LogEvent("Entry");
    }


    void Update() {

    }
}
