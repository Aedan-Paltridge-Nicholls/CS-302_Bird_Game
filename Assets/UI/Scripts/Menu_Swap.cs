
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using static Menu_Swap;

public class Menu_Swap : MonoBehaviour
{

    public  VisualTreeAsset MenuPageSettings;
    public  VisualTreeAsset MenuPageMainMenu;
    public  VisualTreeAsset MenuPageControls;
   
    public VisualTreeAsset MenuPage_Current;
    public UIDocument Menu_UIDocument;

    private Button PlayButton;
    private Button BackButton;
    private Button ControlsButton;
    private Button SettingsButton;
    public enum MenuPages
    {
        MainMenu,
        Settings,
        Controls
    }   
   

    void Start()
    {

        VisualElement _root = Menu_UIDocument.rootVisualElement;
        if (_root == null)
        {
            MenuPage_Current = MenuPageMainMenu;
            Menu_UIDocument.visualTreeAsset = MenuPage_Current;
        }
        else 
        {
            MenuPage_Current = Menu_UIDocument.visualTreeAsset;
        }
       FindButtons();
    }

    private void FindButtons()
    {
        VisualElement _root = Menu_UIDocument.rootVisualElement;
        /*
        * Finds a Button on the _root Visual asset 
        * And Binds a Method to it  -Aedan 
        */
        ControlsButton = _root.Q<Button>("ControlsPage_Button");
        if (ControlsButton != null) ControlsButton.clickable.clicked += ControlsPage_ButtonPressed;

        PlayButton = _root.Q<Button>("PlayButton");
        if (PlayButton != null) PlayButton.clickable.clicked += PlayButtonPressed;

        BackButton = _root.Q<Button>("BackButton");
        if (BackButton != null) BackButton.clickable.clicked += BackButtonPressed;
       

        SettingsButton = _root.Q<Button>("SettingsButton");
        if (SettingsButton != null) SettingsButton.clickable.clicked += SettingsPage_ButtonPressed;

        Button Quit_Button = _root.Q<Button>("Quit_Button");
        if (Quit_Button != null)
        {
            Quit_Button.clickable.clicked += QuitButtonPressed;
        }

    }

    private void QuitButtonPressed()
    {
        Application.Quit();
    }
    private void PlayButtonPressed()
    {
        if (MenuPage_Current == MenuPageMainMenu)
        {
            SceneManager.LoadScene("Game");
        }
    }
    private void BackButtonPressed()
    {
        if (MenuPage_Current != null)
        {
            if (MenuPage_Current == MenuPageControls)
            {
                Swapping_BackFrom(MenuPages.Controls);
            }
            else if (MenuPage_Current == MenuPageSettings)
            {
                Swapping_BackFrom(MenuPages.Settings);
            }
        }
        
        
    }
    private void ControlsPage_ButtonPressed() 
    {
        if (MenuPage_Current == MenuPageSettings)
        {
            Swapping_to(MenuPages.Controls);
        }
    }
    private void SettingsPage_ButtonPressed()
    {
        if (MenuPage_Current == MenuPageMainMenu)
        {
            Swapping_to(MenuPages.Settings);
        }
    }

    private void Swapping_to(MenuPages SwapTO_Page)
    { 
        switch (SwapTO_Page)
        {
            case MenuPages.MainMenu:
            {
                MenuPage_Current = MenuPageMainMenu;
                Menu_UIDocument.visualTreeAsset = MenuPage_Current;
                FindButtons();
                return;
            }
                
            case MenuPages.Settings:
            {
                MenuPage_Current = MenuPageSettings;
                Menu_UIDocument.visualTreeAsset = MenuPage_Current;
                FindButtons();
                return;
            }
               
            case MenuPages.Controls:
            {
                MenuPage_Current = MenuPageControls;
                Menu_UIDocument.visualTreeAsset = MenuPage_Current;
                FindButtons();
                return;
            }
            

            default:
                break;
        }
        FindButtons();
    }
    private void Swapping_BackFrom(MenuPages SwapFrom_Page)
    {
        switch (SwapFrom_Page)
        {
            case MenuPages.MainMenu:
            {
                Application.Quit();
                FindButtons();
                return;
            }
            case MenuPages.Settings:
            {

                MenuPage_Current = MenuPageMainMenu;
                Menu_UIDocument.visualTreeAsset = MenuPage_Current;
                FindButtons();
                return;
            }
            case MenuPages.Controls:
            {
                MenuPage_Current = MenuPageSettings;
                Menu_UIDocument.visualTreeAsset = MenuPage_Current;
                FindButtons();
                return;
            }

            default:
                break;
        }
    }

       


    // Update is called once per frame
    void Update()
    {
        
    }
}
