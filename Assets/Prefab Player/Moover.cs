using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Moover : MonoBehaviour
{
    [Header("ref")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Rigidbody rb;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private Vector3 touchPosition = Vector3.zero;
    [SerializeField] private Camera mainCamera;

    private void Awake()
    {
        if (!playerInput) playerInput = GetComponent<PlayerInput>();
        touchPositionAction = playerInput.actions.FindAction("touchPosition");
        touchPressAction = playerInput.actions.FindAction("TouchPress");

    }
    private void FixedUpdate()
    {
        if (touchPressAction.IsPressed())
        {
            Vector3 touchPosValue = touchPositionAction.ReadValue<Vector2>();
            touchPosValue.z = mainCamera.transform.position.z * -1f;
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(touchPosValue);
            worldPos.z = playerInput.transform.position.z;
            worldPos.y = playerInput.transform.position.y;

            Vector3 towardWorldPos = worldPos - transform.position;
            Debug.DrawLine(transform.position, worldPos);
            towardWorldPos.Normalize();

            rb.AddForce(towardWorldPos * moveSpeed, ForceMode.Acceleration);
        }
    }
}
