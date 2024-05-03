using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eusebio : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    public Rigidbody pjRb;
    VisionRange _alertaR;
    public float damage;
    [SerializeField] float _speed;
    public float range;
    public LayerMask pj;
    [SerializeField] bool _alerta;
    public Animator anim;
    public Collider area;
    EnemyMov movEnemy;
    public Collider pjCollider;
    public AudioSource myAudio;
    public AudioClip muerte;
    public AudioClip alien;
    public GameObject blood;

    public void Start()
    {
        _alertaR = new VisionRange(transform, range, _alerta, pj);
        movEnemy = new EnemyMov(_rb, pjRb, _speed);

        anim.SetBool("Walking", false);
        anim.SetBool("Attack", false);
        anim.SetBool("Death", false);

        myAudio.clip = alien;
        myAudio.Play();
    }

    public void Update()
    {
        _alertaR.VisionRangeUpdate();
        var distance = Vector3.Distance(pjRb.position, _rb.position);

        if (_alertaR._alerta && anim.GetBool("Death") == false)
        {
            anim.SetBool("Walking", true);
            anim.SetBool("Attack", false);
            
            if (distance <= 2.5f) Attack();
            else movEnemy.EnemyMovement();
        }
        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Attack", false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_rb.position, range);
    }
    public void Punch()
    {
        area.enabled = true;
    }
    public void DontPunch()
    {
        area.enabled = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 15 && other.GetComponent<JumpSensor>())
        {
            JumpSensor sensorPJ = other.GetComponent<JumpSensor>();
            if (sensorPJ.IsFalling() && !this.GetComponent<Collider>().isTrigger)
            {
                _speed = 0;
                myAudio.Stop();
                myAudio.clip = muerte;
                myAudio.Play();
                anim.SetBool("Death", true);
            }
        }
    }

    public void Attack()
    {
        anim.SetBool("Attack", true);
        anim.SetBool("Walking", false);
    }

    public void DestroyAndBlood()
    {
        Destroy(this.gameObject);
        Instantiate(blood, transform.position, Quaternion.identity);
    }
}
