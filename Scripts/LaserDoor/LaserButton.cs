using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : MonoBehaviour
{
    public Laser laser;
    // Start is called before the first frame update
    public GameObject redButton;
    public GameObject greenButton;

    void OnCollisionEnter2D(Collision2D collider) {


        if(collider.gameObject.CompareTag("SpaceShip") && laser != null || collider.gameObject.CompareTag("Bullet") && laser != null)
        {
            laser.is_active = false;
            Debug.Log("laser inactivated");
            greenButton.SetActive(true);
            redButton.SetActive(false);
        }

    }

    public void activateLaser()
    {
        laser.is_active=true;
    }
}
