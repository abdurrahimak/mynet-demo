using System.Collections.Generic;

namespace MynetDemo.Game.Ability
{
    public class AbilityManager
    {
        private List<Ability> _abilities = new List<Ability>();

        public int AbilityCount => _abilities.Count;

        public void AddAbility(Ability ability)
        {
            ability.ApplyAbility();
            _abilities.Add(ability);
        }

        public void Destroy()
        {
            foreach (Ability ability in _abilities)
            {
                ability.Destroy();
            }
            _abilities.Clear();
        }
    }
}
