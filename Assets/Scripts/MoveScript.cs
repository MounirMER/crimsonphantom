using UnityEngine;

public class MoveScript : MonoBehaviour
{
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
        
        // Check if the Animator is assigned
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }
    
    // Method to move the object based on input
    public void Move(float horizontalInput, float verticalInput)
    {
        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        
        // Move the object by the movement vector
        transform.Translate(movement * Time.deltaTime);
        
        animator.SetBool("IsMoving", horizontalInput > 0.1 || verticalInput > 0.1 || horizontalInput < -0.1 || verticalInput < -0.1);
    }
    
    // Method to move the object to a specific position
    public void MoveToPosition(Vector3 targetPosition)
    {
        // Move the object to the target position
        transform.position = targetPosition;
        
        // Log the new position for debugging
        Debug.Log("Moved to Position: " + targetPosition);
    }
}
