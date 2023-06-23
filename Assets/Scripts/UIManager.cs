using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTxt;
    [SerializeField] private TMP_Text heightTxt;


    private void OnEnable()
    {
        PlayerManager.OnScoreChange += ScoreUpdate;
        PlayerManager.OnHeightChange += HeightUpdate;
    }

    private void OnDisable()
    {
        PlayerManager.OnScoreChange -= ScoreUpdate;
        PlayerManager.OnHeightChange -= HeightUpdate;
    }

    private void ScoreUpdate(float score)
    {
        scoreTxt.SetText(score.ToString()+" $"); 
    }

    private void HeightUpdate(float height)
    {
        heightTxt.SetText(height.ToString()+" m");
    }
}
