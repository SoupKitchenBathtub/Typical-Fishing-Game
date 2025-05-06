using UnityEngine;

public class FishingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHudController _HUD;
    [SerializeField] private PlayerCharacter _player;

    private int fishAmt;

    public void Interact(GameObject interactor)
    {
        Debug.Log("Fish");
        _player.pressOff();
        Destroy(gameObject);
    }

    public void intInitialize(PlayerCharacter player, PlayerHudController HUD)
    {
        _HUD = HUD;
        _player = player;
    }
}
