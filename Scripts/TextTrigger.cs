using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour
{
    public Text shipText;

    private void Start()
    {
        shipText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip") && shipText)
        {
            shipText.gameObject.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceShip") && shipText)
        {
            //shipText.gameObject.SetActive(false);
            Destroy( shipText.gameObject );
        }
    }
}
