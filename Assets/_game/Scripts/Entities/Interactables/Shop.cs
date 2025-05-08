using UnityEngine;

public class Shop : MonoBehaviour, IInteractable
{

    [SerializeField] private PlayerHudController _HUD;
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private GameFSM _states;

    public void Interact(GameObject interactor)
    {

        if(_states.CurrState == _states._intState)
        {
            if(_states.PrevState == _states._dayState)
            {
                Debug.Log("Regular Goods");
                _player.pressOff();
            }
            else if(_states.PrevState == _states._nightState)
            {
                Debug.Log("Special Goods");
                _player.pressOff();
            }
        }

    }

}
