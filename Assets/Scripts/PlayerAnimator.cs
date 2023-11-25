using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
  [SerializeField] private InputController inputController;
  [SerializeField] private SpriteAnimator spriteAnim;
  [SerializeField] private Sprite[] idleSouthAnimationFrameArray;
  [SerializeField] private Sprite[] idleSouthEastAnimationFrameArray;
  [SerializeField] private Sprite[] idleSouthWestAnimationFrameArray;
  [SerializeField] private Sprite[] idleNorthAnimationFrameArray;
  [SerializeField] private Sprite[] idleNorthEastAnimationFrameArray;
  [SerializeField] private Sprite[] idleNorthWestAnimationFrameArray;
  [SerializeField] private Sprite[] idleEastAnimationFrameArray;
  [SerializeField] private Sprite[] idleWestAnimationFrameArray;
  [SerializeField] private Sprite[] walkSouthAnimationFrameArray;
  [SerializeField] private Sprite[] walkSouthEastAnimationFrameArray;
  [SerializeField] private Sprite[] walkSouthWestAnimationFrameArray;
  [SerializeField] private Sprite[] walkNorthAnimationFrameArray;
  [SerializeField] private Sprite[] walkNorthEastAnimationFrameArray;
  [SerializeField] private Sprite[] walkNorthWestAnimationFrameArray;
  [SerializeField] private float idleFrameRate;
  [SerializeField] private float walkFrameRate;
  [SerializeField] private float runFrameRate;
  [SerializeField] private float midBuffer;

  Vector3 mousePointInWorld;

  public void PlayIdleAnimation(Object sender)
  {
    if (sender == GetComponent<Player>() || sender.GetType() == typeof(InputController)) //second check to be changed at some point, seems inefficient.
    {
      Sprite[] anim;
      if (mousePointInWorld.x >= transform.position.x + midBuffer)
        anim = mousePointInWorld.z <= transform.position.z ? idleSouthEastAnimationFrameArray : idleNorthEastAnimationFrameArray;
      else if (mousePointInWorld.x <= transform.position.x - midBuffer)
        anim = mousePointInWorld.z <= transform.position.z ? idleSouthWestAnimationFrameArray : idleNorthWestAnimationFrameArray;
      else
        anim = mousePointInWorld.z <= transform.position.z ? idleSouthAnimationFrameArray : idleNorthAnimationFrameArray;

      spriteAnim.PlayAnimation(anim, idleFrameRate, false);
    }

  }

  public void PlayWalkingAnimation(Player sender, Vector3 moveDir, bool isHalted)
  {
    if (sender == GetComponent<Player>())
    {
      Sprite[] anim;
      if (mousePointInWorld.x >= transform.position.x + midBuffer)
        anim = mousePointInWorld.z <= transform.position.z ? walkSouthEastAnimationFrameArray : walkNorthEastAnimationFrameArray;
      else if (mousePointInWorld.x <= transform.position.x - midBuffer)
        anim = mousePointInWorld.z <= transform.position.z ? walkSouthWestAnimationFrameArray : walkNorthWestAnimationFrameArray;
      else
        anim = mousePointInWorld.z <= transform.position.z ? walkSouthAnimationFrameArray : walkNorthAnimationFrameArray;

      spriteAnim.PlayAnimation(anim, walkFrameRate, true);
    }
  }

  private void Awake()
  {
    InputEventManager.OnMouseMove += UpdateFacing;
  }

  private void UpdateFacing(Vector3 mousePosition)
  {
    mousePointInWorld = mousePosition;
  }
}
