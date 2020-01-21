using UnityEngine;

namespace Geekbrains
{
    public abstract class Ammunition : BaseObjectScene
    {
        [SerializeField] private float _timeToDestruct = 10;
        [SerializeField] private float _baseDamage = 10;
        protected float _curDamage;
        private float _lossOfDamageAtTime = 0.2f;
        private Vector3 _ammunPos;

        public AmmunitionType Type = AmmunitionType.Bullet;

        protected override void Awake()
        {
            base.Awake();
           
            //c  вероятнотью 1\10 патрон бракованный, порох отсырел)))
            int FakeBull = Random.Range(1, 10);
            if (FakeBull == 1)  _curDamage = 1;
            else  _curDamage = _baseDamage;
        }

        private void Start()
        {
            _ammunPos = gameObject.transform.position;
            DestroyAmmunition(_timeToDestruct);
            InvokeRepeating(nameof(LossOfDamage), 0, 1);
        }

        public void AddForce(Vector3 dir)
        {
            if (!Rigidbody) return;
            Rigidbody.AddForce(dir);
        }

        private void LossOfDamage()
        {
            _curDamage -= _lossOfDamageAtTime;
        }

        protected void DestroyAmmunition(float timeToDestruct = 0)
        {
            Destroy(gameObject, timeToDestruct);
            CancelInvoke(nameof(LossOfDamage));
            // Вернуть в пул
        }
    }
}
