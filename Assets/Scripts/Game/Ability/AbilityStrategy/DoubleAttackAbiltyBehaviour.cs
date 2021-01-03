namespace MynetDemo.Game.Ability
{
    public class DoubleAttackAbiltyBehaviour : AbstractAttackAbilityBehaviour
    {
        public DoubleAttackAbiltyBehaviour(Character character) : base(character)
        {
        }

        public override void Apply()
        {
            IAttack attack = new DoubleAttackDecorator(_character.Attack);
            _character.ChangeAttack(attack);
        }
    }
}
