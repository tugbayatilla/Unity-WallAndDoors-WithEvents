using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ArchPM.Unity.Events;

public class PlayerController : MonoBehaviour
{
	// these are required for player
	public float moveSpeed = 5.0f;
	IConsumerResult consumerResult;
	MoveInputChangedEvent playerMovedEvent;

	private void Start()
	{
		consumerResult = EventBus.Instance.Consumer.Consume<MoveInputChangedEvent>(p => playerMovedEvent = p.Event);
	}

	void Update()
	{
		if (playerMovedEvent != null)
		{
			var movement = new Vector3(playerMovedEvent.horizontalMoveAxis, 0, playerMovedEvent.verticalMoveAxis);
			transform.position = transform.position + (movement * Time.deltaTime * moveSpeed);
		}
	}

	private void OnDestroy()
	{
		consumerResult.Unsubscribe();
	}

}
