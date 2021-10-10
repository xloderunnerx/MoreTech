using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InGameEvent", menuName = "SO/Test")] 

public class InGameEvent : ScriptableObject {
    
    public string description;
    public int activationTimer;
    public Company company;
    public int value;

}
