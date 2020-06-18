using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                var clickTarget = hit.transform.GetComponent<CombatTarget>();

                if (clickTarget == null) continue;
                else if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(clickTarget);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            //sets ray hit
            RaycastHit hit;
            //sets hasHit flag
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            //if hit sent destination point
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().AttackCancel();
                    GetComponent<Mover>().MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}