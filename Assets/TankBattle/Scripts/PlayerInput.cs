using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class PlayerInput : MonoBehaviour
    {
        public Tank playerTank;
        public KeyCode Key_Forward;
        public KeyCode Key_Backward;
        public KeyCode Key_Left;
        public KeyCode Key_Right;
        public KeyCode Key_Fire;

        void Start()
        {
            playerTank = GetComponent<Tank>();
        }

        void Update()
        {if(Input.GetKeyDown(Key_Fire))
            {
                playerTank.Fire(name);
            }
            if (Input.GetKey(Key_Forward))
            {
                playerTank.direction = Tank.Direction.forward;
            }
            else if (Input.GetKey(Key_Backward))
            {
                playerTank.direction = Tank.Direction.backward;
            }
            else if (Input.GetKey(Key_Left))
            {
                playerTank.direction = Tank.Direction.left;
            }
            else if (Input.GetKey(Key_Right))
            {
                playerTank.direction = Tank.Direction.right;
            }
            else
            {
                playerTank.direction = Tank.Direction.stop;
            }
        }
    }
}
