using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

//2019-10-19 by Jinkyu Choi 301024988
public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        //This will check which scene you are in and define whether it would be horizontal or vertical
        switch (SceneManager.GetActiveScene().name)
        {
            case "Main":
                VerticalMove();
                VerticalCheckBounds();
                break;
            case "Level2":
                HorizontalMove();
                HorizontalCheckBounds();
                break;
        }
    }

    //This will control Vertical Movement
    public void VerticalMove()
    {
        Vector2 newPosition = transform.position;

        if(Input.GetAxis("Horizontal") > 0.0f)
        {
            newPosition += new Vector2(speed.max, 0.0f);
        }

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            newPosition += new Vector2(speed.min, 0.0f);
        }

        transform.position = newPosition;
    }

    public void HorizontalMove()
    {
        Vector2 newPosition = transform.position;

        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.max);
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            newPosition += new Vector2(0.0f, speed.min);
        }

        transform.position = newPosition;
    }


    public void VerticalCheckBounds()
    {
        // check right boundary
        if(transform.position.x > boundary.Right)
        {
            transform.position = new Vector2(boundary.Right, transform.position.y);
        }

        // check left boundary
        if (transform.position.x < boundary.Left)
        {
            transform.position = new Vector2(boundary.Left, transform.position.y);
        }
    }

    public void HorizontalCheckBounds()
    {
        // check right boundary
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }

        // check left boundary
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Cloud":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }

}
