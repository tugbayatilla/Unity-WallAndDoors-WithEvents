using ArchPM.Unity.Events;
using UnityEngine.Events;

public class MoveInputChangedEvent : UnityEvent<float, float>, IEvent
{
    public float horizontalMoveAxis; 
    public float verticalMoveAxis;
}