using Interfaces;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDamage damage = other.GetComponent<IDamage>();
        if (damage !=null)
        {
            damage.Damage();
        }
    }
}
