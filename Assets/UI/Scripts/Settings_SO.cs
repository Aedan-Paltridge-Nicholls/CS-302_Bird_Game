using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

using static Settings_SO.ResolutionList;
using RangeAttribute = UnityEngine.RangeAttribute;

[CreateAssetMenu(fileName = "Settings_SO", menuName = "Scriptable Objects/Settings_SO")]
public class Settings_SO : ScriptableObject
{
    [System.Serializable]
    public class Mixer
    {
        [DefaultValue(0.4f)]
        [Range(0.0001f,1f)]
        public float MasterVolume;
        [DefaultValue(0.4f)]
        [Range(0.0001f, 1f)]
        public float MusicVolume;
        [DefaultValue(0.4f)]
        [Range(0.0001f, 1f)]
        public float SFXVolume;
        [DefaultValue(0.4f)]
        [Range(0.0001f, 1f)]
        public float DialogVolume;

        [DefaultValue(false)]
        public bool MasterVolume_isMuted;
        [DefaultValue(false)]       
        public bool MusicVolume_isMuted;
        [DefaultValue(false)]
        public bool SFXVolume_isMuted;
        [DefaultValue(false)]
        public bool DialogVolume_isMuted;

        [DefaultValue(true)]
        public bool MasterVolume_Enabled;
        [DefaultValue(true)]
        public bool MusicVolume_Enabled;
        [DefaultValue(true)]
        public bool SFXVolume_Enabled;
        [DefaultValue(true)]
        public bool DialogVolume_Enabled;

        public void GetEnabledSliders()
        {
            MasterVolume_Enabled =  MasterVolume_isMuted == true ? false : true;
            MusicVolume_Enabled = MusicVolume_isMuted == true ? false : true;
            SFXVolume_Enabled = SFXVolume_isMuted == true ? false : true;
            DialogVolume_Enabled = DialogVolume_isMuted == true ? false : true;
        }

    }
     public Mixer mixer = new();
    
    [DefaultValue(false)]
    public bool isPaused;
    [System.Serializable]
    public class ResolutionInfo
    {
        public int ResIndex;
        public int width;
        public int height;
        public RefreshRate refreshRate;
        public string resolutionText;
        public ResolutionInfo(int width, int height, RefreshRate refreshRate, int Index)
        {
            this.width = width;
            this.height = height;
            this.refreshRate = refreshRate;
            this.resolutionText = $"{width}" + "x" + $"{height}";
            this.ResIndex = Index;
        }
        public ResolutionInfo GetResolutionInfo()
        {
            return this;
        }


    }
    public bool swapPages;

    [System.Serializable]
    public class ResolutionList
    {
        public int indexPicked;
        public List<ResolutionInfo> InfoList = new();

        public void AddResolutions()
        {
            UnityEngine.Resolution CurrRes = Screen.currentResolution;
            UnityEngine.Resolution[] unityResolutions = Screen.resolutions;
            int loops = 0;
            foreach (UnityEngine.Resolution res in unityResolutions)
            {
                float aspect = (float)res.width / res.height;
                int refreshRate = ((int)res.refreshRateRatio.value);
                // Check if it's approximately 16:9 (allowing small floating-point error)
                if (Mathf.Abs(aspect - (16f / 9f)) < 0.01f)
                {
                

                    indexPicked = (res.width == CurrRes.width && res.height == CurrRes.height) ? loops : 1;
                    InfoList.Add(new ResolutionInfo(res.width, res.height, res.refreshRateRatio, loops));
                    loops++;
                }

            }
            /*
             * class Program
{
    public static List<string> RemoveDuplicatesIterative(List<string> items)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < items.Count; i++)
        {
            // Assume not duplicate.
            bool duplicate = false;
            for (int z = 0; z < i; z++)
            {
                if (items[z] == items[i])
                {
                    // This is a duplicate.
                    duplicate = true;
                    break;
                }
            }
            // If not duplicate, add to result.
            if (!duplicate)
            {
                result.Add(items[i]);
            }
        }
        return result;
    }

    static void Main()
    {
        // Call method with this input.
        List<string> input = new List<string>() { "x", "x", "y", "y", "y", "z" };
        List<string> output = RemoveDuplicatesIterative(input);
        Console.WriteLine("Input: " + string.Join(",", input));
        Console.WriteLine("Output: " + string.Join(",", output));
    }
}

             */
        }


    }

    public DropdownField Resolution_dropdown;
    public DropdownField DisplayMode_dropdown;
    public int DisplayMode_Index;

    public ResolutionList resolutionList = new ResolutionList();
    [System.Serializable]
    public enum DisplayMode
    {
        Windowed = FullScreenMode.Windowed,
        Fullscreen = FullScreenMode.ExclusiveFullScreen,
        Borderless = FullScreenMode.FullScreenWindow
    }
  
    public Dictionary<string , FullScreenMode> displayModes =new()
    {
        {"Windowed", FullScreenMode.Windowed},
        {"Fullscreen" , FullScreenMode.ExclusiveFullScreen },
        {"Borderless" , FullScreenMode.FullScreenWindow }
    };

    public void OnEnable()
    {
        swapPages = false;
        resolutionList.AddResolutions();
        Settings_IO.LoadSettings(this);
        Resolution_dropdown = new DropdownField();
        if (Resolution_dropdown != null)
        {
            if (Resolution_dropdown.choices == null)
            {
                Resolution_dropdown.choices = new List<string>(); 
            }
            foreach (ResolutionInfo resInfo in resolutionList.InfoList)
            {
                Resolution_dropdown.choices.Add(resInfo.resolutionText);
            }
            Resolution_dropdown.index = 0;
        }
        DisplayMode_dropdown = new DropdownField();
        if (DisplayMode_dropdown != null)
        {
            if (DisplayMode_dropdown.choices == null)
                DisplayMode_dropdown.choices = new List<string>();
            foreach( KeyValuePair<string,FullScreenMode> mode in displayModes)
            {
                DisplayMode_dropdown.choices.Add(mode.Key);
            }   
                
            DisplayMode_dropdown.index = 0;
        }
       
        
    }
}

