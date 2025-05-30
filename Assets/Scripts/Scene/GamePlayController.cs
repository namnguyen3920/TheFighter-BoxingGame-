using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    [Header("Spawn Point")]
    public Transform spawnPoint;

    private void Start()
    {
        GameObject prefabToSpawn = (SceneMN.d_Instance.selectedEnemyIndex == 1)
            ? SceneMN.d_Instance.bossPrefab
            : SceneMN.d_Instance.hoboPrefab;

        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
    }    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
