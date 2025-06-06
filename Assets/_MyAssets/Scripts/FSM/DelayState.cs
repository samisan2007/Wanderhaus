// Assets/_MyAssets/Scripts/FSM/States/DelayState.cs
using UnityEngine;
using TravelingHouse.FSM;

[CreateAssetMenu(menuName = "Traveling House/States/Delay")]
public sealed class DelayState : GameState
{
    public float duration = 2f;

    float t;

    public override void Enter(StateMachine m) => t = 0f;

    public override void Tick(StateMachine m, float dt)
    {
        if ((t += dt) >= duration)
            m.Advance();
    }
}