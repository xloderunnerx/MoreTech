using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class AspectChanger : MonoBehaviour
{
   public void ChangeAspect() {
        Screen.orientation = ScreenOrientation.Landscape;
    }
}
