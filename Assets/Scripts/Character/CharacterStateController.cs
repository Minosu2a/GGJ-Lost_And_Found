using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private float _sprintSpeed = 500f;
    [SerializeField] private float _airControlForce = 250f;

    private bool _isGrounded = false;
    private RaycastHit _hit;

    private ECharacterState _currenStateType = ECharacterState.NONE;
    private Dictionary<ECharacterState, ACharacterState> _states = null;
    #endregion Fields


    #region Properties
    public Rigidbody Rb => _rb;
    public ACharacterState CurrentState => _states[_currenStateType];

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

        

        _currenStateType = ECharacterState.IDLE;
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
