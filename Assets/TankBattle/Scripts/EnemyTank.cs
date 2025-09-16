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
        public int hitPoint;//����ֵ

        void Start() { }

        private void OnCollisionEnter(Collision collision)
        {
            var _name = collision.gameObject.name;
            if (_name.Contains("Player1"))
            {
                animator.SetTrigger("Dead");
                PlayAudio(audioSource[1], audioDestroy);
                Destroy(gameObject, 1f); //�����Լ�������̹�ˣ�
            }
        }
    }
}
