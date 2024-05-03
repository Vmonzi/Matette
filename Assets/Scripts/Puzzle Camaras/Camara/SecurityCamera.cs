using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour, IVisionRange
{

    [SerializeField] Animator _myAnim;
    [SerializeField] AudioSource _effectSound;
    [SerializeField] float _visionRange;
    [SerializeField] GameObject _target;
    [SerializeField] Turret _turretAttack;

    bool            _detectedPlayer;
    BaseCharacter   _baseCharacter;

    void Start()
    {
        _detectedPlayer = false;
        _baseCharacter = _target.GetComponent<BaseCharacter>();
    }

    void Update()
    {
        DistanceTarget(_target.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _visionRange);
    }

    public void DetectedPlayer()
    {
        if (_baseCharacter.GetController.GetState() != Entity.state.Sneak)
        {
            _detectedPlayer = true;
            _myAnim.SetBool("Detected", true);
            _turretAttack.DetectedPlayer();
        }
    }

    public void OutOfRange()
    {
        _detectedPlayer = false;
        _myAnim.SetBool("Detected", false);
        _turretAttack.OutOfRange();
    }

    public void DistanceTarget(Vector3 target)
    {
        Vector3 dist = target - transform.position;
        float distance = dist.magnitude;

        if (distance <= _visionRange) DetectedPlayer();
        else OutOfRange();
    }

    void AudioPlay()
    {
        _effectSound.Play();
    }
}
