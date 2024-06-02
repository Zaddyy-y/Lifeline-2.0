using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameInput : MonoBehaviour
{
      private  PlayerInput playerInput;

    

    private void Awake()
    {
        // make object of auto generated script/ construct object of type PlayerInput
        playerInput= new PlayerInput();
        //enable input system/ activate chosen action map 
        playerInput.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalised()
    {   
        // listens out for input 
        Vector2 inputVector= playerInput.Player.Move.ReadValue<Vector2>(); 
        
        //Normalise inputVector
        inputVector= inputVector.normalized;
        return inputVector;
      
    }
}
