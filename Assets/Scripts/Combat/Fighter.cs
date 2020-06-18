using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float WeaponRange = 2f;
        Transform target;
        // Start is called before the first frame update
        private void Start()
        {
        }
        private void Update()
        {

            if (target)
            {
                //check to see if target in range
                if(Vector3.Distance(target.position, transform.position)<WeaponRange)
                {
                    // if in range stop moving
                    GetComponent<Mover>().Stop();
                    AttackCancel();
                }
                else
                {
                    // move to target
                    GetComponent<Mover>().MoveTo(target.position);
                }
            }
            
        }
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        public void AttackCancel()
        {
            target = null;
        }
    }
}
