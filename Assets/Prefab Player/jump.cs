using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class jump : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 jumpForce;
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!rb) return;
      
        if(!context.performed)
        {
          

                rb.AddForce(jumpForce, ForceMode.Impulse);
            Debug.Log("Jump!");

        }
        
    }

}