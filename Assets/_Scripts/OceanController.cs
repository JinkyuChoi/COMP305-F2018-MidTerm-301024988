using UnityEngine;
using UnityEngine.SceneManagement;

//2019-10-19 by Jinkyu Choi 301024988
public class OceanController : MonoBehaviour
{
    public float verticalSpeed = 0.1f;
    public float horizontalSpeed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;

    // Start is called before the first frame update
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
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void VerticalMove()
    {
        Vector2 newPosition = new Vector2(0.0f, verticalSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    /// <summary>
    /// This method moves the ocean down the screen by horizontalSpeed
    /// </summary>
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
        transform.position = new Vector2(0.0f, resetPosition);
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void HorizontalReset()
    {
        transform.position = new Vector2(resetPosition, 0.0f);
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void VerticalCheckBounds()
    {
        if (transform.position.y <= resetPoint)
        {
            VerticalReset();
        }
    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void HorizontalCheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            HorizontalReset();
        }
    }
}
