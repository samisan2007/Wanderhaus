// Assets/_MyAssets/Scripts/FSM/GameState.cs
using UnityEngine;

namespace TravelingHouse.FSM
{
    /// <summary>
    /// Base class for all game states.
    /// Derive from this and create assets via the Inspector menu.
    /// </summary>
    public abstract class GameState : ScriptableObject
    {
        /// <remarks>
        /// You get the owning machine in case you want to branch
        /// somewhere other than “next in list”.
        /// </remarks>
        public virtual void Enter(StateMachine machine)    { }
        public virtual void Tick (StateMachine machine,float dt) { }
        public virtual void Exit  (StateMachine machine)    { }
    }
}