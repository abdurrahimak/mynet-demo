namespace MynetDemo.Game
{
    public class ProjectileSpeedModifyAttackDecorator : AttackDecorator
    {
        private float _multiplier = 0.5f;
        public ProjectileSpeedModifyAttackDecorator(IAttack attack) : base(attack)
        {
            float speed = attack.GetProjectileSpeed();
            speed += speed * _multiplier;
            attack.SetProjectileSpeed(speed);
        }
    }
}
