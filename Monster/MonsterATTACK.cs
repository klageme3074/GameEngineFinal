using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterATTACK : MonsterFSMState {

    public override void BeginState()
    {
        base.BeginState();
        if (_manager.Stat.Hp <= 70)
            _manager.SetState(MonsterState.RAGEATTACK);
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        if (Vector3.Distance(_manager.PlayerTransform.position, transform.position) >= _manager.Stat.AttackRange)
        {
            _manager.SetState(MonsterState.CHASE);
            return;
        }

    }

    public void AttackCheck()
    {
        CharacterStat targetStat =
            _manager.Target.GetComponent<CharacterStat>();

        CharacterStat.ProcessDamage(_manager.Stat, targetStat);
    }

    public void AnimEnd()
    {
        _manager.SetState(MonsterState.IDLE);
    }

}
