using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelSystemLast : MonoBehaviour
{
    public float consumeRate = 10.0f;
    public float maxFuel = 120.0f;
    public float startingFuel = 100.0f;
    private float fuel;
    public ProgressBarLast bar;
    public GameObject Danger;
    public GameObject fuelLeakage;

    public Animator anim;
    public GameObject transition;
    public int currentScene;

    private Rigidbody2D rb;

    public void addFuel(float amount) {
        fuel = Mathf.Min(fuel + amount, maxFuel);
    }

    public void removeFuel(float amount) {
        fuel = Mathf.Max(fuel - amount, 0.0f);
        fuelLeakage.SetActive(true);
        if(fuelLeakage != null)
        {
            Destroy(fuelLeakage.gameObject, 3f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        fuel = startingFuel;
        if(bar != null)
        {
            bar.progress = fuel / maxFuel;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private float timer = 0f;
    private bool errorActive = false;
    private float ratioFuel;
    private bool end = false;
    void Update()
    {
        if (bar != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fuel -= consumeRate * Time.deltaTime;
            }
            ratioFuel = fuel / maxFuel;

            bar.progress = ratioFuel;

            if (fuel < (maxFuel / 10) && !errorActive)
            {
                errorActive = true;
                if (Danger != null)
                {
                    Danger.SetActive(true);
                }
                //DANGER SOUND
            }

            if (fuel <= 0 && !end)
            {
                anim.SetBool("moving", false);
                Destroy(rb);
                StartCoroutine(waitSec());
            }
        }

        

        
    }

    IEnumerator waitSec()
    {
        transition.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(currentScene);
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (errorActive && timer>=0.5f)
        {
            timer = 0f;
            errorActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(waitSec());
        }
    }
}
