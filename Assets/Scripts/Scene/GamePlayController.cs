using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public void OnBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
