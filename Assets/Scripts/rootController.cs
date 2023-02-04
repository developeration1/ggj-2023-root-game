using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rootController : MonoBehaviour
{
    public CharacterController controller;
    public LineRenderer lineRenderer;
    public float movementQuantity = 10;
    private int lineRendererPositions = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveRoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            lineRendererPositions++;
            lineRenderer.positionCount = lineRendererPositions;
            Vector2 movementInput = context.ReadValue<Vector2>();
            Vector3 movementOutput = new Vector3(movementInput.x, movementInput.y, 0) * movementQuantity;
            controller.Move(movementOutput);
            lineRenderer.SetPosition(lineRendererPositions-1,controller.transform.position);
            
        }
    }
}
