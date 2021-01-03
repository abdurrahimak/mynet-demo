using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MynetDemo.Game
{
    public class Character : MonoBehaviour
    {
        private IAttack _attack;
        private bool _enableAttack;

        public IAttack Attack => _attack;
        public event Action AttackTriggered;
        public event Action<IAttack> AttackTypeChanged;

        private void Start()
        {
            if (_attack == null)
                _attack = new DefaultAttack();
            transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
        }

        public void ChangeAttack(IAttack attack)
        {
            _attack = attack;
            AttackTypeChanged?.Invoke(_attack);
        }

        private void Update()
        {
            if (_attack.CanAttack() && _enableAttack)
            {
                TriggerAttack();
            }
        }

        public void EnableAttack(bool enable)
        {
            _enableAttack = enable;
        }

        public void TriggerAttack()
        {
            _attack.Attack(transform.position + transform.forward * 1f, transform.forward);
            AttackTriggered?.Invoke();
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.white);
        }
    }
}
