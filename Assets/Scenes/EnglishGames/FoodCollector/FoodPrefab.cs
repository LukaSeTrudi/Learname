using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPrefab : MonoBehaviour
{
    public string name;

    private float falling_speed = 2.0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        name = GetComponent<SpriteRenderer>().sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerFood.paused){
            rb.simulated = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            return;
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        rb.simulated = true;
        rb.velocity = new Vector3(0,-falling_speed,0);
        if(transform.position.y < -6){
            Destroy(gameObject);
        }
    }
}
