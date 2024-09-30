using UnityEngine;

public class Laser : MonoBehaviour
{
    public float damage_amount = 20.0f;
    public float activation_speed = 2.0f;
    public bool is_active = true;
    private float max_scale;
    private float scale;
    public FuelSystemLast fuelSystem;


    void Start()
    {
        scale = 0.0f;
        max_scale = transform.localScale.y;
    }

    public void EffectPlayer() {
        GameObject player = GameObject.Find("SpaceShip");

        Rigidbody2D player_body = player.GetComponent<Rigidbody2D>();
        Vector2 player_vel = player_body.velocity;
        Vector2 normal = Quaternion.Euler(0.0f, 0.0f, gameObject.transform.rotation.z) * Vector2.left;
        Vector2 vec = Vector2.Reflect(player_vel, normal);
        Vector2 force = vec * -5.0f;
        
        player_body.AddForce(force);

        fuelSystem = fuelSystem.GetComponent<FuelSystemLast>();
        fuelSystem.removeFuel(damage_amount);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active) {
                scale += activation_speed * Time.deltaTime;
                scale = scale > max_scale ? max_scale : scale;
        } else {
            scale -= activation_speed * Time.deltaTime;
            scale = scale < 0.0f ? 0.0f : scale;
        }

        transform.localScale = new Vector3(transform.localScale.x, scale, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(is_active && collision.gameObject.CompareTag("SpaceShip"))
        {
            EffectPlayer();
            Debug.Log("Damage");
        }

    }
}
