using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public float maxVal;
    public float minVal;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = maxVal;
        slider.minValue = minVal;
    }

    // Update is called once per frame
    void Update()
    {
        
        slider.value = value;
    }
}
