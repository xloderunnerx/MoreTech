using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndustryInfoItem : MonoBehaviour
{
    public PaymentInfo paymentInfo;
    public Company company;
    public Image companyImage;
    public Text companyName;
    public Text typeText;
    public Text price;
    public Text passive;
    public float rnd;
    public void Init(Company company) {
        this.company = company;
        companyImage.sprite = company.icon;
        companyName.text = company._name;
        rnd = Random.value;
        if(rnd > 0.5f && company.haveBonds) {
            typeText.text = "Облигация";
            price.text = company.bondsPrice.ToString() + "B";
            passive.text = "+" + company.bondsPassive.ToString();
        }
        else {
            typeText.text = "Акция";
            price.text = company.stocksPrice.ToString() + "B";
        }
    }

    public void Click() {
        paymentInfo.Init(company, rnd);
    }
}
