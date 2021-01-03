using UnityEngine;

namespace MynetDemo.Game
{
    public interface IAttack
    {
        void Attack(Vector3 pos, Vector3 dir);
        bool CanAttack();
        void SetProjectileSpeed(float projectileSpeed);
        float GetProjectileSpeed();
        void SetAttackFrequency(float frequency);
        float GetAttackFrequency();
    }
}
