using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private float speed = 10f;
  [SerializeField] private float distCoeff;
  [SerializeField] LayerMask whatToCollide;
  private Vector3 lastMoveDirection;

  private PlayerAnimator playerAnimator;
  private int layerMask;

  private void Awake()
  {
    playerAnimator = GetComponent<PlayerAnimator>();
    InputEventManager.OnMove += Movement;
    layerMask = ~(1 << gameObject.layer);
    DontDestroyOnLoad(gameObject);
  }

  private void Movement(Vector3 moveDir)
  {
    if (this != null && moveDir != Vector3.zero)
    {
      Vector3 baseMoveDir = moveDir;
      float distance = speed * Time.deltaTime * distCoeff;
      bool canMove = CanMove(baseMoveDir, distance);
      if (!canMove)
      {
        //cannot move diagonally
        baseMoveDir = new Vector3(baseMoveDir.x, 0f, 0f).normalized;
        canMove = baseMoveDir.x != 0f && CanMove(baseMoveDir, distance);
        if (!canMove)
        {
          //cannot move horizontally
          baseMoveDir = new Vector3(0f, 0f, baseMoveDir.z).normalized;
          canMove = CanMove(baseMoveDir, distance);
        }
      }

      if (canMove)
      {
        lastMoveDirection = baseMoveDir;
        transform.position += baseMoveDir * distance;
        playerAnimator.PlayWalkingAnimation(this, moveDir, false);
        return;
      }
    }
    playerAnimator.PlayIdleAnimation(this);
  }

  private bool CanMove(Vector3 dir, float distance)
  {
    Debug.DrawRay(transform.position, dir * distance, Color.red, 0.8f);
    return !Physics.Raycast(transform.position, dir, distance, whatToCollide);
  }
}
