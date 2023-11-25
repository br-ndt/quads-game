using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamage : MonoBehaviour
{
  [SerializeField] protected int _damage;

  public int Damage
  {
    get => _damage;
  }
}
