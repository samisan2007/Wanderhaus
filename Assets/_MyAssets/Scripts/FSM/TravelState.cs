using UnityEngine;
using TravelingHouse.FSM;

[CreateAssetMenu(menuName = "Traveling House/States/Travel")]
public sealed class TravelState : GameState
{
    public override void Enter(StateMachine m)
    {
        m.gameObject.BroadcastMessage("SetTurretsActive",  false,
            SendMessageOptions.DontRequireReceiver);
        m.gameObject.BroadcastMessage("SetMovementEnabled", true,
            SendMessageOptions.DontRequireReceiver);
    }

    public override void Tick(StateMachine m, float dt)
    {
        // e.g. if a trigger is reached:
        // if (reachedOutpost) m.SetState(outpostState);
    }
}