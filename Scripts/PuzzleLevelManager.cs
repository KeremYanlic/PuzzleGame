using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLevelManager : SingletonMonobehaviour<PuzzleLevelManager>
{
    public int currentLevel = 1;

    public List<LevelImageSO> puzzleLevels;
    protected override void Awake()
    {
        base.Awake();
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }

}
