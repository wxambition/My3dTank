using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class EnemyTank : Tank
    {
        public enum EnemyTankType
        {
            normal,
            fastMove,
            fastShoot,
            heavy,
        }

        public EnemyTankType enemyTankType;
        public int hitPoint; //生命值

        void Start() { }

        private void OnCollisionEnter(Collision collision)
        {
            var _name = collision.gameObject.name;
            if (_name.Contains("Player1"))
            {
                if (enemyTankType == EnemyTankType.heavy)
                {
                    hitPoint--;
                    if (hitPoint > 0)
                        return;
                }
                animator.SetTrigger("Dead");
                PlayAudio(audioSource[1], audioDestroy);
                particle.Play();  //播放爆炸特效
                Destroy(gameObject, 1f); //销毁自己（敌人坦克）
            }
        }

        private void OnTriggerEnter(Collider other)
        {   //var go=other.gameObject;
            //if(go.CompareTag())
            var tag = other.tag;
            if (tag == "Trees")
                SetSpeed(0.8f);
            else if (tag == "Ice")
                SetSpeed(1.2f);
        }

        private void OnTriggerExit(Collider other)
        {
            SetSpeed(1);
        }
    }
}
