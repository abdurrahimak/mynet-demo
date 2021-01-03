using MynetDemo.Game.Ability;
using System;

namespace MynetDemo.UI
{

    public interface IPlayStateUI
    {
        event Action<AbilityType> ClickedAbility;
        event Action GoMainMenu;
        void DisableAbilityButton(AbilityType abilityType);
        void DisableAllAbilityButtons();
        void Destroy();
    }
}
