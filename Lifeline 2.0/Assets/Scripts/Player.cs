using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private GameInput gameInput;

    [SerializeField] private float moveSpeed= 5;
    [SerializeField] private float rotateSpeed = 5f;


    public bool isRunning;
   

    void Update()
    {     

        Vector2 inputVector = gameInput.GetMovementVectorNormalised();

        //Create a vector 3 & assign y input to z azis
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float playerSize = .7f;

        bool canMove = !Physics.Raycast(transform.position, moveDir, playerSize);
        if (canMove)
        {
            // increment gameobject/player transform position by the vector3 
            transform.position += moveDir * Time.deltaTime * moveSpeed;

        }

        // bool returns true when inputis not zero
        isRunning = moveDir != Vector3.zero;
        
        // set forward pos to players move direction
        transform.forward = Vector3.Lerp(transform.position, moveDir, Time.deltaTime* rotateSpeed);
    }

    /*
    private void HandleMovement()
    {
       

        float moveDistance= moveSpeed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float playerRadius= .5f;
        float playerHeight= 2f;


      //  Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection);


        
    }
    */

   
    public bool IsRunning()
    {
        return isRunning;
    }
}
