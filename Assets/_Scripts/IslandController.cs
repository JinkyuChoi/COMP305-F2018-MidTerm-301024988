using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

//2019-10-19 by Jinkyu Choi 301024988
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

    //This will check which scene you are in and define whether it would be horizontal or vertical
    void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                VerticalMove();
                VerticalCheckBounds();
                break;
            case "Main":
                VerticalMove();
                VerticalCheckBounds();
                break;
            case "Level2":
                HorizontalMove();
                HorizontalCheckBounds();
                break;
            case "End":
                VerticalMove();
                VerticalCheckBounds();
                break;
        }
    }

    /// <summary>
    /// This method moves the island down the screen by verticalSpeed
    /// </summary>
    void VerticalMove()
    { 
        Vector2 newPosition = new Vector2(0.0f, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }
    /// <summary>
    /// This method moves the island down the screen by horizontalSpeed
    /// </summary>

    void HorizontalMove()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, 0.0f);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the island to the resetPosition that has random x
    /// </summary>
    void VerticalReset()
    {
        float randomXPosition = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPosition, boundary.Top);
    }

    /// <summary>
    /// This method resets the island to the resetPosition that has random y
    /// </summary>
    void HorizontalReset()
    {
        float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
        transform.position = new Vector2(boundary.Right, randomYPosition);
    }

    /// <summary>
    /// This method checks if the island reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void VerticalCheckBounds()
    {
        if (transform.position.y <= boundary.Bottom)
        {
            VerticalReset();
        }
    }

    /// <summary>
    /// This method checks if the island reaches the right boundary
    /// and then it Resets it
    /// </summary>
    void HorizontalCheckBounds()
    {
        if (transform.position.x <= boundary.Left)
        {
            HorizontalReset();
        }
    }
}
