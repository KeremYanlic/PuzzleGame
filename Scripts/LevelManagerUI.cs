using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class LevelManagerUI : MonoBehaviour
{
    private int levelReached;

    [SerializeField] private List<Button> levelBtns;

    [SerializeField] private Color nonInteractableColor;
    [SerializeField] private Color interactableColor;
    private void Start()
    {
        levelReached = PlayerPrefs.GetInt("highestLevel", 1);

        for (int i = 0; i < levelBtns.Count; i++)
        {
            if (i + 1 > levelReached)
            {
                levelBtns[i].interactable = false;
            }
        }

        foreach (Button btn in levelBtns)
        {
            if (btn.interactable)
            {
                btn.gameObject.GetComponent<Image>().color = interactableColor;
                btn.gameObject.GetComponent<ButtonManager>().canScale = true;
            }
            else
            {
                btn.gameObject.GetComponent<Image>().color = nonInteractableColor;
                btn.gameObject.GetComponent<ButtonManager>().canScale = false;

            }
        }
    }


    public void ChooseLevel(int levelIndex)
    {
        SceneManager.LoadScene("GameMenu");

        PlayerPrefs.SetInt("currentLevel", levelIndex);
    }
}
