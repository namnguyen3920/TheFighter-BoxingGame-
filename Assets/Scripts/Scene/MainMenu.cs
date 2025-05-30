using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton_Mono_Method<MainMenu>
{
    [Header("For Game Mode Settings")]
    [SerializeField] RectTransform StartPanel;
    [SerializeField] RectTransform PickContentPanel;
    [SerializeField] RectTransform PlayWithPanel;

    public void OnStartGameBtn()
    {
        StartPanel.gameObject.SetActive(false);
        PickContentPanel.gameObject.SetActive(true);
    }
    public void OnPickOpponent()
    {
        PickContentPanel.gameObject.SetActive(false);
        PlayWithPanel.gameObject.SetActive(true);
    }
    public void OnClickRedFighter()
    {
        SceneMN.d_Instance.SelectEnemy(1);
        SceneMN.d_Instance.StartGame();
    }

    public void OnClickHobo()
    {
        SceneMN.d_Instance.SelectEnemy(2);
        SceneMN.d_Instance.StartGame();
    }
    public void OnMoveToGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }
    
}
