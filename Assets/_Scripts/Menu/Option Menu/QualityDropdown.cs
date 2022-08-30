using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropDown;
    public void SetQuality(int qaulityIndex)
    {
        QualitySettings.SetQualityLevel(qaulityIndex);
    }
}
