using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;


public class IslandController : MonoBehaviour
{
    public float verticalSpeed = 0.05f;
    public float horizontalSpeed = 0.05f;


    public Boundary boundary;

    void Start()
    {
        //Reset();
    }

    // Update is called once per frame
    void Update()
    {
        SceneConfiguration();
    }

    void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                VerticleMove();
                VerticalCheckBounds();
                break;
            case "Main":
                VerticleMove();
                VerticalCheckBounds();
                break;
            case "Level2":
                HorizontalMove();
                HorizontalCheckBounds();
                break;
            case "End":
                VerticleMove();
                VerticalCheckBounds();
                break;
        }
    }

    /// <summary>
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void VerticleMove()
    {
        Vector2 newPosition = new Vector2(0.0f, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void HorizontalMove()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void VerticalReset()
    {
        float randomXPosition = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPosition, boundary.Top);
    }

    void HorizontalReset()
    {
        float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
        transform.position = new Vector2(boundary.Right, randomYPosition);
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void VerticalCheckBounds()
    {
        if (transform.position.y <= boundary.Bottom)
        {
            VerticalReset();
        }
    }

    void HorizontalCheckBounds()
    {
        if (transform.position.x <= boundary.Left)
        {
            HorizontalReset();
        }
    }
}
