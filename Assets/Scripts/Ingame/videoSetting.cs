using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGame : MonoBehaviour
{
    public Toggle fullscreenc;
    FullScreenMode screenMode;
    List<Resolution> resolutions = new List<Resolution>();
    public Dropdown resolutionsDropdown;
    public int resolutionNum;
    // Start is called before the first frame update
    void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60){
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutions.AddRange(Screen.resolutions);
        resolutionsDropdown.options.Clear();

        int optionNum = 0;

        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            int height1 = item.width * 9/16;
            option.text = item.width + " × " + height1 + " " + item.refreshRateRatio + "p";
            resolutionsDropdown.options.Add(option);

            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionsDropdown.value = optionNum;
            }
            optionNum ++;
        }
        resolutionsDropdown.RefreshShownValue();

        fullscreenc.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenChk(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void OKclick()
    {
        int rightheight = resolutions[resolutionNum].width * 9/16;
        Screen.SetResolution(resolutions[resolutionNum].width, rightheight, screenMode);
    }
}
