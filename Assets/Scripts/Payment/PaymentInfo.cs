using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PaymentInfo : MonoBehaviour {
    public VariableContainerInt balance;
    public Company company;
    public Text price;
    public Slider slider;
    public int sliderMultiplier;
    public float rnd;
    public UnityEvent onPay;
    public StocksBondContainer stocksBondContainer;

    public void Init(Company company, float rnd) {
        this.rnd = rnd;
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(SliderChanged);
        this.company = company;
        SliderChanged(0);
    }

    public void SliderChanged(float value) {
        sliderMultiplier = ((int)(value * 10));
        if (rnd > 0.5f && company.haveBonds) {
            price.text = (sliderMultiplier * company.bondsPrice).ToString();
        }
        else {
            price.text = (sliderMultiplier * company.stocksPrice).ToString();
        }
    }

    public void Pay() {
        var resultPrice = 0;
        if (rnd > 0.5f && company.haveBonds) {
            resultPrice = (sliderMultiplier * company.bondsPrice);
        }
        else {
            resultPrice = (sliderMultiplier * company.stocksPrice);
        }
        if (balance.Get() < resultPrice)
            return;
        balance.Add(-resultPrice);
        if (rnd > 0.5f && company.haveBonds) {
            for (int i = 0; i < sliderMultiplier; i++)
                stocksBondContainer.bonds.Add(new Bond(company));
        }
        else {
            for (int i = 0; i < sliderMultiplier; i++)
                stocksBondContainer.stocks.Add(new Stock(company));
        }
        onPay?.Invoke();
    }
}
