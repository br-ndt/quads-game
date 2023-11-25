using System;
using UnityEngine;

public class MovesForward : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private bool activeOnAwake;
  private bool active;

  private void Awake()
  {
    if (activeOnAwake)
    {
      active = true;
    }
  }

  // Update is called once per frame
  private void FixedUpdate()
  {
    if (active)
    {
      transform.position += transform.forward * speed * Time.deltaTime;
    }
  }
}
