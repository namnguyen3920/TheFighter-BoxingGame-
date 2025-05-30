using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour
{
    private readonly List<IHitObserver> hitObsv = new();
    
    public void AddBeingHitObsv(IHitObserver observer)
    {
        if (!hitObsv.Contains(observer))
        {
            hitObsv.Add(observer);
        }
    }

    public void RemoveHitObsv(IHitObserver observer)
    {
        if(hitObsv.Contains(observer))
        {
            hitObsv.Remove(observer);
        }
    }

    public void TakePunch(int damage)
    {
        hitObsv.ForEach((hitObsv) =>
        {
            hitObsv.OnReceivedHit(damage);
        });
    }
}
