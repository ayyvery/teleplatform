using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed = 3f;
    public float climbSpeed = 2f;
    public float jump = 5f;
    public float bounce = 10f;

    public bool top = false;
    public bool onMovingPlatform = false;
    public bool doubleJump = false;
    public bool onClimbable = false;

    public Collision2D movingPlatform;

    public Camera cam;

    public Rigidbody2D movingRb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (onMovingPlatform)
        {
            rb.velocity = new Vector2(movingRb.velocity.x, rb.velocity.y);
        }

        if (Input.GetKey("d") && !onClimbable)
        {
            if (onMovingPlatform)
            {
                rb.velocity = new Vector2(speed + movingRb.velocity.x, rb.velocity.y);
            } 
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            
        }
        if(Input.GetKeyUp("d"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(Input.GetKey("a") && !onClimbable)
        {
            if (onMovingPlatform)
            {
                rb.velocity = new Vector2(-speed + movingRb.velocity.x, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
        }
        if (Input.GetKeyUp("a"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown("s"))
        {
            if(!top)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 10);
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 10, cam.transform.position.z);
                top = true;
            } 
            else if(top) 
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 10);
                cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 10, cam.transform.position.z);
                top = false;
            }
        }

        if (onClimbable)
        {
            rb.velocity = new Vector2(0, 0);

            if (Input.GetKey("w")) 
            {
                rb.velocity = new Vector2(0, climbSpeed * rb.gravityScale);
            }
        }

        if(Input.GetKeyDown("space") && rb.velocity.y == 0 || Input.GetKeyDown("space") && doubleJump || Input.GetKeyDown("space") && onClimbable)
        {
            onClimbable = false;
            rb.velocity = new Vector2(rb.velocity.x, jump * rb.gravityScale);
            doubleJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "killfield")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.transform.gameObject.tag == "levelFinish")
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if(SceneManager.GetActiveScene().buildIndex == 12) {
                SceneManager.LoadScene("menu");
            } else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            byte levelID = byte.Parse(sceneName.Remove(0, 5));
            PlayerPrefs.SetInt("level", levelID);
        }

        if (collision.transform.gameObject.tag == "doubleJump")
        {
            doubleJump = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.gameObject.tag == "gravityPill")
        {
            rb.gravityScale = -rb.gravityScale;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "movingPlatform" || collision.transform.gameObject.tag == "diagonal")
        {
            onMovingPlatform = true;
            movingPlatform = collision;
            movingRb = collision.rigidbody;
        }

        if (collision.transform.gameObject.tag == "climbable")
        {
            onClimbable = true;
        }

        if (collision.transform.gameObject.tag == "bouncepad")
        {
            float angle;

            if (collision.transform.parent.localRotation.eulerAngles.z <= 180)
            {
                angle = collision.transform.parent.localRotation.eulerAngles.z / 90;
            } 
            else
            {
                angle = -(360 - collision.transform.parent.localRotation.eulerAngles.z) / 90;
            }

            if (angle > 1)
            {
                rb.velocity = new Vector2(-Mathf.Sqrt(bounce * bounce * Mathf.Abs(angle - 2)), -Mathf.Sqrt(bounce * bounce * Math.Abs(angle - 1)));
            } 
            else if (angle < -1)
            {
                rb.velocity = new Vector2(Mathf.Sqrt(bounce * bounce * (angle + 2)), -Mathf.Sqrt(bounce * bounce * (Math.Abs(angle + 1))));
            }
            else if (angle > 0)
            {
                rb.velocity = new Vector2(-Mathf.Sqrt(bounce * bounce * angle), Mathf.Sqrt(bounce * bounce * (1 - Math.Abs(angle))));
            } 
            else if (angle < 0)
            {
                rb.velocity = new Vector2(Mathf.Sqrt(bounce * bounce * -angle), Mathf.Sqrt(bounce * bounce * (1 - Math.Abs(angle))));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x + (float)Math.Sqrt(bounce * bounce * -angle), (float)Math.Sqrt(bounce * bounce * (1 - Math.Abs(angle))));
            }

        }

        if (collision.transform.gameObject.tag == "projectile" || collision.transform.gameObject.tag == "killplatform")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onMovingPlatform = false;
        onClimbable = false;
    }
}
