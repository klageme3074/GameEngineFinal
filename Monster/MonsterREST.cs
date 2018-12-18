using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterREST : MonsterFSMState
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        _manager.Stat.Hp += Time.deltaTime*10f;
        if (_manager.Stat.Hp > 70f)
        {
            _manager.SetState(MonsterState.IDLE);
        }
    }
}
