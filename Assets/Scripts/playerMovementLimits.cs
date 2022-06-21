using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerMovementLimits : MonoBehaviour
{
    public float speed = 10f;
    public float moveLimitYmin = -5f;
    public float moveLimitYmax = 5f;
    public float moveLimitXmin = -1f;
    public float moveLimitXmax = 1f;
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 startingPosition;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Clamp the up and down movement
        // put in score number of vollys
        // reset if hits the bad area
        //adjust the rate of speed increase
        // 
        //movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        startingPosition = rb.position;


    }

    private void FixedUpdate()
    {

        // float movePosition = Mathf.Clamp(rb.position + movement * speed * Time.fixedDeltaTime, -moveLimitY, moveLimitY);
        Vector2 clampedPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, moveLimitYmin, moveLimitYmax);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, moveLimitXmin, moveLimitXmax);
        rb.MovePosition(clampedPosition);
    }

    

}
