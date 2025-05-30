using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIMN : Singleton_Mono_Method<UIMN>
{
    [SerializeField] private RectTransform gameUI;
    [SerializeField] private HealthMN playerHealth;
    [SerializeField] private HealthMN enemyHealth;
    [SerializeField] private CharacterStats _player;

    [Header("Player UI")]
    [SerializeField] private TMP_Text playerMaxHealth;
    [SerializeField] private TMP_Text playerCurrentHealth;
    [SerializeField] private TMP_Text playerAction;
    [SerializeField] private TMP_Text playerEndurance;
    [SerializeField] private TMP_Text playerStrength;

    [Header("Enemy UI")]
    [SerializeField] private TMP_Text enemyMaxHealth;
    [SerializeField] private TMP_Text enemyCurrentHealth;
    [SerializeField] private TMP_Text enemyAction;
    [SerializeField] private TMP_Text enemyEndurance;
    [SerializeField] private TMP_Text enemyStrength;

    [Header("Game UI")]
    [SerializeField] private TMP_Text playerSliderValue;
    [SerializeField] private TMP_Text enemySliderValue;
    [SerializeField] private TMP_Text turnTimer;
    [SerializeField] private RectTransform EndGamePanel;
    [SerializeField] private TMP_Text GameResult;

    private void Awake()
    {
        var findEnemy = GameObject.FindWithTag("EnemyHealth");;
        gameUI = GetComponentInChildren<RectTransform>();
        if (findEnemy != null)
            enemyHealth = findEnemy.GetComponent<HealthMN>();
    }
    private void Start()
    {
        playerEndurance.text = _player.Endurance.ToString();
        playerStrength.text = _player.Damage.ToString();
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation*Vector3.forward, Camera.main.transform.rotation*Vector3.up);
    }

    public void OnPlayerSliderUpdate(float value)
    {
        playerSliderValue.text = value.ToString();
    }

    public void OnEnemySliderUpdate(float value)
    {
        enemySliderValue.text = value.ToString();
    }

    public void OnPlayerHealthUpdated(float current, float max)
    {
        playerCurrentHealth.text = current.ToString();
        playerMaxHealth.text = max.ToString();
    }

    public void OnEnemyHealthUpdated(float current, float max)
    {
        enemyCurrentHealth.text = current.ToString();
        enemyMaxHealth.text = max.ToString();
    }

    public void ShowEnemyStats(CharController enemy)
    {
        enemyEndurance.text = enemy.characterStats.Endurance.ToString();
        enemyStrength.text = enemy.characterStats.Damage.ToString();
    }

    public IEnumerator OnPlayerActionUpdated(CharacterAction p_action)
    {
        playerAction.gameObject.SetActive(true);
        playerAction.text = p_action.ToString();

        yield return new WaitForSeconds(2f);

        playerAction.gameObject.SetActive(false);
    }

    public IEnumerator OnEnemyActionUpdated(CharacterAction e_action)
    {
        enemyAction.gameObject.SetActive(true);
        enemyAction.text = e_action.ToString();

        yield return new WaitForSeconds(2f);

        enemyAction.gameObject.SetActive(false);
    }
    public void TurnTimerUpdate(float timer)
    {
        turnTimer.text = Mathf.CeilToInt(timer).ToString();
    }
    public void ShowEndGameUI(EndGame result)
    {
        EndGamePanel.gameObject.SetActive(true);

        switch (result)
        {
            case EndGame.YouWin:
                GameResult.text = "You Win";
                break;
            case EndGame.YouLose:
                GameResult.text = "You Lose";
                break;
            case EndGame.Draw:
                GameResult.text = "Draw";
                break;
        }
    }

    private void OnEnable()
    {
        playerHealth.OnHealthUpdated += OnPlayerHealthUpdated;
        enemyHealth.OnHealthUpdated += OnEnemyHealthUpdated;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthUpdated -= OnPlayerHealthUpdated;
        enemyHealth.OnHealthUpdated -= OnEnemyHealthUpdated;
    }

}
