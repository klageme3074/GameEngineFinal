using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    IDLE = 0,
    MOVE,
    PUNCH,
    KICK,
    DEAD
}

[RequireComponent(typeof(PlayerStat))]
[ExecuteInEditMode]
public class FSMManager : MonoBehaviour, IFSMManager
{
    private bool _isinit = false;
    public PlayerState startState = PlayerState.IDLE;
    private Dictionary<PlayerState, FSMState> _states = new Dictionary<PlayerState, FSMState>();

    [SerializeField]
    private PlayerState _currentState;
    public PlayerState CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    public FSMState CurrentStateComponent
    {
        get { return _states[_currentState]; }
    }
    

    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private PlayerStat _stat;
    public PlayerStat Stat { get { return _stat; } }

    private Transform _target;
    public Transform Target { get { return _target; } }

    private Animator _anim;
    public Animator Anim { get { return _anim; } }

    private Camera _sight;
    public Camera Sight { get { return _sight; } }

    public CharacterController testTarget;
    

    public int clickLayer = 0;
    public int sightAspect = 3;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<PlayerStat>();
        _anim = GetComponentInChildren<Animator>();
        _sight = GetComponentInChildren<Camera>();
        _target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        //_sight.aspect = sightAspect;

        PlayerState[] stateValues = (PlayerState[])System.Enum.GetValues(typeof(PlayerState));
        foreach (PlayerState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Player" + s.ToString());
            FSMState state = (FSMState)GetComponent(FSMType);
            if(null == state)
            {
                state = (FSMState)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }
    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public void SetState(PlayerState newState)
    {
        if(_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
        _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Update()
    {
    }

    private void OnDrawGizmos()
    {
        if(_sight != null)
        {
            Gizmos.color = Color.blue;
            Matrix4x4 temp = Gizmos.matrix;

            Gizmos.matrix = Matrix4x4.TRS(
                _sight.transform.position,
                _sight.transform.rotation,
                Vector3.one
                );

            Gizmos.DrawFrustum(
                _sight.transform.position,
                _sight.fieldOfView,
                _sight.farClipPlane,
                _sight.nearClipPlane,
                _sight.aspect
                );

            Gizmos.matrix = temp;
        }
    }

    public void NotifyTargetKilled()
    {
        SetState(PlayerState.IDLE);
    }

    public void SetDeadState()
    {
        SetState(PlayerState.DEAD);
    }
}
