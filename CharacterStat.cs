using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    private float _hp = 100.0f;
    public float Hp { get { return _hp; } set { _hp = value; } }
    
    private float _moveSpeed = 3.0f;
    public float MoveSpeed { get { return _moveSpeed; } }
    
    private float _turnSpeed = 540.0f;
    public float TurnSpeed { get { return _turnSpeed; } }
    
    private float _attackRange = 2.0f;
    public float AttackRange { get { return _attackRange; } }

    private float _power = 2.0f;
    public float Power { get { return _power; } }

    public CharacterStat lastHitBy = null;

    public void TakeDamage(CharacterStat from, float damage)
    {
        _hp = Mathf.Clamp(_hp - damage, 0, 500);
        if(_hp <= 0)
        {
            if (lastHitBy == null)
                lastHitBy = from;

            GetComponent<IFSMManager>().SetDeadState();
            from.GetComponent<IFSMManager>().NotifyTargetKilled();
            Debug.Log(name + " is Killed by " + lastHitBy.name);
        }
        
    }

    private static float CalcDamage(CharacterStat from, CharacterStat to)
    {
        return from._power;
    }

    public static void ProcessDamage(CharacterStat from, CharacterStat to)
    {
        float finalDamage = CalcDamage(from, to);
        to.TakeDamage(from, finalDamage);

        if (to.tag == "Enemy" && to._hp <= 30 && to._hp!=0)
        {
            to.GetComponent<MonsterFSMManager>().SetState(MonsterState.RUNAWAY);
        }
    }

    public void initStat(StatData data)
    {
        _hp = data.maxHp;
        _moveSpeed = data.MoveSpeed;
        _turnSpeed = data.TurnSpeed;
        _attackRange = data.AttackRange;
        _power = data.Power;
    }
}
