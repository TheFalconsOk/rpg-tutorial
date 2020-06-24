using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1.5f;
        float timeSinceLastAttck = 0f;
        Transform target;
        // Start is called before the first frame update
        private void Start()
        {
        }
        private void Update()
        {
            timeSinceLastAttck += Time.deltaTime;

            if (target)
            {
                //check to see if target in range
                if (Vector3.Distance(target.position, transform.position) < weaponRange)
                {
                    // if in range stop moving start attack behaviour
                    GetComponent<Mover>().Cancel();
                    AttackBehaviour();
                }
                else
                {
                    // move to target
                    GetComponent<Mover>().MoveTo(target.position);
                }
            }

        }

        private void AttackBehaviour()
        {
            if (timeBetweenAttacks<= timeSinceLastAttck)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttck = 0f;
            }
            
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            target = null;
        }

        //animation event
        void Hit()
        {

        }
    }
}
