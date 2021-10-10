using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalViewScript : MonoBehaviour
{
    public Text descriptionText;
    public Button closeButton;

    public void sendDescription(string description) {
        descriptionText.text = description;    
    }

}
