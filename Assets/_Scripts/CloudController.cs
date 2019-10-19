using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.SceneManagement;

//2019-10-19 by Jinkyu Choi 301024988
public class CloudController : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
    public Boundary boundary;

    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                VerticalReset();
                break;
            case "Main":
                VerticalReset();
                break;
            case "Level2":
                HorizontalReset();
                break;
            case "End":
                VerticalReset();
                break;
        }
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
    /// This method moves the cloud down the screen by verticalSpeed and horizontal speed 
    /// </summary>
    void VerticalMove()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method moves the cloud left the screen by verticalSpeed and horizontal speed
    void HorizontalMove()
    {
        Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method resets the cloud to the resetPosition and that has random x with slightly random y
    /// </summary>
    void VerticalReset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

        float randomXPosition = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
    }

    /// <summary>
    /// This method resets the cloud to the resetPosition and that has random y with slightly random x
    /// </summary>
    void HorizontalReset()
    {
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

        float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);
        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + 2.0f), randomYPosition);
    }

    /// <summary>
    /// This method checks if the cloud reaches the lower boundary
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
    /// This method checks if the cloud reaches the left boundary
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
