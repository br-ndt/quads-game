using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowsMouseInWorld : MonoBehaviour
{
  private void Awake()
  {
    InputEventManager.OnMouseMove += Reposition;
  }

  private void Reposition(Vector3 position)
  {
    transform.position = position;
  }
}
