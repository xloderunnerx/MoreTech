using DG.Tweening;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityUtils.Variables;
using Variable.Strategy;

namespace Variable.Strategy {
    public class UpdateIntTMPSimpleBehaviour : IUpdateBehaviour<IntVariable> {
        [OdinSerialize] private TextMeshProUGUI displayTMP;

        public void Update(IntVariable variable) {
            //displayTMP.text = variable.Value.ToString();
            DOTween.To(x => displayTMP.text = ((int)x).ToString(), Convert.ToInt32(displayTMP.text), variable.Value, 0.5f);   
        }
    }
}