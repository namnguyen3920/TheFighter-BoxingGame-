using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HitBox : MonoBehaviour
{
    [SerializeField] bool canAttack;
    public PunchType punchType;

    private void Awake()
    {
        canAttack = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!canAttack) return;
        if(other.TryGetComponent<HitReceiver>(out var hitReceiver))
        {

            hitReceiver.TakePunch(10);
            other.enabled = false;
            StartCoroutine(HitBoxActiveTime(0.2f));
            other.enabled = true;
        }
    }

    public void EnableHitBox(float time)
    {
        StartCoroutine(HitBoxActiveTime(time));
    }
    private IEnumerator HitBoxActiveTime(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }
}
