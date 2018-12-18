using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimEvent : MonoBehaviour
{
    MonsterFSMManager _manager;
	// Use this for initialization
	void Awake () {
        _manager = transform.root.GetComponent<MonsterFSMManager>();
	}

    void PunchHitCheck()
    {
        MonsterATTACK attackState = _manager.CurrentStateComponent as MonsterATTACK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }

    void RageHitCheck()
    {
        MonsterRAGEATTACK attackState = _manager.CurrentStateComponent as MonsterRAGEATTACK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }

    void PunchAnimEnd()
    {
        MonsterATTACK attackState = _manager.CurrentStateComponent as MonsterATTACK;
        if (null != attackState)
        {
            attackState.AnimEnd();
        }

    }
    void RageAnimEnd()
    {
        MonsterRAGEATTACK attackState = _manager.CurrentStateComponent as MonsterRAGEATTACK;
        if (null != attackState)
        {
            attackState.AnimEnd();
        }
    }

}
