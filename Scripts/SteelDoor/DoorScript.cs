using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Collision2D collision;

    public bool doorOpened = false;

    public Collider2D coll;
    public SpriteRenderer spriteRenderer;

    public GameObject rightSide;
    public Rigidbody2D rightRB;

    public GameObject leftSide;
    public Rigidbody2D leftRB;

    public Transform endL;
    public Transform endR;

    public float speed=0.1f;
    public void OpenDoor()
    {
        //RunAnimation
        
        Debug.Log("KAPI ACILDI");
        doorOpened = true;
    }
    private void Start()
    {
        rightRB = rightSide.GetComponent<Rigidbody2D>();
        leftRB = leftSide.GetComponent<Rigidbody2D>();
        rightSide.SetActive(false);
        leftSide.SetActive(false);

    }

    private void FixedUpdate()
    {
        if(doorOpened)
        {
            spriteRenderer.enabled = false;
            Destroy(coll);
            rightSide.SetActive(true);
            leftSide.SetActive(true);
            rightRB.transform.position = Vector2.MoveTowards(rightSide.transform.position,endR.position,speed);
            leftRB.transform.position = Vector2.MoveTowards(leftSide.transform.position, endL.position, speed);
        }
    }

}
