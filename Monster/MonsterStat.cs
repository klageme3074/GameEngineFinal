using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStat : CharacterStat
{
    public StatData monsterStat;

    private void Awake()
    {
        initStat(monsterStat);
    }
}
