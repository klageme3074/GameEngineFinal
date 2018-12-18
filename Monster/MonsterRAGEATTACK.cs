using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRAGEATTACK : MonsterFSMState {

    int postIndex;

    private void Start()
    {
        postIndex = 0;
    }

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

    }

    public void AttackCheck()
    {
        CharacterStat targetStat =
            _manager.Target.GetComponent<CharacterStat>();
        CharacterStat.ProcessDamage(_manager.Stat, targetStat);
    }

    public void AnimEnd()
    {
        Telleport();
        _manager.SetState(MonsterState.IDLE);
    }

    private void Telleport()
    {
        int randIndex = Random.Range(0, 4);
        while (randIndex == postIndex)
        {
            randIndex = Random.Range(0, 4);
        }
        switch (randIndex)
        {
            case 0:
                transform.position = _manager.Target.transform.position + new Vector3(1f, 0f, 0f);
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
                break;
            case 1:
                transform.position = _manager.Target.transform.position + new Vector3(-1f, 0f, 0f);
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 2:
                transform.position = _manager.Target.transform.position + new Vector3(0f, 0f, 1f);
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 3:
                transform.position = _manager.Target.transform.position + new Vector3(0f, 0f, -1f);
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
        }
        postIndex = randIndex;
    }

}
