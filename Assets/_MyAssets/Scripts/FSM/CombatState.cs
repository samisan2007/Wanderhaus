using UnityEngine;
using TravelingHouse.FSM;

[CreateAssetMenu(menuName = "Traveling House/States/Combat")]
public sealed class CombatState : GameState
{
    public override void Enter(StateMachine m)
    {
        m.gameObject.BroadcastMessage("SetMovementEnabled", false,
            SendMessageOptions.DontRequireReceiver);
        m.gameObject.BroadcastMessage("SetTurretsActive",   true,
            SendMessageOptions.DontRequireReceiver);
    }

    public override void Tick(StateMachine m, float dt)
    {
        // if (WaveManager.Instance.IsClear) m.Advance();
    }
}