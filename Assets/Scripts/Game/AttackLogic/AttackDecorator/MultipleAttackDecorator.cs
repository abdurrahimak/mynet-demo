using UnityEngine;

namespace MynetDemo.Game
{
    public class MultipleAttackDecorator : AttackDecorator
    {
        public MultipleAttackDecorator(IAttack attack) : base(attack)
        {
        }

        public override void Attack(Vector3 pos, Vector3 dir)
        {
            base.Attack(pos, Quaternion.AngleAxis(-45f, Vector3.up) * dir);
            base.Attack(pos, dir);
            base.Attack(pos, Quaternion.AngleAxis(45f, Vector3.up) * dir);
        }
    }
}
