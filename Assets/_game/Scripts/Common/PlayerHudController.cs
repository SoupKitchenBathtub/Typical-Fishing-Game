using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using EasyTransition;
using UnityEngine;

public class PlayerHudController : MonoBehaviour
{

    private UIDocument _document;

    //private VisualElement _root;
    private VisualElement _HUD;
    private VisualElement _pause;
    private VisualElement _settings;
    private VisualElement _lose;

    private Button _pEnter;
    private Button _pExit;
    private Button _sEnter;
    private Button _sExit;
    private Button _quit;

    private Slider _music;
    private Slider _SFX;

    [SerializeField] private string _lvlName;

    private List<Button> _menuButtons = new List<Button>();

    public AudioSource _click;
    //public AudioSource _mmMusic;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        //_root = _document.rootVisualElement.Q("Root");
        _HUD = _document.rootVisualElement.Q("HUD");
        _pause = _document.rootVisualElement.Q("Pause");
        _settings = _document.rootVisualElement.Q("Settings");
        _lose = _document.rootVisualElement.Q("LoseScreen");

        _pEnter = _document.rootVisualElement.Q("pEnter") as Button;
        _pEnter.RegisterCallback<ClickEvent>(OnPEnterClick);

        _pExit = _document.rootVisualElement.Q("pExit") as Button;
        _pExit.RegisterCallback<ClickEvent>(OnPExitClick);

        _sEnter = _document.rootVisualElement.Q("sEnter") as Button;
        _sEnter.RegisterCallback<ClickEvent>(OnSEnterClick);

        _sExit = _document.rootVisualElement.Q("sExit") as Button;
        _sExit.RegisterCallback<ClickEvent>(OnSExitClick);

        _quit = _document.rootVisualElement.Q("Quit") as Button;
        _quit.RegisterCallback<ClickEvent>(OnQuitClick);

        /*_menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnDisable()
    {
        _pEnter.UnregisterCallback<ClickEvent>(OnPEnterClick);
        _pExit.UnregisterCallback<ClickEvent>(OnPExitClick);
        _sEnter.UnregisterCallback<ClickEvent>(OnSEnterClick);
        _sExit.UnregisterCallback<ClickEvent>(OnSExitClick);
        _quit.UnregisterCallback<ClickEvent>(OnQuitClick);

        /*for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnPEnterClick(ClickEvent evt)
    {
        //Disable/ or Close HUD
        //Open Pause
    }

    private void OnPExitClick(ClickEvent evt)
    {
        //Close Pause
        //Open HUD
    }

    private void OnSEnterClick(ClickEvent evt)
    {
        //Close Pause
        //Open Settings
    }

    private void OnSExitClick(ClickEvent evt)
    {
        //Close Settings
        //Open Pause
    }

    private void OnQuitClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_lvlName);
        //print("ouch");
    }

}
