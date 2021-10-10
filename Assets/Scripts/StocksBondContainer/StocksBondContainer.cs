using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StocksBondContainer : SerializedMonoBehaviour
{
    [OdinSerialize] private VariableContainerInt balance;
    public List<Bond> bonds;
    public List<Stock> stocks;
    public UnityEvent onBondsUpdated;

    private void Awake() {
        bonds = new List<Bond>();
        stocks = new List<Stock>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateBonds() {
        var resultingBond = 0;
        bonds.ForEach(b => resultingBond += b.company.bondsPassive);
        balance.Add(resultingBond);
        Debug.Log("Resulting bounds = " + resultingBond);
    }
}
