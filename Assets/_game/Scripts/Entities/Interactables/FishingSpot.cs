using UnityEngine;

public class FishingSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerHudController _HUD;
    [SerializeField] private PlayerCharacter _player;

    private int fishAmt;
    private float fTime = 5f;
    private float fDur;
    private int fTap;

    public void Interact(GameObject interactor)
    {

        fDur += Time.deltaTime;
        _HUD.FGEnter();
        _HUD.FishTimer(fTime, fTime - fDur);

        if(fDur >= fTime)
        {
            _HUD.FGExit();
            _player.FTrans();
            _player.FReset();
            _player.pressOff();
            Destroy(gameObject);
        }

    }

    public void intInitialize(PlayerCharacter player, PlayerHudController HUD)
    {
        _HUD = HUD;
        _player = player;
    }
}
