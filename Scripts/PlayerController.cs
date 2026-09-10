using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveStep = 1f;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null) return; 

        Vector3 moveDir = Vector3.zero;

        if (keyboard.wKey.wasPressedThisFrame || keyboard.upArrowKey.wasPressedThisFrame)
            moveDir = Vector3.up;
        else if (keyboard.sKey.wasPressedThisFrame || keyboard.downArrowKey.wasPressedThisFrame)
            moveDir = Vector3.down;
        else if (keyboard.aKey.wasPressedThisFrame || keyboard.leftArrowKey.wasPressedThisFrame)
            moveDir = Vector3.left;
        else if (keyboard.dKey.wasPressedThisFrame || keyboard.rightArrowKey.wasPressedThisFrame)
            moveDir = Vector3.right;

        if (moveDir != Vector3.zero)
        {
            transform.position += moveDir * moveStep;
        }
    }

    public void DisableMovement()
    {
        this.enabled = false;
    }
}