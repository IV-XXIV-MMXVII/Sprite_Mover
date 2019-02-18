using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour
{
    // Declare our variables


    // Start is called before the first frame update


    [HideInInspector] public bool right = true; //This variable will be used to detect whether the player is going left or right.

    public float movement; //This will be the current speed of the player
    public float acceleration = 6f; //This defines the speed limit of player; how fast the player can go.

    private const float slowDown = 1f; //Controls movement 1 unit
    private Rigidbody2D rb; //We grab a reference to the gameObject's Rigidbody in order to apply Physic-like properties

    Vector3 origonalPosition; //Initialing this variable so we can grab the starting position

    void Start()

    {
        rb = GetComponent<Rigidbody2D>(); //Get's our Rigidbody2D

        origonalPosition = gameObject.transform.position; //Assigns the starting position to the gameobject.

    }

    // Update is called once per frame
    void Update()
    {
        //If the player isn't moving, and left key or right key is pressed
        //The player will start moving!!

        // After reaching the max speed, it will stay at that
        //speed until there is no input from the user.

        //If the user's input is opposite of the gameObject's direction
        //It'll face either left or right, relative to the player's input

        //When the user presses the shift key
        //The player will move only 1 unit

        float leftRight = Input.GetAxis("Horizontal");

        if (leftRight * rb.velocity.x < acceleration)
            rb.AddForce(Vector2.right * leftRight * movement); 
        if (Mathf.Abs(rb.velocity.x) > acceleration)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * acceleration, rb.velocity.y); 

        if (leftRight > 0 && !right)
            whirl();
        else if (leftRight < 0 && right)
            whirl();
      

        if (Input.GetKey(KeyCode.LeftShift))
            acceleration = slowDown;
        else
            acceleration = 6f;

        if (Input.GetKeyDown(KeyCode.Q))
            gameObject.SetActive(false);

    
    }
    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
            gameObject.transform.position = origonalPosition; //If we hit the spacebar, it'll have the player return to the starting position.
    }

    void whirl() // private function that putes rotation.

    {
        right = !right; // This switches the outcome 
        Vector3 scale = transform.localScale; // Grabs the scale
        scale.x *= -1; // Will whirl over Y axis
        transform.localScale = scale; // localScale = scale 
        


    }




}
