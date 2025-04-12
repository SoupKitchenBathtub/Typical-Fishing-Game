using UnityEngine;

public class InputBroadcaster : MonoBehaviour
{

    public bool IsTapPressed { get; private set; } = false;
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    IsTapPressed = true;
                    break;
                case TouchPhase.Ended:
                    IsTapPressed = false;
                    break;
            }
        }
    }

}
