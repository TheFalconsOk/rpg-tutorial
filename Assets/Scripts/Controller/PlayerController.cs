using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

namespace RPG.Control
{
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            //sets ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //sets ray hit
            RaycastHit hit;
            //sets hasHit flag
            bool hasHit = Physics.Raycast(ray, out hit);
            //if hit sent destination point
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }
    }
}