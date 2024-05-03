using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasAsc : MonoBehaviour, IPuertasMov
{
    // Victoria Monzi - Ivo Aguilera
    [SerializeField] Transform _open;
    [SerializeField] Transform _close;
    float                      _velocity = 10;
    Ascensor                   _asc;
    Transform                  _target;

    private void Start()
    {
        _asc = GetComponentInParent<Ascensor>();
        _target = _close;
    }

    public void Open()
    {
        _target = _open;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _velocity * Time.deltaTime);
    }
    public void Close()
    {
        _target = _close;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _velocity * Time.deltaTime);
    }
}
