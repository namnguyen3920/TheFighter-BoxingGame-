using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMN : MonoBehaviour
{
    public HitBox leftHandHitbox;
    public HitBox rightHandHitbox;

    public void EnableLeftHitbox(float duration)
    {
        leftHandHitbox.EnableHitBox(duration);
    }

    public void EnableRightHitbox(float duration)
    {
        rightHandHitbox.EnableHitBox(duration);
    }
}
