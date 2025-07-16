using UnityEngine;

public class MoveScript : MonoBehaviour
{
    Animator animator;
    [SerializeField] private float speed = 2;
    [SerializeField] private float rotationSpeed = 10f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }
    
    public void Move(float horizontalInput, float verticalInput)
    {
        // Create a movement vector based on input
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
        if (movement != Vector3.zero)
        {
            // Calculate the target rotation based on movement direction
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            
            // Move in the direction the character is facing
            transform.Translate(Vector3.forward * (speed * Time.deltaTime), Space.Self);
        }
        
        animator.SetBool("IsMoving", horizontalInput != 0 || verticalInput != 0);
    }
    
    public void MoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
        Debug.Log("Moved to Position: " + targetPosition);
    }
}