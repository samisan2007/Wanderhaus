// Assets/_MyAssets/Scripts/FSM/StateMachine.cs
using System;
using System.Collections.Generic;
using UnityEngine;

namespace TravelingHouse.FSM
{
    /// <summary>
    /// Drop this on a GameObject (e.g. “GameManager”).
    /// Feed it an ordered list of GameState assets in the Inspector.
    /// </summary>
    public sealed class StateMachine : MonoBehaviour
    {
        [Tooltip("Sequence of states to play. You can branch at runtime.")]
        [SerializeField] List<GameState> sequence = new();

        int   index = -1;
        GameState current;

        public event Action<GameState> OnStateChanged;

        void Start() => Advance();    // Kick off first state

        void Update()
        {
            if (current != null)
                current.Tick(this, Time.deltaTime);
        }

        /// <summary>Call from a state to jump anywhere.</summary>
        public void SetState(GameState newState)
        {
            if (newState == current || newState == null) return;

            current?.Exit(this);
            current = newState;
            current.Enter(this);
            OnStateChanged?.Invoke(current);
        }

        /// <summary>Move to the next entry in the Inspector list.</summary>
        public void Advance()
        {
            index = (index + 1) % sequence.Count;
            SetState(sequence[index]);
        }

        /// <summary>Utility for UI, debug, etc.</summary>
        public GameState Current => current;
    }
}