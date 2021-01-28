using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectile;
    public float speed = 0.02f;
    public float delay = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(projectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, transform);
        InvokeRepeating("launch", 0, delay);
    }

    void launch()
    {
        Instantiate(projectile, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, transform);
    }

    void Update()
    {
        foreach(Transform child in transform)
        {
            if (transform.localRotation.eulerAngles.z == 0)
            {
                child.transform.position = new Vector2(child.transform.position.x, child.transform.position.y + speed);
            } 
            else if (transform.localRotation.eulerAngles.z == 90)
            {
                child.transform.position = new Vector2(child.transform.position.x - speed, child.transform.position.y);
            }
            else if (transform.localRotation.eulerAngles.z == 180)
            {
                child.transform.position = new Vector2(child.transform.position.x, child.transform.position.y - speed);
            }
            else if (transform.localRotation.eulerAngles.z == 270)
            {
                child.transform.position = new Vector2(child.transform.position.x + speed, child.transform.position.y);
            }

        }
    }
}
