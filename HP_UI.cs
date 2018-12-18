using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour {
    CharacterStat _player;
    CharacterStat _enemy;
    public Text playerHPtxt;
    public Text enemyHPtxt;
    public Text enemyStatetxt;
    // Use this for initialization
    void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStat>();
        _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CharacterStat>();
    }

    public void Update()
    {
        playerHPtxt.text = "Player HP: " + _player.Hp;
        enemyHPtxt.text = "Enemy HP: " + _enemy.Hp;

        enemyStatetxt.text = "MonsterState: "+_enemy.GetComponent<MonsterFSMManager>().CurrentState;
    }
}
