using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IndustryList", menuName = "SO/Industry/IndustryList")]
public class IndustryList : SerializedScriptableObject
{
    [OdinSerialize] private List<Industry> industries;

    public List<Industry> Industries { get => industries; set => industries = value; }
}
