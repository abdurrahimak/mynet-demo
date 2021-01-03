namespace MynetDemo.Game
{
    public class FrequencyModifyAttackDecorator : AttackDecorator
    {
        private float _freqMultiplier = 0.5f;
        public FrequencyModifyAttackDecorator(IAttack attack) : base(attack)
        {
            SetAttackFrequency(attack.GetAttackFrequency() * _freqMultiplier);
        }
    }
}
