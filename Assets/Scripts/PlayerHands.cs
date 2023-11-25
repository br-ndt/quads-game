using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
  [SerializeField] private Transform handPivot;
  [SerializeField] private float verticalOffset;
  [SerializeField] private float depthOffset;
  [SerializeField] private Transform leftHand;
  [SerializeField] private Transform rightHand;
  [SerializeField] private Transform firingPosition;
  [SerializeField] private Vector3 handAngleOffset;
  [SerializeField] private float cooldown;
  [SerializeField] private GameObject bulleto;
  [SerializeField] private ParticleSystem muzzleFlash;
  [SerializeField] private AudioSource audioSource;
  [SerializeField] private float pitchRange;
  [SerializeField] private float recoilIncrement;
  [SerializeField] private float recoilMax;

  private float recoil = 0;

  private void RotateHands(Vector3 pointTowards)
  {
    handPivot.LookAt(pointTowards);
    handPivot.rotation = AccountForRecoil(recoil, handPivot.rotation.eulerAngles.y);
    leftHand.localRotation = Quaternion.Inverse(handPivot.rotation);
    rightHand.localRotation = Quaternion.Inverse(handPivot.rotation);
  }

  private Quaternion AccountForRecoil(float recoil, float currentY)
  {
    return Quaternion.Euler(0 - recoil, currentY, 0);
  }

  private void BeginMouse(Vector3 position)
  {
    StopCoroutine("Stabilize");
    StartCoroutine("Fire");
  }

  private void EndMouse(Vector3 position)
  {
    StopCoroutine("Fire");
    StartCoroutine("Stabilize");
  }

  private void Awake()
  {
    InputEventManager.OnMouseMove += RotateHands;
    InputEventManager.OnLeftMouseDown += BeginMouse;
    InputEventManager.OnLeftMouseUp += EndMouse;
    // animator = GetComponent<PlayerHands_Animator>();        
  }

  private IEnumerator Fire()
  {
    while (true)
    {
      Quaternion bulletoRotate = Quaternion.Euler(handPivot.rotation.eulerAngles.x + UnityEngine.Random.Range(-recoil / 2, recoil / 2), handPivot.rotation.eulerAngles.y + UnityEngine.Random.Range(-recoil / 2, recoil / 2), handPivot.rotation.eulerAngles.z);
      Instantiate(bulleto, firingPosition.position, bulletoRotate, null);
      recoil += recoilIncrement;
      if (recoil > recoilMax)
      {
        recoil = recoilMax;
      }
      handPivot.rotation = AccountForRecoil(recoil, handPivot.rotation.eulerAngles.y);

      muzzleFlash.Emit(30);
      audioSource.pitch = 1 + UnityEngine.Random.Range(-pitchRange, pitchRange);
      audioSource.Play();
      yield return new WaitForSeconds(cooldown);
    }
  }

  private IEnumerator Stabilize()
  {
    while (true)
    {
      while (recoil > 0)
      {
        recoil -= recoilIncrement / 2;
      }
      if (recoil < 0)
      {
        recoil = 0;
      }
      handPivot.rotation = AccountForRecoil(recoil, handPivot.rotation.eulerAngles.y);

      if (recoil == 0)
      {
        yield return null;
      }
      yield return new WaitForSeconds(cooldown);
    }
  }
}
