using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarLast : MonoBehaviour
{
    public float progress = 1.0f;
    public Image img;

    void Update()
    {
        if(img != null)
        {
            img.fillAmount = progress;
        }
        
    }
}
