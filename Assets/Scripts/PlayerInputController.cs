using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDwonController
{
    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}