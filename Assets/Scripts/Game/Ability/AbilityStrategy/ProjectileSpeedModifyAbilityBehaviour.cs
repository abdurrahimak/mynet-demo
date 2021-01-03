namespace MynetDemo.Game.Ability
{
    public class ProjectileSpeedModifyAbilityBehaviour : AbstractAttackAbilityBehaviour
    {
        public ProjectileSpeedModifyAbilityBehaviour(Character character) : base(character)
        {
        }

        public override void Apply()
        {
            IAttack attack = new ProjectileSpeedModifyAttackDecorator(_character.Attack);
            _character.ChangeAttack(attack);
        }
    }
}
