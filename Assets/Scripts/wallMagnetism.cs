using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMagnetism : MonoBehaviour
{
    public Transform player;
    bool right = false;

    void Start() {
        if (transform.rotation.z == -90) {
            right = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerRelative = player.InverseTransformPoint(transform.position);

        if (right) {
            if (playerRelative.x < 0.5 && playerRelative.y < Mathf.Abs(transform.localScale.y / 2)) {
                //set player wall boolean to true
                //stick player to wall physically
            }
        } else {
            if (playerRelative.x > -0.5 && playerRelative.y < Mathf.Abs(transform.localScale.y / 2)) {
                //set player wall boolean to true
                //stick player to wall physically
            }
        }
    }
}
