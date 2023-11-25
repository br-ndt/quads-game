using UnityEngine;

public class InputController : MonoBehaviour
{
  public MouseUtil mouseUtil;
  public Vector3 mousePointInWorld;
  void HandleMovement()
  {
    float moveX = Input.GetAxisRaw("Horizontal");
    float moveZ = Input.GetAxisRaw("Vertical");
    Vector3 baseMoveDir = new Vector3(moveX, 0, moveZ).normalized;
    InputEventManager.Move(this, baseMoveDir);
  }

  void HandleMouse()
  {
    Vector3 curMouse = mouseUtil.GetMouseWorldPosition();
    if (mousePointInWorld != curMouse)
    {
      mousePointInWorld = curMouse;
      InputEventManager.MouseMove(this, mousePointInWorld);
    }
    if (Input.GetMouseButtonDown(0))
    {
      InputEventManager.MouseDown(this, 0, mousePointInWorld);
    }
    if (Input.GetMouseButtonDown(1))
    {
      InputEventManager.MouseDown(this, 1, mousePointInWorld);
    }
    if (Input.GetMouseButtonUp(0))
    {
      InputEventManager.MouseUp(this, 0, mousePointInWorld);
    }
    if (Input.GetMouseButtonUp(1))
    {
      InputEventManager.MouseUp(this, 1, mousePointInWorld);
    }
  }

  void HandleKeyboard()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      InputEventManager.NumKey(this, 0); // shift player input to be 1 -> 0 based
    }
    if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      InputEventManager.NumKey(this, 1);
    }
  }

  private void Awake()
  {
    mouseUtil = GetComponent<MouseUtil>();
    Cursor.visible = false;
  }

  private void Update()
  {
    HandleMovement();
    HandleMouse();
    HandleKeyboard();
  }
}

