using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    private Button restartBtn;
    private Button returnBtn;

    private Transform winScene;
    private Button nextLevelBtn;
    private Button winSceneRestartBtn;
    private Button mainMenuBtn;
    private void Awake()
    {
        restartBtn = transform.Find("restartBtn").GetComponent<Button>();
        returnBtn = transform.Find("returnBtn").GetComponent<Button>();
        winScene = transform.Find("WinScene");

        nextLevelBtn = winScene.transform.Find("nextLevelBtn").GetComponent<Button>();
        winSceneRestartBtn = winScene.transform.Find("restartBtn").GetComponent<Button>();
        mainMenuBtn = winScene.transform.Find("mainMenuBtn").GetComponent<Button>();

        restartBtn.onClick.AddListener(() =>
        {

            Restart();
        });
        returnBtn.onClick.AddListener(() =>
        {

            LoadMainMenu();
        });

        ////////// On Win /////////////////

        nextLevelBtn.onClick.AddListener(() =>
        {

            int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
            if (currentLevel < 8)
            {
                currentLevel++;
            }


            PlayerPrefs.SetInt("currentLevel", currentLevel);

            int highestLevel = PlayerPrefs.GetInt("highestLevel", 1);
            if (highestLevel < currentLevel)
            {
                PlayerPrefs.SetInt("highestLevel", currentLevel);
            }
            else
            {
                PlayerPrefs.SetInt("highestLevel", highestLevel);
            }

            Restart();



        });

        winSceneRestartBtn.onClick.AddListener(() =>
        {

            Restart();
        });
        mainMenuBtn.onClick.AddListener(() =>
        {

            LoadMainMenu();
        });



    }


    private void Restart()
    {
        SoundManager.Instance.PlayClip(GameResources.Instance.clickAudioClip, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadMainMenu()
    {
        SoundManager.Instance.PlayClip(GameResources.Instance.clickAudioClip, 1f);
        SceneManager.LoadScene("MainMenu");
    }


    private void OnEnable()
    {
        //Subscribe to win event
        PieceManager.Instance.OnWin += Instance_OnWin;
    }

    private void OnDisable()
    {
        //Unsubscribe from win event
        PieceManager.Instance.OnWin -= Instance_OnWin;
    }


    private void Instance_OnWin(PieceManager obj)
    {
        LeanTween.moveLocalY(winScene.gameObject, 0f, 1f);


    }
    public void PlayHoverSound()
    {
        SoundManager.Instance.PlayClip(GameResources.Instance.btnHoverAudioClip, 0.5f);
    }

}
