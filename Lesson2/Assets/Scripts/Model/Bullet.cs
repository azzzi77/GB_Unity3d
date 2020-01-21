using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            // дописать доп урон
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();

            if (tempObj != null)
            {
                var bulletPlace = gameObject.transform.position;
                Debug.Log("пуля в "+ bulletPlace+" сила урона "+ _curDamage);
                tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
            }

            DestroyAmmunition();
        }
    }
}
