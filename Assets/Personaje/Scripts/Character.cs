using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    private CharacterController controllerChar;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;
     // Speed of rotation
    public float rotationSpeed = 5f;
    private void Start()
    {
        controllerChar = GetComponent<CharacterController>();
    }

    void Update()
    {
      //  Vector3 moveVertical = transform.up * (-1) * Input.GetAxis("Horizontal");
       Vector3 moveVertical = transform.up  * Input.GetAxis("Horizontal");
       // Vector3 moveHorizontal = transform.right * Input.GetAxis("Vertical");
        Vector3 moveHorizontal = transform.right *(-1)* Input.GetAxis("Vertical");
        Vector3 move = moveVertical + moveHorizontal;
        /*  Vector3 moveVertical = transform.up *(-1)* Input.GetAxis("Horizontal");
          Vector3 moveHorizontal = transform.right *(-1)* Input.GetAxis("Vertical");

          Vector3 move = moveVertical + moveHorizontal;
          float horizontalInput = Input.GetAxis("Horizontal");

          // Rotate the player only for left and right movement
          if (horizontalInput != 0)
          {
              Vector3 moveDirection = new Vector3(0f, 0f, horizontalInput).normalized;
             Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.left);
             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
          }
        */


        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(0f, 0f, horizontalInput).normalized;
        // Rotate the player only for left and right movement
      
        
        
        
        /*if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(Vector3.left, -rotationSpeed * Time.deltaTime);
          //  Vector3 moveDirection = new Vector3(0f, 0f, horizontalInput).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Rotate right when pressing D
       else  if (Input.GetKey(KeyCode.D))
        {
           // Vector3 moveDirection = new Vector3(0f, 0f, horizontalInput).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        */

        // Calculate movement direction
       /* Vector3 moveVertical = transform.up * (-1) * horizontalInput;
        Vector3 moveHorizontal = transform.right * verticalInput;
        Vector3 move = moveVertical + moveHorizontal;
       */
        // Move the player
        if (move != Vector3.zero)
        {
            controllerChar.Move(move.normalized * Time.deltaTime * playerSpeed);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controllerChar.Move(playerVelocity * Time.deltaTime);
    }
}
