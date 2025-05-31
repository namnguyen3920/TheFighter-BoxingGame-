using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneMN : Singleton_Mono_Method<SceneMN>
{
    [Header("Enemy Prefabs (Names)")]
    public string mobName = "Mob";
    public string bossName = "Boss";

    [HideInInspector]
    public int selectedEnemyIndex = 1;

    public void SelectEnemy(int index) => selectedEnemyIndex = index;

    public void StartGame()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("GamePlay");

        StartCoroutine(WaitForSystemsAndActivate());
    }

    private IEnumerator WaitForSystemsAndActivate()
    {
        yield return null;

        GameObject container = GameObject.Find("EnemyContainer");
        string targetName = (selectedEnemyIndex == 1) ? bossName : mobName;
        Transform childTransform = container.transform.Find(targetName);
        GameObject prefabToActivate = childTransform.gameObject;

        prefabToActivate.SetActive(true);

        CharController enemyController = prefabToActivate.GetComponent<CharController>();
        if (enemyController != null && GameManager.d_Instance != null)
        {
            GameManager.d_Instance.RegisterEnemy(enemyController);
        }

        HealthMN enemyHealth = prefabToActivate.GetComponentInChildren<HealthMN>();
        if (enemyHealth != null && UIMN.d_Instance != null)
        {
            UIMN.d_Instance.SetupEnemyHealth(enemyHealth);
        }

        Destroy(gameObject);
    }
}
