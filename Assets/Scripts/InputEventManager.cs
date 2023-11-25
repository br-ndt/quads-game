using UnityEngine;

public class InputEventManager
{
  #region Movement Keys
  public delegate void MoveInputEventHandler(Vector3 moveDir);

  public static event MoveInputEventHandler OnMove;
  public static void Move(object sender, Vector3 moveDir)
  {
    if (OnMove != null && sender.GetType() == typeof(InputController))
      OnMove(moveDir);
  }
  #endregion

  #region Mouse
  public delegate void MouseInputEventHandler(Vector3 position);
  public static event MouseInputEventHandler OnMouseMove;
  public static event MouseInputEventHandler OnLeftMouseDown;
  public static event MouseInputEventHandler OnRightMouseDown;
  public static event MouseInputEventHandler OnLeftMouseUp;
  public static event MouseInputEventHandler OnRightMouseUp;

  public static void MouseMove(Object sender, Vector3 position)
  {
    if (sender.GetType() == typeof(InputController))
    {
      OnMouseMove?.Invoke(position);
    }
  }

  public static void MouseDown(Object sender, int buttonFired, Vector3 position)
  {
    if (sender.GetType() == typeof(InputController))
    {
      switch (buttonFired)
      {
        case 1:
          OnRightMouseDown?.Invoke(position);
          break;
        default:
          OnLeftMouseDown?.Invoke(position);
          break;
      }
    }
  }

  public static void MouseUp(Object sender, int buttonFired, Vector3 position)
  {
    if (sender.GetType() == typeof(InputController))
    {
      switch (buttonFired)
      {
        case 1:
          OnRightMouseUp?.Invoke(position);
          break;
        default:
          OnLeftMouseUp?.Invoke(position);
          break;
      }
    }
  }
  #endregion

  #region Other Keyboard
  public delegate void KeyboardInputEventHandler();
  public static event KeyboardInputEventHandler OnRotateKey;
  public static void Rotate(object sender)
  {
    if (OnRotateKey != null && sender.GetType() == typeof(InputController))
      OnRotateKey();
  }

  public delegate void NumKeyInputEventHandler(int num);
  public static event NumKeyInputEventHandler OnNumKey;
  public static void NumKey(object sender, int numkey) // eventually might want per-number basis
  {
    if (OnNumKey != null && sender.GetType() == typeof(InputController))
      OnNumKey(numkey);
  }
  #endregion
}