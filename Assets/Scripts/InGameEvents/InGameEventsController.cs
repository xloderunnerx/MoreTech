using Sirenix.Utilities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class InGameEventsController : MonoBehaviour
{
    public InGameEventsList inGameEventsList;
    public List<PlannedEvent> plannedEventsList;
    public JournalViewScript journalViewScript;

    private void Awake()
    {
        plannedEventsList = new List<PlannedEvent>();
    }

    public void addPlannedEvent() {

        

        var inGameEventer = inGameEventsList.list[Random.Range(0, inGameEventsList.list.Count)];

        journalViewScript.sendDescription(inGameEventer.description);
        journalViewScript.gameObject.SetActive(true);

        plannedEventsList.Add(new PlannedEvent(inGameEventer.description,
                                               inGameEventer.activationTimer,
                                               inGameEventer.company,
                                               inGameEventer.value));
    }

    public void decreaseActivationTimer()
    {
        plannedEventsList.ForEach(item => { item.activationTimer -= 1; });

        plannedEventsList.Where(item => item.activationTimer <= 0).ToList().ForEach(item => {
            item.company.stocksPrice += item.value;
        });

        plannedEventsList.Where(item => item.activationTimer <= 0).ForEach(item => { plannedEventsList.Remove(item); });
    }

    public void showInfoPanel()
    {
        
    }

}

public class PlannedEvent {

    public string description;
    public int activationTimer;
    public Company company;
    public int value;

    public PlannedEvent(string description, int activationTimer, Company company, int value)
    {
        this.description = description;
        this.activationTimer = activationTimer;
        this.company = company;
        this.value = value;
    }

}