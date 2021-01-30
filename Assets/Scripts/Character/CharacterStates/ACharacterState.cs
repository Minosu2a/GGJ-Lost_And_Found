using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacterState : MonoBehaviour
{


	#region Fields
	protected CharacterStateController _controller = null;
	protected ECharacterState _state = ECharacterState.NONE;
	private Timer _timerEcho = null;
	#endregion Fields

	#region Properties
	public Timer TimerEcho => _timerEcho;
	#endregion Properties

	#region Methods
	public void Initialize(CharacterStateController controller, ECharacterState state)
	{
		_controller = controller;
		_state = state;
		_timerEcho = new Timer();
	}

	public abstract void EnterState();
	public abstract void UpdateState();
	public abstract void ExitState();

	#endregion Methods


  
}
