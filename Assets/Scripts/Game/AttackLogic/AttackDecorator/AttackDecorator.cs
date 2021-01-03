using UnityEngine;

namespace MynetDemo.Game
{
    public abstract class AttackDecorator : IAttack
    {
        protected IAttack _attack;
        public AttackDecorator(IAttack attack)
        {
            _attack = attack;
        }

        public virtual void Attack(Vector3 pos, Vector3 dir)
        {
            _attack.Attack(pos, dir);
        }

        public virtual bool CanAttack()
        {
            return _attack.CanAttack();
        }

        public float GetAttackFrequency()
        {
            return _attack.GetAttackFrequency();
        }

        public float GetProjectileSpeed()
        {
            return _attack.GetProjectileSpeed();
        }

        public void SetAttackFrequency(float frequency)
        {
            _attack.SetAttackFrequency(frequency);
        }

        public virtual void SetProjectileSpeed(float projectileSpeed)
        {
            _attack.SetProjectileSpeed(projectileSpeed);
        }
    }
}
