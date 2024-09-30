using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackDoor : MonoBehaviour
{
    private bool onDoorCase=false;
    public DoorScript currentDoorScript;
    public float completeTime = 5f;
    private float hackTimer = 0f;
    public Slider hackProgressSlider;
    private bool startHack=false;

    void Start()
    {
        
    }

    void Update()
    {
        if(onDoorCase == true)
        {
            HackingDoor();
        }
        else if(onDoorCase == false)
        {

        }
        
    }

    public void HackingDoor()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if(onDoorCase==true && currentDoorScript.doorOpened == false)
            {
                if (Input.GetKeyDown(KeyCode.H))
                {
                    startHack = true;
                }

                if (Input.GetKey(KeyCode.H) && startHack == true)
                {
                    hackTimer += Time.deltaTime;
                    UpdateSlider(); // updates slider

                    if (hackTimer >= completeTime)
                    {
                        Debug.Log("Hack Completed");
                        currentDoorScript.OpenDoor();
                        currentDoorScript.doorOpened = true;
                        hackTimer = 0f;
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            startHack = false;
            hackTimer = 0f;
            UpdateSlider();
        }
    }

    public void UpdateSlider()
    {
        hackProgressSlider.gameObject.SetActive(true);
        hackProgressSlider.maxValue = completeTime;
        hackProgressSlider.minValue = 0f;
        hackProgressSlider.value = hackTimer;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoorCase"))
        {
            onDoorCase = true;
            currentDoorScript = collision.GetComponent<DoorScript>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoorCase"))
        {
            onDoorCase = false;
            currentDoorScript = null;
            hackTimer = 0f;
            UpdateSlider();
        }
    }
}
