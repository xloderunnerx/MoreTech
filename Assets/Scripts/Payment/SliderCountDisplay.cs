using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCountDisplay : MonoBehaviour
{
    public Slider slider;
    public Text text;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = ((int)(slider.value * 10)).ToString();
    }
}
