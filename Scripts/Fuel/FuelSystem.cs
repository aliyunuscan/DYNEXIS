using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    public float consumeRate = 10.0f;
    public float maxFuel = 120.0f;
    public float startingFuel = 100.0f;
    private float fuel;
    private GameObject bar;
    private ProgressBar progressBar;

    public void addFuel(float amount) {
        fuel = math.min(fuel + amount, maxFuel);
    }

    public void removeFuel(float amount) {
        fuel = math.max(fuel - amount, 0.0f);

    }
    // Start is called before the first frame update
    void Start()
    {
        bar = GameObject.Find("FuelBar");
        if (bar != null)
        {
            progressBar = bar.GetComponent<ProgressBar>();
            fuel = startingFuel;
            //bar.progress = fuel / maxFuel;
            progressBar.minVal = 0f;
            progressBar.maxVal = maxFuel;
            progressBar.value = fuel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(progressBar != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fuel -= consumeRate * Time.deltaTime;
            }
            //bar.progress = fuel / maxFuel;
            progressBar.value = fuel;
        }
    }
}
