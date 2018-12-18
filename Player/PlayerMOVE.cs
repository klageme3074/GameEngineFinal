using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOVE : FSMState
{
    Vector3 moveVelocity;
    Vector3 moveInput;
    Transform visualTransform;

    public void Awake()
    {
        visualTransform = GetComponentInChildren<Animator>().GetComponent<Transform>();
    }

    public override void BeginState()
    {
        base.BeginState();
        if (_manager == null)
            _manager = GetComponent<FSMManager>();
    }

    public override void EndState()
    {
        base.EndState();
    }
    protected override void Update()
    {
        base.Update();
        Movement();
        if(moveVelocity==Vector3.zero)
            _manager.SetState(PlayerState.IDLE);
    }

    void Movement()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * _manager.Stat.MoveSpeed;
        VisualRotate();
        transform.Translate(Vector3.forward * moveVelocity.z * Time.deltaTime);
        transform.Translate(Vector3.right * moveVelocity.x * Time.deltaTime);
    }

    void VisualRotate()
    {
        if (0f < moveInput.normalized.x && 0f < moveInput.normalized.z) { visualTransform.localRotation = Quaternion.Euler(0f, 45f, 0f); }
        if (0f < moveInput.normalized.x && 0f > moveInput.normalized.z) { visualTransform.localRotation = Quaternion.Euler(0f, 135f, 0f); }
        if (0f > moveInput.normalized.x && 0f > moveInput.normalized.z) { visualTransform.localRotation = Quaternion.Euler(0f, 225f, 0f); }
        if (0f > moveInput.normalized.x && 0f < moveInput.normalized.z) { visualTransform.localRotation = Quaternion.Euler(0f, -45f, 0f); }
        if (moveInput.normalized.x == 1f) { visualTransform.localRotation = Quaternion.Euler(0f, 90f, 0f); }
        if (moveInput.normalized.x == -1f) { visualTransform.localRotation = Quaternion.Euler(0f, -90f, 0f); }
        if (moveInput.normalized.z == 1f) { visualTransform.rotation = Quaternion.Euler(0f, 0f, 0f); }
        if (moveInput.normalized.z == -1f) { visualTransform.rotation = Quaternion.Euler(0f, 180f, 0f); }
    }
}
