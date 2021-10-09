using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndustryInfoPanel : MonoBehaviour
{
    public List<IndustryInfoItem> industryInfoItems;
    public Text _name;
    public Text description;
    public void Init(Industry industry) {
        _name.text = industry._name;
        description.text = industry.description;
        if(industry.companies.Count > 0) {
            var company = industry.companies[0];
            industryInfoItems[0].Init(company);
        }
        if (industry.companies.Count > 1) {
            var company = industry.companies[1];
            industryInfoItems[1].Init(company);
        }
        if (industry.companies.Count > 2) {
            var company = industry.companies[2];
            industryInfoItems[2].Init(company);
        }
    }
}
