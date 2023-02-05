using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button optionsButton;


    private void Awake()
    {
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();

        });

        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        optionsButton.onClick.AddListener(() => {
            OptionsUI.Instance.Show();
        });

    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManagerOnGamePaused;
        KitchenGameManager.Instance.OnGameUnPaused += KitchenGameManagerOnGameUnPaused;
        
        Hide();
    }

    private void KitchenGameManagerOnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void KitchenGameManagerOnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
