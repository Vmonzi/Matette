using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ascensor : MonoBehaviour
{
    // Ivo Aguilera - Victoria Monzi
    public enum posicion { up, down };

    public GameObject[] toShowOrHide;
    public Rigidbody    rb;
    public PuertasAsc[] doors;
    public Vector3      _velocity;

    public delegate void Move();
    public event Move LetsMove;  

    bool                _move;
    posicion            _pos; // false = abajo, true = arriba


    private void Start()
    {
        foreach (PuertasAsc door in doors)
        {
            LetsMove += door.Open;
        }

        foreach(GameObject hide in toShowOrHide)
        {
            hide.SetActive(false);
        }
        rb = this.GetComponent<Rigidbody>();

        _pos = posicion.up;
    }

    private void Update()
    {
        LetsMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject show in toShowOrHide)
        {
            show.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject hide in toShowOrHide)
        {
            hide.SetActive(false);
        }
    }

    public void Movement()
    {
        SetMove(true);
        Vector3 velocity = Vector3.zero;
        if (_pos == posicion.down)
        {
            velocity = (transform.position + _velocity * Time.deltaTime);
        }
        if (_pos == posicion.up)
        {
            velocity = (transform.position - _velocity * Time.deltaTime);
        }
        rb.MovePosition(velocity);
    }

    public posicion GetPos()
    {
        return _pos;
    }

    public void SetPos(posicion pos)
    {
        _pos = pos;
    }

    public bool GetMove()
    {
        return _move;
    }

    public void SetMove(bool move)
    {
        _move = move;
    }
}
