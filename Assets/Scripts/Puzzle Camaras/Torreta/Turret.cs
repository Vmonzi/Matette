using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Turret: MonoBehaviour, IVisionRange
{
    //Casella, Maximiliano
    [SerializeField] float _visionRange;
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _target;
    [SerializeField] AudioSource _soundEffect;
    [SerializeField] Animator _myAnim;

    bool attackPlayer;
    BaseCharacter _baseCharacter;

    private void Start()
    {
        _baseCharacter = _target.GetComponent<BaseCharacter>();
    }

    void Update()
    {
        DistanceTarget(_target.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _visionRange);
    }

    public void AttackPlayer()
    {
        if (attackPlayer)
        {
            Instantiate(_bullet, transform.position, Quaternion.identity);
        }
    }
    public void DistanceTarget(Vector3 target)
    {
        Vector3 dist = target - transform.position;
        float distance = dist.magnitude;

        if (distance <= _visionRange && _baseCharacter.GetController.GetState() != Entity.state.Sneak) DetectedPlayer();
    }

    public void DetectedPlayer()
    {
        attackPlayer = true;
        _myAnim.SetBool("Attack", true);
        AttackPlayer();
    }

    public void OutOfRange()
    {
        attackPlayer = false;
        _myAnim.SetBool("Attack", false);
    }

    void AudioPlay()
    {
        _soundEffect.Play();
    }
}
