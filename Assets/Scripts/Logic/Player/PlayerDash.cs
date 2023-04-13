using Mirror;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Logic.Camera;
using Assets.Scripts.Logic.Player;

public class PlayerDash : NetworkBehaviour
{
    public bool IsDashing { get; private set; }
    public bool IsDashCoolDown { get; private set; }

    [SerializeField] [Range(100f, 1000f)] private float _dashDistance;
    [SerializeField] [Range(0f, 10f)] private float _dashCoolDownTime;
    
    [SerializeField] private KeyCode _inputKey = KeyCode.Mouse0;
    
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private CharacterController _characterController;


    private void Update()
    {
        if(!isLocalPlayer) { return; }    
        if (Input.GetKeyDown(_inputKey))
        {
            DoImpulse();
        }
    }

    private void DoImpulse()
    {
        if (IsDashCoolDown) { return; }
        IsDashing = true;
        Vector3 movementVector = _cameraController.PlanarRotation * Vector3.forward*_dashDistance;
        _characterController.Move(movementVector*Time.deltaTime);
        IsDashing=false;
        StartCoroutine(DashCoolDownRoutine());
    }

    private IEnumerator DashCoolDownRoutine()
    {
        IsDashCoolDown = true;
        yield return new WaitForSeconds(_dashCoolDownTime);
        IsDashCoolDown=false;
    }
}
