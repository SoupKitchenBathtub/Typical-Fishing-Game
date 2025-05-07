using UnityEngine;

public class FishingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHudController _HUD;
    [SerializeField] private PlayerCharacter _player;

    private int fishAmt;

    public void Interact(GameObject interactor)
    {
        int fishAmt = Random.Range(1, 5);
        Debug.Log(fishAmt);
        _player.IncreaseFISH(fishAmt);
        _player.pressOff();
        Destroy(gameObject);
    }

    public void intInitialize(PlayerCharacter player, PlayerHudController HUD)
    {
        _HUD = HUD;
        _player = player;
    }
}
