using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{

    [SerializeField] Transform _target;
    [SerializeField] Transform _wall;
    [SerializeField] Transform _point1;
    [SerializeField] float _speed;
    [SerializeField] float _dmg;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _wallObj;
    [SerializeField] ButtonsBreakWall _delegeteMovement;
    [SerializeField] ParedDestroy _pared;
    bool _move;


    private void Start()
    {
        _move = false;
        _target = _point1;

        //_delegeteMovement.audioEvent = AudioPlay;
        _delegeteMovement.activateWall += UpdateRange;

    }
    public void Update()
    {
        var distance = Vector3.Distance(transform.position, _target.position);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
         
        if (_move)
        {
            _target = _wall;
           
        }
        else
        {
            _target = _point1;
        }
    }

    public void UpdateRange ()
    {
        _move = true;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<BaseCharacter>().ReceiveDamage(_dmg);
        }
        else if(other.gameObject == _wallObj)
        {
            _pared._audio.Play();
            Destroy(gameObject, 0.5f);
            
        }
      
    }


    //public void AudioPlay()
    //{
    //    _audio.Play();
    //}




}
