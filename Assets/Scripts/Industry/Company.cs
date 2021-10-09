using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Company", menuName = "SO/Industry/Company")]
public class Company : SerializedScriptableObject
{
    public string _name;
    public Sprite icon;
    public bool haveStocks;
    public int stocksPrice;
    public bool haveBonds;
    public int bondsPrice;
    public int bondsPassive;
}
