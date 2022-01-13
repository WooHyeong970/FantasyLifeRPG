using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField]
    private Text levelText;
    private Image experienceBarImage;

    private void Awake()
    {
        //levelText = transform.Find("Level_txt").GetComponent<Text>();
        experienceBarImage = transform.Find("ExpBar_img").GetComponent<Image>();

        SetExperienceBarSize(0.5f);
        SetLevelNumber(7);
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL " + levelNumber;
    }
}
