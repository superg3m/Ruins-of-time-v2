using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropDown;
    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        dropDown.ClearOptions();
        AddingResolutionsToDropDown();
    }


    private void AddingResolutionsToDropDown()
    {
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropDown.AddOptions(options);
        dropDown.value = currentResolutionIndex;
        dropDown.RefreshShownValue();
    }


    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}