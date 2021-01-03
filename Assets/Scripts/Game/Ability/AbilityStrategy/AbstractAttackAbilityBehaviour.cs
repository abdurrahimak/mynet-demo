namespace MynetDemo.Game.Ability
{
    public abstract class AbstractAttackAbilityBehaviour : IAbilityBehaviour
    {
        protected Character _character;
        public AbstractAttackAbilityBehaviour(Character character)
        {
            _character = character;
        }

        public abstract void Apply();

        public virtual void Destroy()
        {

        }
    }
}
