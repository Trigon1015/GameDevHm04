using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
   
    public  new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float speed = 30f;
    public float maxBounceAngle = 75f;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();

    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rigidbody.velocity = Vector2.zero;
    }

    private void Update()
    {
        
        if(Input.GetKey(KeyCode.A))
        {
            
            this.direction = Vector2.left;
            this.rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            this.direction = Vector2.right;
            this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
        }
        else
        {
            this.direction = Vector2.zero;
            this.rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        
    }

    private void FixedUpdate()
    {
        /*
        if(this.direction != Vector2.zero)
        {
            //this.rigidbody.AddForce(this.direction * this.speed);
            if (Input.GetKey(KeyCode.A))
            {

                this.rigidbody.velocity = new Vector2(-speed, rigidbody.velocity.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
            }
            else
            {
                this.rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            }
            
        }
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        BallController ball = other.gameObject.GetComponent<BallController>();
        if(ball != null)
        {
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = other.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = other.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }

}
