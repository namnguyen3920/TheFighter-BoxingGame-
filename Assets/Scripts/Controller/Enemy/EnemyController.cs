
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyController : CharController
{
    [SerializeField] CharacterStats _enemy;

    [Header("Decision Time")]
    [SerializeField] private float minWait = 2f;
    [SerializeField] private float maxWait = 12f;

    protected override void Awake()
    {
        base.Awake();
        _charRegistry = new Dictionary<CharacterAction, IPowerScaler>()
        {
            { CharacterAction.Attack, new EnemyAttackScaler(this, _enemy.Damage) },
            { CharacterAction.Block, new EnemyBlockScaler(this, _enemy.Endurance) },
        };
    }

    private void Start()
    {
        StartEnemyAction();
        GameManager.d_Instance.OnTurnEnd += StartEnemyAction;
    }

    public void StartEnemyAction()
    {
        StartCoroutine(EnemyRandomAction());
    }

    private IEnumerator EnemyRandomAction()
    {
        _charCurrAction = (CharacterAction)UnityEngine.Random.Range(0, Enum.GetNames(typeof(CharacterAction)).Length);

        float wait = UnityEngine.Random.Range(minWait, maxWait);
        yield return new WaitForSeconds(wait);

        HandleCharacterAction(_charCurrAction);
    }

}
