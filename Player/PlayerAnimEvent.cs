using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEvent : MonoBehaviour
{
    FSMManager _manager;
    private void Awake()
    {
        _manager = transform.root.GetComponent<FSMManager>();
    }

    void PunchHitCheck()
    {
        PlayerPUNCH attackState = _manager.CurrentStateComponent as PlayerPUNCH;
        if(null != attackState)
        {
            attackState.AttackCheck();
        }
    }

    void KickHitCheck()
    {
        PlayerKICK attackState = _manager.CurrentStateComponent as PlayerKICK;
        if (null != attackState)
        {
            attackState.AttackCheck();
        }
    }

    void PunchAnimEnd()
    {
        PlayerPUNCH attackState = _manager.CurrentStateComponent as PlayerPUNCH;
        if (null != attackState)
        {
            attackState.AnimEnd();
        }
        
    }
    void KickAnimEnd()
    {
        PlayerKICK attackState = _manager.CurrentStateComponent as PlayerKICK;
        if (null != attackState)
        {
            attackState.AnimEnd();
        }
    }

}
