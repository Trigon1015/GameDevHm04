using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public PaddleController paddle;
    public float speed = 500f;
    public bool started;

    public void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        started = false;
        ResetBall();
    }

    private void Update()
    {
        SpeedLimit();
        Shoot();
        
    }

    private void Shoot()
    {
        Vector2 force = Vector2.zero;
        force.x = 0;
        force.y = 1f;
        if(!started)
        {
            rigidbody.position = new Vector2(paddle.rigidbody.position.x, paddle.rigidbody.position.y + 3f);
        }
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("shoot");
            this.rigidbody.AddForce(force *  this.speed);
            started = true;
        }

        
    }

    public void ResetBall()
    {
        rigidbody.position = new Vector2(paddle.rigidbody.position.x, paddle.rigidbody.position.y + 3f);
        rigidbody.velocity = Vector2.zero;
        started = false;
       
    }

    public void SpeedLimit()
    {
        if(rigidbody.velocity.magnitude != 16 )
        {
            rigidbody.velocity = rigidbody.velocity.normalized *16;
        }
    }
}


