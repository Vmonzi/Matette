using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Ivo Joaquín Aguilera

public class BaseCharacter : MonoBehaviour, IPlayer
{
    [Header("Stats")]
    [SerializeField] float _maxLife;
    [SerializeField] float _speed = 5;

    public float GetMaxLife     { get { return _maxLife; } }
    public float GetSpeed       { get { return _speed; } }
    public float GetCurrentLife { get { return _myController.GetCurrentLife(); } }

    [Header("Control Movement")]
    [SerializeField]    Rigidbody               _myRigidbody;
    [SerializeField]    Animator                _myAnim;
    [SerializeField]    Transform               _toRotate;
    [SerializeField]    Transform               _camera;
    [SerializeField]    CameraInteractCharacter _cameraInteract;

    public Rigidbody                GetRigidbody        { get { return _myRigidbody; } }
    public Animator                 GetAnimator         { get { return _myAnim; } }
    public Transform                GetRotator          { get { return _toRotate; } }
    public Transform                GetCamera           { get { return _camera; } }
    public CameraInteractCharacter  GetCameraInteract   { get { return _cameraInteract; } }

    [Header("Sensors")]
    [SerializeField] JumpSensor     _jumpSensor;
    [SerializeField] GrubBox        _sensorBox;
    [SerializeField] StandUpSensor  _canStand;

    [Header("Colliders")]
    public Collider crouch;
    public Collider stand;

    [Header("Feedback")]
    [SerializeField] FeedbackCharacter _feedback;
    public FeedbackCharacter UpdateFeedback { get { return _feedback; } }

    private bool        _canReceiveDamage;
    private float       _timeCantReceiveDamage  = 0;
    private Controller  _myController;

    public Controller GetController { get { return _myController; } }

    private void Awake()
    {
        _myController = new Controller(this, _jumpSensor, _sensorBox, _canStand);
    }

    // Start is called before the first frame update
    void Start()
    {
        _myController.SetCurrentLife(_maxLife);
        _canReceiveDamage   = true;

        _feedback.UpdateLife(_maxLife);
        _feedback.TextToDrop(false);
        _myController.SetActiveController(true);
    }

    private void Update()
    {
        if (_timeCantReceiveDamage >= 0)
        {
            _timeCantReceiveDamage -= Time.deltaTime;
            if (_timeCantReceiveDamage <= 0)
            {
                _canReceiveDamage = true;
                _feedback.ChangeColorBarLife(Color.white);
            }
        }
        _myController.ControllerUpdate();
    }

    private void FixedUpdate()
    {
        _myController.ControllerFixedUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 17)
        {
            _myController.SetState(Entity.state.Death);
        }
        if (other.gameObject.layer == 11)
        {
            other.GetComponent<PotionHP>().GetPwUP(this);
        }
        if(other.GetComponent<IHelpRobots>() != null)
        {
            other.GetComponent<IHelpRobots>().Text();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<IHelpRobots>() != null && Input.GetKeyDown(KeyCode.Q))
        {
            other.GetComponent<IHelpRobots>().HelpText();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<IHelpRobots>() != null)
        {
            collision.GetComponent<IHelpRobots>().ExitHelpText();
        }
    }

    public void ReceiveDamage(float damage)
    {
        if (_canReceiveDamage)
        {
            _myController.SetCurrentLife(_myController.GetCurrentLife() - damage);

            StartCoroutine(UpdateLifeBar());
            _feedback.ChangeColorBarLife(Color.red);
            _feedback.SoundDamage();
            _feedback.ChangePitch(1.0f);

            _feedback.PlaySound();

            //isDeath?
            if (_myController.GetCurrentLife() <= 0)
            {
                _myController.SetState(Entity.state.Death);
                GameManager.InstanceGameManager.LoadLevel("Lose");
                _myController.SetActiveController(false);
            }
            else
            {
                _sensorBox.grubbed = false;
                _feedback.TextToDrop(false);
                if (!_jumpSensor.IsFalling())
                {
                    _myController.SetState(Entity.state.Hurt);
                }
            }
            _canReceiveDamage = false;
            _timeCantReceiveDamage = 1.0f;
        }
    }

    public void AddLife(float lifeToAdd)
    {
        _myController.SetCurrentLife(_myController.GetCurrentLife() + lifeToAdd);
        if(_myController.GetCurrentLife() > _maxLife)
        {
            _myController.SetCurrentLife(_maxLife);
        }
        StartCoroutine(UpdateLifeBar());
    }

    public void AddSpeed(float speedToAdd, float timeToResetSpeed)
    {
        _myController.SetSpeed(_myController.GetSpeed() + speedToAdd);
        Invoke("ResetSpeed", timeToResetSpeed);
    }

    private void ResetSpeed()
    {
        _myController.SetSpeed(_speed);
    }

    public void EndJump()
    {
        _myController.SetState(Entity.state.IDLE);
    }

    public void EndHurt()
    {
        _myAnim.SetBool("Hurt", false);
        _myController.SetState(Entity.state.IDLE);
    }

    IEnumerator UpdateLifeBar()
    {
        _feedback.UpdateLife(_myController.GetCurrentLife() / _maxLife);
        yield return new WaitForEndOfFrame();
    }

    public void ColliderCrouch()
    {
        crouch.enabled = true;
        stand.enabled = false;
    }

    public void ColliderStand()
    {
        crouch.enabled = false;
        stand.enabled = true;
    }
}
