using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HitController : MonoBehaviour
{
    //public LayerMask layerTarget;
    //public Transform leftHandPos;
    //public Transform rightHandPos;
    //[SerializeField] Vector3 halfExtendBox = new Vector3(0.5f, 0.5f, 0.5f);

    //public void LaunchAttack(PunchType punchType)
    //{
    //    Debug.Log("Punch!");
    //    Transform hand = GetHandPosition(punchType);
    //    if (hand == null) { return; }
    //    Collider[] hitsCol = Physics.OverlapBox(hand.position, halfExtendBox, hand.rotation, layerTarget);
    //    Debug.Log("Attack!");
    //    Debug.Log($"Hit Col: {hitsCol[0]}");
    //    foreach (Collider hitCol in hitsCol)
    //    {
    //        if (hitCol.transform.root == transform.root) continue;

    //        Debug.Log($"Hit Collide: {hitCol}");
    //        if (hitCol.TryGetComponent<HitReceiver>(out var hitReceiver))
    //        {
    //            hitReceiver.TakePunch(100);
    //        }
    //    }
    //}

    //private Transform GetHandPosition(PunchType type)
    //{
    //    return type switch
    //    {
    //        PunchType.PunchRight => leftHandPos,
    //        _ => rightHandPos,
    //    };
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.matrix = Matrix4x4.TRS(leftHandPos.position, leftHandPos.rotation, Vector3.one);
    //    Gizmos.DrawWireCube(Vector3.zero, halfExtendBox * 2);
    //    Gizmos.matrix = Matrix4x4.TRS(rightHandPos.position, rightHandPos.rotation, Vector3.one);
    //    Gizmos.DrawWireCube(Vector3.zero, halfExtendBox * 2);
        
    //}
}
