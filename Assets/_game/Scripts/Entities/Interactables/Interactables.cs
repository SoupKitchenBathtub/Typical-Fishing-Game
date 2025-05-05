using UnityEngine;

public abstract class Interactables : MonoBehaviour
{

    [SerializeField] AudioClip _intSound = null;
    [SerializeField] PlayerHudController _hud;
    protected abstract void Interact(PlayerCharacter playerCharacter);

    public void intInitialize(PlayerHudController hud)
    {
        _hud = hud;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerCharacter playerCharacter))
        {
            _hud.InteractActive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter playerCharacter))
        {
            _hud.InteractDeactive();
        }
    }
}
