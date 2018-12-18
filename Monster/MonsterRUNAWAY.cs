using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRUNAWAY : MonsterFSMState {

    public override void BeginState()
    {
        base.BeginState();
    }
    public override void EndState()
    {
        base.EndState();
    }
    // Update is called once per frame
    void Update () {
        
        //몬스터가 휴식할 위치에 도착하면
        if (Vector3.Distance(_manager.RestPos.position, transform.position) < 1f)
        {
            _manager.SetState(MonsterState.REST);
        }
        _manager.CC.CKMove(_manager.RestPos.position, _manager.Stat);
	}

}
