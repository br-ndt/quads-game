using UnityEngine;

public class MouseUtil : MonoBehaviour
{
  Plane bisectPlane;
  private void Awake()
  {
    bisectPlane = new Plane(Vector3.up, 0);
  }

  public Vector3 GetMouseWorldPosition()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (bisectPlane.Raycast(ray, out float distance))
    {
      return ray.GetPoint(distance);
    }

    return Vector3.down;
  }
}
