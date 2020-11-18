using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    public enum State
    {
        Up,
        Down,
        Left,
        Right
    }

    public State state { get; set; }
    public float X { get; set; }
    public float Y { get; set; }

    public PlayerInput(float X, float Y, State state)
    {
        this.X = X;
        this.Y = Y;
        this.state = state;
    }
}
