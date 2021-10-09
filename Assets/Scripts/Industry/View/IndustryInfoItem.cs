using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndustryInfoItem : MonoBehaviour
{
    public Image companyImage;
    public Text companyName;
    public Text typeText;
    public Text price;

    public void Init(Company company) {
        companyImage.sprite = company.icon;
        companyName.text = company._name;
        var randomValue = Random.value;
        if(randomValue > 0.5f && company.haveBonds) {
            typeText.text = "Облигация";
            price.text = company.bondsPrice.ToString() + "B";
        }
        else {
            typeText.text = "Акция";
            price.text = company.stocksPrice.ToString() + "B";
        }
    }
}
