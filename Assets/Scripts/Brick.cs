using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer sr { get; private set; }
    public Color[] states;
    public int points = 100;
    public int health { get; private set; }
    public bool unbreakable;

    private void Awake()
    {
        this.sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if(!this.unbreakable)
        {
            this.health = this.states.Length;
            this.sr.color = this.states[this.health - 1];
        }
        
    }

    private void Hit()
    {
        if(this.unbreakable)
        {
            return;
        }
        this.health--;

        if(this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.sr.color = this.states[this.health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Ball")
        {
            Hit();
        }
    }
       
    
}
