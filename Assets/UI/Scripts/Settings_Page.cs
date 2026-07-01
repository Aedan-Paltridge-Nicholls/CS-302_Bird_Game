using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using static Settings_SO.ResolutionList;

public class Settings_Page : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Settings_SO settings_SO;
    [SerializeField] 
    private UIDocument uiDocument; // Assign in Inspector

    private int ResIndex;
    private Settings_SO.ResolutionList resInfoList ;
    public Settings_SO.ResolutionInfo info;
    public AudioMixer audioMixer;
    public Menu_Swap Menu_Swap;

    /*    UI Elements  
     * 
     *     Dropdowns 
     */
    public DropdownField ResolutionDropdown;
    private DropdownField DisplayModeDropdown;
    /* Volume Sliders*/
    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public Slider DialogVolumeSlider;
    /* Mute Toggles */
    public Toggle MasterMuteToggle;
    public Toggle MusicMuteToggle;
    public Toggle SFXMuteToggle;
    public Toggle DialogMuteToggle;
    /*Buttons*/
    public Button BackButton;

    
    /* bools */
    private bool SettingsOnScreen;
    private bool AddedListeners;

    void Start()
    {
        settings_SO.mixer.GetEnabledSliders();
        AddedListeners = false;
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument is not assigned in the Inspector.");
            return;
        }
        settings_SO.OnEnable();
        resInfoList = settings_SO.resolutionList;
        VisualElement root = uiDocument.rootVisualElement;
        if (root != null) { AddSettingsListeners(); }
      
        
    }
    
    public void BackButtonPressed()
    {
      
    }
    private void OnEnable()
    {
        
    }
    public void AddSettingsListeners()
    {
        VisualElement root = uiDocument.rootVisualElement;
        ResolutionDropdown = root.Q<DropdownField>("ResolutionDropdownField");
        BackButton = root.Q<Button>("BackButton");
        ResIndex = settings_SO.resolutionList.indexPicked;
        DisplayModeDropdown = root.Q<DropdownField>("DisplayModeDropdownField");
        // Volume Sliders 
        {
            static float linearToDecibel(float linear)
            {
               return Mathf.Log10(linear) * 20f;
            }
            MasterVolumeSlider = root.Q<Slider>("MasterVolumeSlider");
                MasterVolumeSlider.RegisterValueChangedCallback(evt =>
                {
                    audioMixer.SetFloat("MasterVolume", linearToDecibel(evt.newValue));
                });
            MasterMuteToggle = root.Q<Toggle>("MasterMuteToggle");
                MasterMuteToggle.RegisterValueChangedCallback(evt =>
                {
                    settings_SO.mixer.GetEnabledSliders();
                });

            SFXVolumeSlider = root.Q<Slider>("SFXVolumeSlider");
                SFXVolumeSlider.RegisterValueChangedCallback(evt =>
                {
                    audioMixer.SetFloat("SFXVolume", linearToDecibel(evt.newValue));
                });
            SFXMuteToggle = root.Q<Toggle>("SFXMuteToggle");
                SFXMuteToggle.RegisterValueChangedCallback(evt =>
                {
                    settings_SO.mixer.GetEnabledSliders();
                });

            MusicVolumeSlider = root.Q<Slider>("MusicVolumeSlider");
                MusicVolumeSlider.RegisterValueChangedCallback(evt =>
                {
                    audioMixer.SetFloat("MusicVolume", linearToDecibel(evt.newValue));
                });
            MusicMuteToggle = root.Q<Toggle>("MusicMuteToggle");
                MusicMuteToggle.RegisterValueChangedCallback(evt =>
                {
                    settings_SO.mixer.GetEnabledSliders();
                });

            DialogVolumeSlider = root.Q<Slider>("DialogVolumeSlider");
                DialogVolumeSlider.RegisterValueChangedCallback(evt =>
                {
                    audioMixer.SetFloat("DialogVolume", linearToDecibel(evt.newValue));
                });
            DialogMuteToggle = root.Q<Toggle>("DialogMuteToggle");
                DialogMuteToggle.RegisterValueChangedCallback(evt =>
                {
                    settings_SO.mixer.GetEnabledSliders();
                });
        }


        DisplayModeDropdown.RegisterValueChangedCallback(evt =>
        {
            if (settings_SO.displayModes.TryGetValue(evt.newValue, out FullScreenMode value))
            {
                Settings_SO.ResolutionInfo info_res = settings_SO.resolutionList.InfoList[ResIndex].GetResolutionInfo();
                Screen.SetResolution(info_res.width, info_res.height, value, info_res.refreshRate);
            }
        });
        ResolutionDropdown.RegisterValueChangedCallback(evt =>
        {
            settings_SO.resolutionList.indexPicked = ResIndex;
            Settings_SO.ResolutionInfo info_res = settings_SO.resolutionList.InfoList[ResIndex].GetResolutionInfo();
            if (settings_SO.displayModes.TryGetValue(settings_SO.DisplayMode_dropdown.text, out FullScreenMode value))
            {
                Screen.SetResolution(info_res.width, info_res.height, value, info_res.refreshRate);
            }
        });
        AddedListeners = true;
    }
    private void OnApplicationQuit()
    {
        Settings_IO.SaveSettings(settings_SO);
    }
    // Update is called once per frame
    void Update()
    {

        if (Menu_Swap.MenuPage_Current == Menu_Swap.MenuPageSettings && SettingsOnScreen == true && AddedListeners == false) 
        {
            AddSettingsListeners();
        }
        SettingsOnScreen = Menu_Swap.MenuPage_Current == Menu_Swap.MenuPageSettings ? true : false;
        AddedListeners = SettingsOnScreen == false ? false : AddedListeners;
    }
}
