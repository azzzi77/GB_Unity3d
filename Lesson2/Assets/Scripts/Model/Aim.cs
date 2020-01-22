using System;
using UnityEngine;

namespace Geekbrains
{
    public sealed class Aim : MonoBehaviour, ISetDamage, ISelectObj
    {
        public event Action OnPointChange;
		
        public float Hp = 100;
        private bool _isDead;
        //броня у противника
        public float Armor = 50;

        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;

            if (Armor > 0)
            {
                Armor -= info.Damage;
            }
            if (Armor <= 0)
            {
                if (Hp > 0)
                {
                    Hp -= info.Damage;
                }

                if (Hp <= 0)
                {
                   // if (!TryGetComponent<Rigidbody>(out _))
                   // {
                   //     gameObject.AddComponent<Rigidbody>();
                   // }
                    Destroy(gameObject);

                    OnPointChange?.Invoke();
                    _isDead = true;
                }
            }
    
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
