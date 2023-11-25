using UnityEngine;

public class PlayerHandAnimator : MonoBehaviour
{
  [SerializeField] private float attackFrameRate;
  private SpriteRenderer spriteRenderer;
  private SpriteAnimator animator;
  Sprite[] sprites;

  // input is negative, to invert rotation caused by aiming pivot
  public void RotateHand(Vector3 modifier)
  {
    spriteRenderer.transform.localRotation = Quaternion.Euler(Vector3.zero + modifier);

    if (spriteRenderer.transform.position.z - transform.position.z > 0.1600f)
      spriteRenderer.sortingOrder = 0;
    else
      spriteRenderer.sortingOrder = 2;
  }

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<SpriteAnimator>();
  }
}
