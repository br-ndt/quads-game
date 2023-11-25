using System;
using UnityEngine;

public class CleansUpOnCollide : CanCollide
{
  protected override void OnTriggerEnter(Collider other)
  {
    base.OnTriggerEnter(other);
    Destroy(gameObject);
  }
}