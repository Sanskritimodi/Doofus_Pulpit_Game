/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float force = 10f;
    private Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move Doofus
        transform.Translate(moveDirection * force * Time.deltaTime);
    }
}*/


/*using UnityEngine;

public class DoofusController : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of Doofus
    private Vector3 moveDirection;

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move Doofus
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // Increase score or other actions when stepping on a pulpit
            GameManager.instance.IncreaseScore();
        }
    }
}*/

using UnityEngine;

public class DoofusController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of Doofus
    private Vector3 moveDirection;
    private bool isOnPulpit = false; // To track if Doofus is currently on a Pulpit

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        // Move Doofus
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // Doofus is on a Pulpit
            isOnPulpit = true;
            GameManager.instance.IncreaseScore();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // Doofus has left the Pulpit
            isOnPulpit = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallDetector"))
        {
            // Doofus has fallen
            if (isOnPulpit)
            {
                // Only end the game if Doofus falls while on a Pulpit
                GameManager.instance.GameOver();
            }
        }
    }
}