using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStateController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Rigidbody _rb = null;
    [Header("Physic")]
    [SerializeField] private LayerMask _groundLayer = 0;
    [SerializeField] private float _groundThreshold = 1.1f;
    [SerializeField] private float _castRadius = 0.45f;
    [Header("Speeds")]
    [SerializeField] private float _walkSpeed = 250f;
    [SerializeField] private float _airControlForce = 250f;

    [SerializeField] private GameObject _teleportPosition1 = null;
    [SerializeField] private GameObject _teleportPosition2 = null;
    [SerializeField] private GameObject _teleportPosition3 = null;
    private int _levelNumber = 0;

    [SerializeField] private float _delayOfAnimInteraction = 4f;
    [SerializeField] private float _delayOfTeleport = 2f;
    private bool _animationInteractionFinished = false;
    private bool _fadeOutAnimationFinished = false;
    private bool temp_ = false;


    private float _timeStamp = 0f;


    private bool _isGrounded = false;
    private RaycastHit _hit;

    private ECharacterState _currenStateType = ECharacterState.NONE;
    private Dictionary<ECharacterState, ACharacterState> _states = null;
    private bool _inRangeOfTrigger = false;
    #endregion Fields


    #region Properties
    public Rigidbody Rb => _rb;
    public ACharacterState CurrentState => _states[_currenStateType];

    public bool AnimationInteractionFinished
    {
        get
        {
           return _animationInteractionFinished;
        }
        set
        {
            _animationInteractionFinished = value;
        }
    }
    public bool IsGrounded => _isGrounded;
	#endregion Properties


	#region Methods

    void Start()
    {
        _states = new Dictionary<ECharacterState, ACharacterState>();

        IdleState idleState = new IdleState();
        idleState.Initialize(this, ECharacterState.IDLE);
        _states.Add(ECharacterState.IDLE, idleState);

        WalkState walkState = new WalkState();
        walkState.Initialize(this, ECharacterState.WALK);
        _states.Add(ECharacterState.WALK, walkState);

        InteractionState interactionState = new InteractionState();
        interactionState.Initialize(this, ECharacterState.INTERACTION);
        _states.Add(ECharacterState.INTERACTION, interactionState);

        _currenStateType = ECharacterState.IDLE;

        InputManager.Instance.OnInteractionKeyPressed += CarillonCheck;

    }
    private void Update()
    {
        if(_rb.velocity.x > 0)
        {
            transform.forward = Vector3.right;
        }
        else if (_rb.velocity.x < 0)
        {
            transform.forward = Vector3.left;
        }
        if(_rb.velocity.z > 0)
        {
            transform.forward = Vector3.forward;
        }
        else if (_rb.velocity.z < 0)
        {
            transform.forward = Vector3.back;
        }
    }
    public void FixedUpdate()
    {
        CurrentState.UpdateState();

        _isGrounded = Physics.SphereCast(transform.position, _castRadius, Vector3.down, out _hit, _groundThreshold, _groundLayer);
    }

    public void ChangeState(ECharacterState newState)
    {
        Debug.Log("Transition from " + _currenStateType + " to " + newState);
        CurrentState.ExitState();
        _currenStateType = newState;
        CurrentState.EnterState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Carillon")
        {
           _inRangeOfTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Carillion")
        {
            _inRangeOfTrigger = false;
        }
    }

    public void CarillonCheck()
    {
        if (_inRangeOfTrigger == true)
        {
            ChangeState(ECharacterState.INTERACTION);
        }
    }

    public void Interaction()
    {
        _timeStamp += Time.deltaTime;

       if(_timeStamp >= _delayOfAnimInteraction && _animationInteractionFinished == false)
       {
            //ANIMATION DU CARILLON QUI SE FAIT MANGER
            _timeStamp = 0;
            _animationInteractionFinished = true;
            Debug.Log("Interaction Animation is finished");
       }

       if(_animationInteractionFinished == true)
       {
            //DEBUT ANIMATION DU TELEPORT (YEUX QUI SE FERME ETC...)
           // UIManager.Instance.FadeInGo = true;
            Debug.Log("FadeIn");
            _animationInteractionFinished = false;
       }

       if (_timeStamp >= _delayOfTeleport && _fadeOutAnimationFinished == false)
       {
            //TELEPORT PENDANT UN ECRAN NOIR 
            switch (_levelNumber)
            {
                case 1:
                    this.gameObject.transform.position = _teleportPosition1.transform.position;
                break;
                case 2:
                  //  this.gameObject.transform.position = _teleportPosition1.transform.position;
                    break;

            }
            _levelNumber++;
            _timeStamp = 0;
            _fadeOutAnimationFinished = true;
            UIManager.Instance.FadeInGo = true;
        }

       if(_timeStamp >= _delayOfTeleport && _fadeOutAnimationFinished == true) //SUREMENT UN NOUVEAU TIMER A FAIRE
       {
            //DEBUT DU NIVEAU
            ChangeState(ECharacterState.IDLE);
            UIManager.Instance.FadeOutGo = true;
            _fadeOutAnimationFinished = false;
            _timeStamp = 0;

       }
    }

    public void Walk()
    {
        _rb.velocity = InputManager.Instance.MoveDir * _walkSpeed;
    }

    public void Echo()
    {
        Debug.Log("Echo");
    }

    #endregion Methods



}
