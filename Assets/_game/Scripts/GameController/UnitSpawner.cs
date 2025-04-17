using UnityEngine;
using Unity.Cinemachine;

public class UnitSpawner : MonoBehaviour
{

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private CinemachineCamera _cinemaMachineBrain;

   /* public Unit Spawn(Unit unitPrefab, Transform location)
    {
        Unit newUnit = Instantiate(unitPrefab, location.position, location.rotation);

        newUnit.GetComponent<PlayerMovement>().Initialize(_gameController.GetComponent<InputHandler>());

        return newUnit;
    }*/

}
