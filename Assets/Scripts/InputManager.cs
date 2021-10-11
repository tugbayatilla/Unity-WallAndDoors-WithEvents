using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ArchPM.Unity.Events;

public class InputManager : MonoBehaviour
{
    // these are required to get info from input system
    private PlayerInputActions playerInputActions;
    private InputAction movement;
	public MoveInputChangedEvent moveInputChangedEvent;

    // input system
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    // input system
    private void OnEnable()
    {
        movement = playerInputActions.Player.Movement;
        movement.performed += OnMovement;
        movement.canceled += OnMovement;
        movement.Enable();
    }

    // input system
    private void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
		var @event = new MoveInputChangedEvent() { horizontalMoveAxis = inputVector.x, verticalMoveAxis = inputVector.y };

		moveInputChangedEvent?.Invoke(@event.horizontalMoveAxis, @event.verticalMoveAxis);

		EventBus.Instance.Publisher.Publish(@event);
    }

    // input system
    private void OnDisable()
    {
        // step 4
        movement.Disable();
    }

}
