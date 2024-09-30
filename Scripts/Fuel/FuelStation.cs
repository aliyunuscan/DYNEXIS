using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    public FuelSystemLast fuelSystem;
    public float fuelAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip"))
        {
            fuelSystem.addFuel(fuelAmount);
            Destroy(this.gameObject);
        }
        
    }
}
