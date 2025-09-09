using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class AIInput : MonoBehaviour
    {
        public Tank enemyTank;
        public float timer; //¼ÆÊ±Æ÷

        void Start() { }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                int d = Random.Range(0, 5);
                if (d == 0)
                    enemyTank.direction = Tank.Direction.stop;
                else if (d == 1)
                    enemyTank.direction = Tank.Direction.forward;
                else if (d == 2)
                    enemyTank.direction = Tank.Direction.backward;
                else if (d == 3)
                    enemyTank.direction = Tank.Direction.left;
                else if (d == 4)
                    enemyTank.direction = Tank.Direction.right;
            }
        }
    }
}
