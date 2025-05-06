using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCharacter : MonoBehaviour
{
    public event Action<int> OnLeveledUp = delegate { };
    public event Action<float, float> OnEXPGained = delegate { };
    public event Action<int> onGoldCollected = delegate { };

    //public event Action<bool> InteractionDetected = delegate { };

    public float EXP { get; private set; }
    public int LVL { get; private set; }
    public int GOLD { get; private set; }
    public int FISH { get; private set; }

    private float _expForNextLevelUp = 100;
    private float _expTotal;
    private bool isClicked = false;

    private GameController _gameController;

    private PlayerHudController _hud;

    public LayerMask _layerToTest;

    private PlayerCharacter _playerPOS;

    private void Awake()
    {
        _playerPOS = FindAnyObjectByType<PlayerCharacter>();

        _gameController = FindAnyObjectByType<GameController>();

        _hud = FindAnyObjectByType<PlayerHudController>();//_gameController.GetComponentInParent<PlayerHudController>();

        LVL = SaveManager.Instance.ActiveSaveData.level;

        GOLD = SaveManager.Instance.ActiveSaveData.gold;

        FISH = SaveManager.Instance.ActiveSaveData.fish;
    }

    private void DetectInteractable()
    {
        Collider[] result = Physics.OverlapSphere(_playerPOS.transform.position, 1.5f, _layerToTest);

        if(result.Length>0)
        {
            foreach (var collider in result)
            {
                IInteractable[] interactable = collider.GetComponents<IInteractable>();
                foreach (var interactableObj in interactable)
                {
                    _hud.InteractActive();
                    if(isClicked == true)
                    {
                        interactableObj.Interact(gameObject);
                    }
                }
            }
        }
        else
        {
            _hud.InteractDeactive();
        }

    }

    private void Update()
    {
        DetectInteractable();
    }

    public void IncreaseGOLD(int amount)
    {
        GOLD += amount;
        onGoldCollected?.Invoke(GOLD);
        //Debug.Log("Gold: " + GOLD);
    }

    public void intPress()
    {
        isClicked = true;
    }

    public void pressOff()
    {
        isClicked = false;
    }

}
