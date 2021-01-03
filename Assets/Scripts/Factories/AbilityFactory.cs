using MynetDemo.Core;
using MynetDemo.Game;
using MynetDemo.Game.Ability;

namespace MynetDemo.Creation
{
    public class AbilityFactory : SingletonClass<AbilityFactory>
    {
        public AbilityManager CreateAbilityManager()
        {
            return new AbilityManager();
        }

        public IAbilityBehaviour CreateMultipleAttackAbilityBehaviour(Character character)
        {
            return new MultipleAttackAbilityBehaviour(character);
        }

        public IAbilityBehaviour CreateDoubleAttackAbiltyBehaviour(Character character)
        {
            return new DoubleAttackAbiltyBehaviour(character);
        }

        public IAbilityBehaviour CreateFrequencyModifyAbilityBehaviour(Character character)
        {
            return new FrequencyModifyAbilityBehaviour(character);
        }

        public IAbilityBehaviour CreateProjectileSpeedModifyAbilityBehaviour(Character character)
        {
            return new ProjectileSpeedModifyAbilityBehaviour(character);
        }

        public IAbilityBehaviour CreateDuplicateCharacterAbilityBehaviour(Character character)
        {
            return new DuplicateCharacterAbilityBehaviour(character);
        }

        public Ability CreateAbility(IAbilityBehaviour abilityBehaviour)
        {
            return new Ability(abilityBehaviour);
        }

        public Ability CreateAbility(AbilityType type, Character character)
        {
            Ability ability = null;
            switch (type)
            {
                case AbilityType.MultipleAttack:
                    {
                        ability = CreateAbility(CreateMultipleAttackAbilityBehaviour(character));
                        break;
                    }
                case AbilityType.DoubleAttack:
                    {
                        ability = CreateAbility(CreateDoubleAttackAbiltyBehaviour(character));
                        break;
                    }
                case AbilityType.HasteAttack:
                    {
                        ability = CreateAbility(CreateFrequencyModifyAbilityBehaviour(character));
                        break;
                    }
                case AbilityType.FasterAttack:
                    {
                        ability = CreateAbility(CreateProjectileSpeedModifyAbilityBehaviour(character));
                        break;
                    }
                case AbilityType.CloneCharacter:
                    {
                        ability = CreateAbility(CreateDuplicateCharacterAbilityBehaviour(character));
                        break;
                    }
            }
            return ability;
        }
    }
}
