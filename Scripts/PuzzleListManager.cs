using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleListManager : SingletonMonobehaviour<PuzzleListManager>
{
    [SerializeField] private List<GameObject> puzzlePieceList;

    private LevelImageSO currentLevelImageSO;

    private void Start()
    {
        UpdateScene();
    }
    public void UpdateScene()
    {
        currentLevelImageSO = PuzzleLevelManager.Instance.puzzleLevels[PuzzleLevelManager.Instance.currentLevel - 1];

        for (int i = 0; i < puzzlePieceList.Count; i++)
        {
            puzzlePieceList[i].gameObject.GetComponent<SpriteRenderer>().sprite = currentLevelImageSO.LevelImages[i];
        }
    }
}
