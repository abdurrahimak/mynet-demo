using MynetDemo.Creation;
using UnityEngine;

namespace MynetDemo.Game.Ability
{
    public class DuplicateCharacterAbilityBehaviour : IAbilityBehaviour
    {
        private Character _character;
        private Character _duplicatedCharacter;
        private readonly Vector3 _mins = new Vector3(-2f, 0f, -5f);
        private readonly Vector3 _maxs = new Vector3(2f, 0f, 2f);

        public DuplicateCharacterAbilityBehaviour(Character character)
        {
            _character = character;
        }

        public void Apply()
        {
            Vector3 pos = new Vector3(UnityEngine.Random.Range(_mins.x, _maxs.x), UnityEngine.Random.Range(_mins.y, _maxs.y), UnityEngine.Random.Range(_mins.z, _maxs.z));
            pos.y = _character.gameObject.transform.position.y;
            _duplicatedCharacter = CharacterFactory.Instance.CreateCharacter(pos, _character.gameObject.transform.rotation, _character.Attack);
            _character.AttackTriggered += _duplicatedCharacter.TriggerAttack;
            _character.AttackTypeChanged += _duplicatedCharacter.ChangeAttack;
        }

        public void Destroy()
        {
            if (_duplicatedCharacter.gameObject)
            {
                _character.AttackTriggered -= _duplicatedCharacter.TriggerAttack;
                _character.AttackTypeChanged -= _duplicatedCharacter.ChangeAttack;
                GameObject.Destroy(_duplicatedCharacter.gameObject);
            }
        }
    }
}
