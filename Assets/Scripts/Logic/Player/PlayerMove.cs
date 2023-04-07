using Assets.Scripts.Infrastructure.Services.InputServiceFolder;
using Assets.Scripts.Logic;
using UnityEngine;

public class PlayerMove : MonoBehaviour, IMove
{
    public CharacterController CharacterController;
    public float MovementSpeed;
    private IInputService _inputeService;

    public bool IsMoving { get; set; }

    public void Construct(IInputService inputeService) => _inputeService = inputeService;

    private void Awake() => SetStartPlayerPosition();

    private void Update() => Move();


    private void SetStartPlayerPosition()
    {
        Transform spawnPoint = FindObjectOfType<PlayerSpawnPoint>().transform;
        transform.position = new Vector3(spawnPoint.position.x, 2, spawnPoint.position.z);
    }

    public void Move()
    {
        IsMoving = false;
        Vector3 movementVector = Vector3.zero;
        if (_inputeService.Axis.sqrMagnitude > Mathf.Epsilon)
        {
            movementVector = Camera.main.transform.TransformDirection(_inputeService.Axis);
            movementVector.y = 0;
            movementVector.Normalize();
            transform.forward = movementVector;
            if (!IsMoving) { IsMoving = true; }
        }
        movementVector += Physics.gravity;
        CharacterController.Move(movementVector * Time.deltaTime * MovementSpeed);
    }
}
