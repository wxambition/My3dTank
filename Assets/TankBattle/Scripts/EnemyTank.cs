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
        public int hitPoint; //����ֵ

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
                particle.Play();  //���ű�ը��Ч
                Destroy(gameObject, 1f); //�����Լ�������̹�ˣ�
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
