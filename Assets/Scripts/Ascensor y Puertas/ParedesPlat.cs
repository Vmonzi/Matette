using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesPlat : MonoBehaviour, IPuertasMov
{
    public Transform open;
    public Transform close;
    Transform      _target;
    float          _velocity = 15;

    private void Start()
    {
        _target = close;
    }
   public void Open()
    {
        _target = open;
    }

    public void Close()
    {
        _target = close;
    }

    private void Update()
    {
         transform.position = Vector3.MoveTowards(transform.position, _target.position, _velocity * Time.deltaTime);
    }
}
