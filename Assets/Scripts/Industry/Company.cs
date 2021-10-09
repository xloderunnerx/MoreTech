using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Company", menuName = "SO/Industry/Company")]
public class Company : SerializedScriptableObject
{
    public string _name;
    public Sprite icon;
    public int stocksPrice;
    public int bondsPrice;
    public int bondsPassive;
}
