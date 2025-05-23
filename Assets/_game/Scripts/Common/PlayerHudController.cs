using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using EasyTransition;
using UnityEngine;

public class PlayerHudController : MonoBehaviour
{

    [SerializeField] private GameController _gameController;
    [SerializeField] private PlayerCharacter _playerCharacter;
    private Health _playerHealth;

    private UIDocument _document;

    //private VisualElement _root;
    private VisualElement _HUD;
    private VisualElement _pause;
    private VisualElement _settings;
    private VisualElement _lose;
    private VisualElement _fG;
    private VisualElement _s1;
    private VisualElement _s2;
    private VisualElement _sC;

    private Button _pEnter;
    private Button _pExit;
    private Button _sEnter;
    private Button _sExit;
    private Button _quit;
    private Button _fQuit;
    private Button _interact;
    private Button _honk;
    private Button _fButton;
    private Button _Retry;

    private Slider _music;
    private Slider _SFX;

    private Label _gLabel;
    private Label _fLabel;

    private ProgressBar _fTime;

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
        _fG = _document.rootVisualElement.Q("FishingMinigame");

        _pEnter = _document.rootVisualElement.Q("pEnter") as Button;
        
        _pExit = _document.rootVisualElement.Q("pExit") as Button;
        
        _sEnter = _document.rootVisualElement.Q("sEnter") as Button;
        
        _sExit = _document.rootVisualElement.Q("sExit") as Button;
        
        _quit = _document.rootVisualElement.Q("Quit") as Button;

        _fQuit = _document.rootVisualElement.Q("Fquit") as Button;

        _interact = _document.rootVisualElement.Q("Interact") as Button;

        _honk = _document.rootVisualElement.Q("Honk") as Button;

        _fButton = _document.rootVisualElement.Q("FishButton") as Button;

        _Retry = _document.rootVisualElement.Q("Retry") as Button;

        _gLabel = _document.rootVisualElement.Q("GoldLabel") as Label;

        _fLabel = _document.rootVisualElement.Q("FishLabel") as Label;

        _fTime = _document.rootVisualElement.Q("FishTime") as ProgressBar;

        /*_menuButtons = _document.rootVisualElement.Query<Button>().ToList();
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnEnable()
    {
        _pEnter.RegisterCallback<ClickEvent>(OnPEnterClick);
        _pExit.RegisterCallback<ClickEvent>(OnPExitClick);
        _sEnter.RegisterCallback<ClickEvent>(OnSEnterClick);
        _sExit.RegisterCallback<ClickEvent>(OnSExitClick);
        _quit.RegisterCallback<ClickEvent>(OnQuitClick);
        _fQuit.RegisterCallback<ClickEvent>(OnFquitClick);
        _interact.RegisterCallback<ClickEvent>(OnInteractClick);
        _honk.RegisterCallback<ClickEvent>(OnHonkClick);
        _Retry.RegisterCallback<ClickEvent>(OnNewRunClick);
        _fButton.RegisterCallback<ClickEvent>(OnFButtonClick);
        _gameController.OnLose.AddListener(LoseScreenEnter);
        _playerCharacter.onGoldCollected += SetGoldAmt;
        _playerCharacter.onFishCollected += SetFishAmt;
        //_playerCharacter.InteractionDetected += ButtonPressed();
    }

    private void OnDisable()
    {
        _gameController.OnLose.RemoveListener(LoseScreenEnter);
        _pEnter.UnregisterCallback<ClickEvent>(OnPEnterClick);
        _pExit.UnregisterCallback<ClickEvent>(OnPExitClick);
        _sEnter.UnregisterCallback<ClickEvent>(OnSEnterClick);
        _sExit.UnregisterCallback<ClickEvent>(OnSExitClick);
        _quit.UnregisterCallback<ClickEvent>(OnQuitClick);
        _fQuit.UnregisterCallback<ClickEvent>(OnFquitClick);
        _interact.UnregisterCallback<ClickEvent>(OnInteractClick);
        _honk.UnregisterCallback<ClickEvent>(OnHonkClick);
        _Retry.UnregisterCallback<ClickEvent>(OnNewRunClick);
        _fButton.RegisterCallback<ClickEvent>(OnFButtonClick);
        _playerCharacter.onGoldCollected -= SetGoldAmt;
        _playerCharacter.onFishCollected -= SetFishAmt;
        /*for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }*/
    }

    private void OnPEnterClick(ClickEvent evt)
    {
        //Disable/ or Close HUD
        _pause.RemoveFromClassList("menu_ExitRight");
        _pEnter.SetEnabled(false);
    }

    private void OnPExitClick(ClickEvent evt)
    {
        _pause.AddToClassList("menu_ExitRight");
        _pEnter.SetEnabled(true);
    }

    private void OnSEnterClick(ClickEvent evt)
    {
        _pause.AddToClassList("menu_ExitRight");
        _settings.RemoveFromClassList("menu_ExitRight");
    }

    private void OnSExitClick(ClickEvent evt)
    {
        _settings.AddToClassList("menu_ExitRight");
        _pause.RemoveFromClassList("menu_ExitRight");
    }

    private void OnQuitClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_lvlName);
        //print("ouch");
    }

    private void OnFquitClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_lvlName);
        SaveManager.Instance.ResetSave();
        //print("ouch");
    }

    public void InteractActive()
    {
        //MinimizeHonk
        _honk.AddToClassList("buttonInt_ExitShrink");
        //MaximizeInt
        _interact.RemoveFromClassList("buttonInt_ExitShrink");
        _honk.SetEnabled(false);
        _interact.SetEnabled(true);
    }

    public void InteractDeactive()
    {
        _honk.RemoveFromClassList("buttonInt_ExitShrink");
        //MaximizeInt
        _interact.AddToClassList("buttonInt_ExitShrink");
        _honk.SetEnabled(true);
        _interact.SetEnabled(false);
    }

    public void LoseScreenEnter()
    {
        _lose.RemoveFromClassList("loseScreen_ExitDown");
    }

    private void OnHonkClick(ClickEvent evt)
    {
        Debug.Log("Honk");
    }

    private void OnInteractClick(ClickEvent evt)
    {
        //ButtonPressed();
        _playerCharacter.intPress();
    }

    private void OnFButtonClick(ClickEvent evt)
    {
        _playerCharacter.FClick();
    }

    /*private void OnRetryClick(ClickEvent evt)
    {
        //reload scene
        //Erase both initial save & score save
        SaveManager.Instance.ResetRecord();
        SaveManager.Instance.ResetSave();
    }*/

    private void OnNewRunClick(ClickEvent evt)
    {
        //Erase both initial save & score save
        SaveManager.Instance.ResetRecord();
        SaveManager.Instance.ResetSave();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //Load New Scene
    }

    public void FGEnter()
    {
        _fG.RemoveFromClassList("minigame_exit");
    }

    public void FGExit()
    {
        _fG.AddToClassList("minigame_exit");
    }

    private void SetGoldAmt(int amt)
    {
        _gLabel.text = string.Format(": {0}", amt);
    }

    private void SetFishAmt(int amt)
    {
        _fLabel.text = string.Format(": {0}", amt);
    }

    public void FishTimer(float timeThresh, float time)
    {
        _fTime.highValue = timeThresh;
        _fTime.value = time;
        _fTime.title = $"{(int)(time)} Secs";
    }
}
