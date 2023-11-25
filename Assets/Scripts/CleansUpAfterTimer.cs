using System.Collections;
using UnityEngine;

public class CleansUpAfterTimer : MonoBehaviour
{
  [SerializeField] float timerSeconds;
  private void Awake()
  {
    StartCoroutine("CleanUpAfterTimer");
  }

  private IEnumerator CleanUpAfterTimer()
  {
    yield return new WaitForSeconds(timerSeconds);
    Destroy(gameObject); 
  }
}
