using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasHealth : MonoBehaviour
{
  [SerializeField] private int maxHitPoints;
  [SerializeField] private bool maxOnAwake;

  private int _hitPoints;
  private bool dying = false;

  public int HP
  {
    get => _hitPoints;
    set
    {
      if (!dying)
      {
        StopCoroutine("FlashRed");
        _hitPoints = value;
        StartCoroutine("FlashRed");
        if (_hitPoints <= 0)
        {
          dying = true;
          StartCoroutine("Die");
        }
      }
    }
  }

  private void Awake()
  {
    if (maxOnAwake)
    {
      _hitPoints = maxHitPoints;
    }
  }
  
  private IEnumerator FlashRed() 
  {
    GetComponent<Renderer>().material.color = new Color(1, 0, 0);
    yield return new WaitForSeconds(0.1f);
    GetComponent<Renderer>().material.color = new Color(1, 1, 1);
  }

  private IEnumerator Die()
  {
    StopCoroutine("FlashRed");
    GetComponent<Renderer>().material.color = new Color(0, 0, 0);
    yield return new WaitForSeconds(1f);
    Destroy(gameObject);
  }
}
