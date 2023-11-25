using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivesDamage : MonoBehaviour
{
  [SerializeField] HasHealth health;

  private void Awake()
  {
    if (health == null)
    {
      health = GetComponent<HasHealth>();
    }
  }

  public void Receive(int damage)
  {
    if (health != null)
    {
      health.HP -= damage;
    }
  }
}
