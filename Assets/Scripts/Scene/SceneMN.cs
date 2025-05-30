using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMN : Singleton_Mono_Method<SceneMN>
{
    [Header("Enemy Prefabs")]
    public GameObject hoboPrefab;
    public GameObject bossPrefab;
    [HideInInspector]
    public int selectedEnemyIndex = 1;

    public void SelectEnemy(int index)
    {
        selectedEnemyIndex = index;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    

}
