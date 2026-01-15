using System;
using System.Collections.Generic;

public class StateMachine<T>
{
    private State<T> currentState;
    private Dictionary<Enum, State<T>> states;

    public void RegisterState(Enum en, State<T> state)
    {
        states[en] = state;
    }

    /// <summary>
    /// Change state using the state reference.
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State<T> newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    /// <summary>
    /// Change state using associated enum.
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(Enum newState)
    {
        if (states.TryGetValue(newState, out var state))
        {
            currentState?.Exit();
            currentState = state;
            currentState?.Enter();
        }
    }

    public void Update()
    {
        currentState?.Update();
    }
}