namespace MynetDemo.Game.Ability
{
    public class Ability
    {
        private IAbilityBehaviour _ability;
        public Ability(IAbilityBehaviour abilityBehaviour)
        {
            _ability = abilityBehaviour;
        }

        public void ApplyAbility()
        {
            _ability.Apply();
        }

        public void Destroy()
        {
            _ability.Destroy();
        }
    }
}
