using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Industry", menuName = "SO/Industry/Industry")]
public class Industry : SerializedScriptableObject
{
    public string _name;
    public string description;
    public Sprite sprite;
    public List<Company> companies;
}
