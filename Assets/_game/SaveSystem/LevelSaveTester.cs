using UnityEngine;
using UnityEngine.InputSystem;

public class LevelSaveTester : MonoBehaviour
{
    private void Update()
    {
        // Q KEY - save
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            SaveManager.Instance.Save();
        }
        // W KEY - load
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            SaveManager.Instance.Load();
        }
        // A KEY - level up
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            SaveManager.Instance.ActiveSaveData.level++;
            Debug.Log("Level Up! " + SaveManager.Instance.ActiveSaveData.level);
        }
        // SPACE - print save data
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Level: " + SaveManager.Instance.ActiveSaveData.level);
            Debug.Log("Gold: " + SaveManager.Instance.ActiveSaveData.gold);
        }
    }
}
