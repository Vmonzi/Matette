using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Entity
{
    public enum state { Death, Walking, IDLE, Running, Craw, Hurt, Grubbing, Jumping, Sneak }

    private state _currentState;
    private float _currentLife;
    private float _speed;

    //Life Set & Get
    public void SetCurrentLife(float life) { _currentLife = life; }

    public float GetCurrentLife() { return _currentLife; }

    //Speed Set & Get
    public void SetSpeed(float speed) { _speed = speed; }

    public float GetSpeed() { return _speed; }

    //State Set & Get
    public void SetState(state state)
    {
        _currentState = state;
    }

    public state GetState() { return _currentState; }

    public bool IsDeath()
    {
        if (_currentState == state.Death)
        {
            return true;
        }
        return false;
    }
}