namespace MynetDemo.Game.Ability
{
    public class FrequencyModifyAbilityBehaviour : AbstractAttackAbilityBehaviour
    {
        public FrequencyModifyAbilityBehaviour(Character character) : base(character)
        {
        }

        public override void Apply()
        {
            IAttack attack = new FrequencyModifyAttackDecorator(_character.Attack);
            _character.ChangeAttack(attack);
        }
    }
}
