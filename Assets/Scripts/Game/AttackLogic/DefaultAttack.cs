using UnityEngine;

namespace MynetDemo.Game
{
    public class DefaultAttack : IAttack
    {
        protected float _projectileSpeed = 3f;
        protected float _attackFrequency = 2f;
        private bool _canAttack = false;
        private float _lastAttackTime;

        public void Attack(Vector3 pos, Vector3 dir)
        {
            _canAttack = false;
            _lastAttackTime = Time.timeSinceLevelLoad;

            GameObject go = PoolerManager.Instance.GetPoolObjectForSeconds("Bullet", 4f);
            go.transform.position = pos;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = dir * _projectileSpeed;
        }

        public bool CanAttack()
        {
            _canAttack = (Time.timeSinceLevelLoad - _lastAttackTime) > _attackFrequency;
            return _canAttack;
        }

        public float GetAttackFrequency()
        {
            return _attackFrequency;
        }

        public float GetProjectileSpeed()
        {
            return _projectileSpeed;
        }

        public void SetAttackFrequency(float frequency)
        {
            _attackFrequency = frequency;
        }

        public void SetProjectileSpeed(float projectileSpeed)
        {
            _projectileSpeed = projectileSpeed;
        }
    }
}
