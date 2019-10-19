using UnityEngine;
using UnityEngine.SceneManagement;

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
        transform.position = new Vector2(0.0f, resetPosition);
    }

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

    void HorizontalCheckBounds()
    {
        if (transform.position.x <= resetPoint)
        {
            HorizontalReset();
        }
    }
}
