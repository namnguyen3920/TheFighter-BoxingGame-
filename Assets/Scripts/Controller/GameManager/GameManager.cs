using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : Singleton_Mono_Method<GameManager>
{
    public float turnDuration = 20f;
    public PlayerController player;
    public CharController enemy;
    private bool _isGameOver;

    [SerializeField]
    private List<ActionProperties> _turnQueue = new List<ActionProperties>();
    public event Action OnTurnEnd;

    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy").GetComponent<CharController>();
        UIMN.d_Instance.ShowEnemyStats(enemy);
        OnTurnEnd += ResetTurn;
        StartCoroutine(TurnLoop());
    }
    private IEnumerator TurnLoop()
    {
        while (!_isGameOver)
        {
            float timer = turnDuration;
            UIMN.d_Instance.TurnTimerUpdate(timer);
            while (timer > 0f && _turnQueue.Count < 2)
            {
                timer -= Time.deltaTime;
                UIMN.d_Instance.TurnTimerUpdate(timer);
                yield return null;
            }

            yield return StartCoroutine(ProcessQueue());

            bool playerDead = player.healthMN.CurrentHealth <= 0f;
            bool enemyDead = enemy.healthMN.CurrentHealth <= 0f;

            if (playerDead || enemyDead)
            {
                if (playerDead)
                    player.CharacterChangeState(player.characterKnockOutState);
                if (enemyDead)
                    enemy.CharacterChangeState(enemy.characterKnockOutState);

                _isGameOver = true;

                yield return new WaitForSeconds(4f);

                if (playerDead && enemyDead)
                    UIMN.d_Instance.ShowEndGameUI(EndGame.Draw);
                else if (enemyDead)
                    UIMN.d_Instance.ShowEndGameUI(EndGame.YouWin);
                else
                    UIMN.d_Instance.ShowEndGameUI(EndGame.YouLose);

                yield break;
            }

            OnTurnEnd?.Invoke();
        }
    }
    private IEnumerator ProcessQueue()
    {
        var entries = _turnQueue.ToArray();
        int remaining = entries.Length;
        foreach (var entry in entries)
        {
            StartCoroutine(ExecuteAciton(entry, () => --remaining));
        }
        yield return new WaitUntil(() => remaining == 0);
        _turnQueue.Clear();
    }
    private IEnumerator ExecuteAciton(ActionProperties entry, Action onComplete)
    {
        
        switch (entry.CharacterAction)
        {
            case CharacterAction.Attack:
                yield return StartCoroutine(CharacterAttackHandler(entry));
                break;
            case CharacterAction.Block:
                yield return StartCoroutine(CharacterBlockHandler(entry));
                break;
        }
        onComplete();
    }
    public void AssignAction(ActionProperties charProperties)
    {
        _turnQueue.Add(charProperties);

        if (charProperties.Character is PlayerController)
            UIMN.d_Instance.OnPlayerSliderUpdate(charProperties.ScaledValue);

        if (charProperties.Character is EnemyController)
            UIMN.d_Instance.OnEnemySliderUpdate(charProperties.ScaledValue);
    }
    private IEnumerator CharacterAttackHandler(ActionProperties entry)
    {
        if(entry.Character is PlayerController)
        {
            yield return StartCoroutine(UIMN.d_Instance.OnPlayerActionUpdated(CharacterAction.Attack));
        } 
        else
        {
            yield return StartCoroutine(UIMN.d_Instance.OnEnemyActionUpdated(CharacterAction.Attack));
        }

        var targetHealth = entry.Opponent.healthMN.CurrentHealth;

        if (targetHealth > 0)
        {
            entry.Character.CharacterChangeState(entry.Character.characterCombatState);
            entry.Opponent.healthMN.ApplyDamage(entry.ScaledValue);
        }

        
    }
    private IEnumerator CharacterBlockHandler(ActionProperties entry)
    {
        if (entry.Character is PlayerController)
        {
            yield return StartCoroutine(UIMN.d_Instance.OnPlayerActionUpdated(CharacterAction.Block));
        }
        else
        {
            yield return StartCoroutine(UIMN.d_Instance.OnEnemyActionUpdated(CharacterAction.Block));
        }

        entry.Character.healthMN.BlockDamage(entry.ScaledValue);
    }
    
private void ResetTurn()
    {
        player.p_action.EnableInput();
    }
}

