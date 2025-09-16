using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class AIInput : MonoBehaviour
    {
        public EnemyTank enemyTank;
        public float timer; //计时器

        void Start() { }

        void Update()
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                int f = Random.Range(0, 2);
                if(f==0)
                    enemyTank.Fire(name);//敌人坦克开火

                int d = Random.Range(0, 5);
                if (d == 0)
                    enemyTank.direction = EnemyTank.Direction.stop;
                else if (d == 1)
                    enemyTank.direction = EnemyTank.Direction.forward;
                else if (d == 2)
                    enemyTank.direction = EnemyTank.Direction.backward;
                else if (d == 3)
                    enemyTank.direction = EnemyTank.Direction.left;
                else if (d == 4)
                    enemyTank.direction = EnemyTank.Direction.right;
            }
        }
    }
}
