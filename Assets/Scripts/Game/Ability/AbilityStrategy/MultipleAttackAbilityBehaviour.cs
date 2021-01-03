namespace MynetDemo.Game.Ability
{
    public class MultipleAttackAbilityBehaviour : AbstractAttackAbilityBehaviour
    {
        public MultipleAttackAbilityBehaviour(Character character) : base(character)
        {
        }

        public override void Apply()
        {
            IAttack attack = new MultipleAttackDecorator(_character.Attack);
            _character.ChangeAttack(attack);
        }
    }
}
