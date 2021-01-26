using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{

    public bool horizontal = true;

    public Rigidbody2D rb;

    public string topCoord;
    public string bottomCoord;

    public float speed = 3f;

    public bool movingDown = true;

    // Update is called once per frame
    void Update()
    {
        if (horizontal)
        {
            if (movingDown)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }

            if (transform.position.x < float.Parse(bottomCoord))
            {
                movingDown = false;
            }

            if (transform.position.x > float.Parse(topCoord))
            {
                movingDown = true;
            }
        } 
        
        if(!horizontal)
        {
            if(gameObject.tag == "diagonal")
            {
                string[] bottomCoords = bottomCoord.Split(';');
                string[] topCoords = topCoord.Split(';');

                float horSpeed = (float.Parse(topCoords[0]) - float.Parse(bottomCoords[0])) / speed;
                float verSpeed = (float.Parse(topCoords[1]) - float.Parse(bottomCoords[1])) / speed;

                if (movingDown)
                {
                    if (float.Parse(topCoords[0]) < float.Parse(bottomCoords[0])) 
                    {
                        horSpeed = (float.Parse(bottomCoords[0]) - float.Parse(topCoords[0])) / speed;
                        rb.velocity = new Vector2(horSpeed, -verSpeed);
                    } 
                    else
                    {
                        rb.velocity = new Vector2(-horSpeed, -verSpeed);
                    }
                }
                else
                {
                    if (float.Parse(topCoords[0]) < float.Parse(bottomCoords[0]))
                    {
                        horSpeed = (float.Parse(bottomCoords[0]) - float.Parse(topCoords[0])) / speed;
                        rb.velocity = new Vector2(-horSpeed, verSpeed);
                    }
                    else
                    {
                        rb.velocity = new Vector2(horSpeed, verSpeed);
                    }
                }

                if (transform.position.y < float.Parse(bottomCoords[1]))
                {
                    movingDown = false;
                }

                if (transform.position.y > float.Parse(topCoords[1]))
                {
                    movingDown = true;
                }
            } 
            else 
            {
                if(movingDown)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -speed);
                } 
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, speed);
                }

                if(transform.position.y < float.Parse(bottomCoord))
                {
                    movingDown = false;
                }

                if(transform.position.y > float.Parse(topCoord))
                {
                    movingDown = true;
                }     
            }   
        }  
    }
}
