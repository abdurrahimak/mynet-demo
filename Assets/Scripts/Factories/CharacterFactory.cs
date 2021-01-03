using MynetDemo.Core;
using MynetDemo.Game;
using UnityEngine;

namespace MynetDemo.Creation
{
    public class CharacterFactory : SingletonClass<CharacterFactory>
    {
        public Character CreateCharacter(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            GameObject prefab = ResourceManager.Instance.GetResource<GameObject>("Character");
            GameObject go = GameObject.Instantiate(prefab, parent);
            go.transform.position = position;
            go.transform.rotation = Quaternion.identity;
            return go.GetComponent<Character>();
        }

        public Character CreateCharacter(Vector3 position, Transform parent = null)
        {
            return CreateCharacter(position, Quaternion.identity, parent);
        }

        public Character CreateCharacter(Transform parent = null)
        {
            return CreateCharacter(Vector3.zero, Quaternion.identity, parent);
        }

        internal Character CreateCharacter(Vector3 pos, Quaternion rotation, IAttack attack)
        {
            Character character = CreateCharacter(pos, rotation);
            character.ChangeAttack(attack);
            return character;
        }
    }
}
