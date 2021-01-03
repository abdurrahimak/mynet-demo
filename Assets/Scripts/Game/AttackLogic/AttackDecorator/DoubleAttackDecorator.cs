using UnityEngine;

namespace MynetDemo.Game
{
    public class DoubleAttackDecorator : AttackDecorator
    {
        private float _durationForSecondAttack = 0.15f;
        private float _secondAttackTime;
        private bool _canAttackSecond;

        public DoubleAttackDecorator(IAttack attack) : base(attack)
        {
            _canAttackSecond = false;
            _secondAttackTime = 0f;
        }

        public override bool CanAttack()
        {
            bool canAttack = base.CanAttack();
            if (canAttack)
            {
                _canAttackSecond = true;
                _secondAttackTime = Time.timeSinceLevelLoad + _durationForSecondAttack;
                return true;
            }
            else
            {
                if (Time.timeSinceLevelLoad > _secondAttackTime && _canAttackSecond)
                {
                    _canAttackSecond = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
