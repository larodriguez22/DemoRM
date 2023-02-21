using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public Collider losingCollider;

    private bool isOnCorrectPath = true;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PathSquare"))
        {
            isOnCorrectPath = true;
        }
        else if (other == losingCollider)
        {
            // The player has hit the losing collider
            Debug.Log("You lost!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PathSquare"))
        {
            isOnCorrectPath = false;
        }
    }

    void OnGUI()
    {
        if (!isOnCorrectPath)
        {
            GUI.Label(new Rect(10, 10, 200, 20), "You're off the path!");
        }
    }
}
