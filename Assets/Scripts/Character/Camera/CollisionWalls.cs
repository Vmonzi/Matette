using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWalls : MonoBehaviour
{
    private float _minDistance = 1;
    private float _maxDistance = 6;
    private float _friction = 3;
    private float _distance;

    Vector3 _direction;

    private void Start()
    {
        _direction = transform.localPosition.normalized;
        _distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 posCamera = transform.parent.TransformPoint(_direction * _maxDistance);

        RaycastHit hit;
        if(Physics.Linecast(transform.parent.position, posCamera, out hit))
        {
            _distance = Mathf.Clamp(hit.distance * 0.2f, _minDistance, _maxDistance);
        }
        else
        {
            _distance = _maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, _direction * _distance, _friction * Time.deltaTime);
    }
}
