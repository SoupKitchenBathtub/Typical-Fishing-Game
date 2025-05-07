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
    private VisualElement _record;

    private Button _play;
    private Button _newRun;
    private Button _quit;

    private Slider _music;
    private Slider _SFX;

    [SerializeField] private string _lvlName;

    private Label _dayRec;
    private Label _goldRec;
    private Label _fishRec;
    private Label _lvlRec;

    private List<Button> _menuButtons = new List<Button>();

    public AudioSource _click;
    public AudioSource _mmMusic;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _root = _document.rootVisualElement.Q("Root");

        _record = _document.rootVisualElement.Q("Record");

        _play = _document.rootVisualElement.Q("Play") as Button;
        _play.RegisterCallback<ClickEvent>(OnPlayClick);

        _newRun = _document.rootVisualElement.Q("NewGame") as Button;
        _newRun.RegisterCallback<ClickEvent>(OnNewClick);

        _quit = _document.rootVisualElement.Q("Quit") as Button;
        _quit.RegisterCallback<ClickEvent>(OnQuitClick);

        _dayRec = _document.rootVisualElement.Q("DaysRecord") as Label;

        _goldRec = _document.rootVisualElement.Q("GoldRecord") as Label;

        _fishRec = _document.rootVisualElement.Q("FishRecord") as Label;

        _lvlRec = _document.rootVisualElement.Q("LevelRecord") as Label;

        SetDayRecord();
        SetGoldRecord();
        SetFishRecord();
        SetLvlRecord();
        /*_menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnDisable()
    {
        _play.UnregisterCallback<ClickEvent>(OnPlayClick);
        _newRun.UnregisterCallback<ClickEvent>(OnNewClick);
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

    private void OnNewClick(ClickEvent evt)
    {
        SaveManager.Instance.ResetSave();
        SaveManager.Instance.ResetRecord();
        SceneManager.LoadScene(_lvlName);
    }

    private void OnQuitClick(ClickEvent evt)
    {
        Application.Quit();
        //print("ouch");
    }

    private void SetDayRecord()
    {
        _dayRec.text = string.Format("Days Since Last Incident: {0}", SaveManager.Instance.ActiveRecData.day);
    }

    private void SetGoldRecord()
    {
        _goldRec.text = string.Format("Company Income: {0}", SaveManager.Instance.ActiveRecData.gold);
    }

    private void SetFishRecord()
    {
        _fishRec.text = string.Format("Fish Quota: {0}", SaveManager.Instance.ActiveRecData.fish);
    }

    private void SetLvlRecord()
    {
        _lvlRec.text = string.Format("Years Experience Req: {0}", SaveManager.Instance.ActiveRecData.level);
    }
}
