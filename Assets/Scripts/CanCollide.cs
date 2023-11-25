using System;
using UnityEngine;

public class CanCollide : MonoBehaviour
{
  protected virtual void OnTriggerEnter(Collider other)
  {
    DealsDamageOnCollision dealDamage = GetComponent<DealsDamageOnCollision>();
    if (dealDamage != null)
    {
      ReceivesDamage receiveDamage = other.GetComponent<ReceivesDamage>();
      if (receiveDamage != null)
      {
        receiveDamage.Receive(dealDamage.Damage);
      }
    }
  }
}