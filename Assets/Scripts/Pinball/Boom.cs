using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _force;
    [SerializeField] private float _radiusPush;



    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.layer & (1 << _layerMask.value)) == 1)
        {

            PushAway(collision);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radiusPush);
    }

    private void PushAway(Collision collision)
    {
        Rigidbody rigidbody = collision.collider.attachedRigidbody;
        if (rigidbody)
        {
            if (collision.contacts.Length > 0)
            {
                Vector3 point = collision.contacts[0].point;
                Debug.Log($"{rigidbody.name} {point}");
                rigidbody.AddExplosionForce(_force, point, _radiusPush);
            }

        }
    }


}
