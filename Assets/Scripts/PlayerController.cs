using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float baseSpeed = 20f;

    bool canMove = true;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            rb2d.AddTorque(torqueAmount);
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow)) {
            surfaceEffector2d.speed = boostSpeed;
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            surfaceEffector2d.speed = slowSpeed;
        } else {
            surfaceEffector2d.speed = baseSpeed;
        }
    }

    public void DisableController()
    {
        canMove = false;
    }
}
