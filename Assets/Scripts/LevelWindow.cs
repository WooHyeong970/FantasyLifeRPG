using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Image experienceBarImage;
    private LevelSystem levelSystem;

    [SerializeField]
    private Button getExp;

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void Awake()
    {
        getExp.GetComponent<Button>().onClick.AddListener(() => levelSystem.AddExperience(15));
        getExp.GetComponent<Button>().onClick.AddListener(() => SetLevelSystem(levelSystem));
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL " + levelNumber;
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnLevelChanged(object sender, EventArgs e)
    {
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
}
