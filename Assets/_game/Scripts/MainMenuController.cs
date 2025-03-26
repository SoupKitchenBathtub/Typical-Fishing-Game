using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using EasyTransition;
using UnityEngine;


public class MainMenuController : MonoBehaviour
{

    private UIDocument _document;

    private VisualElement _root;
    private VisualElement _settings;
    private VisualElement _credits;

    private Button _play;
    private Button _quit;

    private Slider _music;
    private Slider _SFX;

    [SerializeField] private string _lvlName;

    private List<Button> _menuButtons = new List<Button>();

    public AudioSource _click;
    public AudioSource _mmMusic;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _root = _document.rootVisualElement.Q("Root");

        _play = _document.rootVisualElement.Q("Play") as Button;
        _play.RegisterCallback<ClickEvent>(OnPlayClick);

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
        _play.UnregisterCallback<ClickEvent>(OnPlayClick);
        _quit.UnregisterCallback<ClickEvent>(OnQuitClick);

        /*for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnPlayClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_lvlName);
    }

    private void OnQuitClick(ClickEvent evt)
    {
        Application.Quit();
        //print("ouch");
    }

}
