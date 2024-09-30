using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{

    public LaserButton laser;
    public GameObject gemDialogue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip"))
        {
            laser.activateLaser();
            gemDialogue.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
