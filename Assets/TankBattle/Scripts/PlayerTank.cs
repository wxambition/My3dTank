using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CLTank
{
    public class PlayerTank : Tank
    {
        public enum PlayerTankType
        {
            pow_0,
            pow_1,
            pow_2,
            pow_3,
        }

        public PlayerTankType playerTankType;

        public enum PlayerType
        {
            player1,
            player2,
        }

        public PlayerType playerType;

        void Start() { }

        private void OnCollisionEnter(Collision collision)
        {
            var _name = collision.gameObject.name;
            if (_name.Contains("Enemy"))
            {
                animator.SetTrigger("Dead");
                PlayAudio(audioSource[1], audioDestroy);
                Destroy(gameObject, 1f); //�����Լ�������̹�ˣ�
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var tag = other.tag;
            switch (tag)
            {
                case "Bomb":
                    Debug.Log("ʰ����ը��");
                    break;
                case "Clock":
                    Debug.Log("ʰ��������");
                    break;
                case "Heart":
                    Debug.Log("ʰ���˼ӳ�");
                    break;
                case "Shield":
                    Debug.Log("ʰ���˶���");
                    break;
                case "Spade":
                    Debug.Log("ʰ��������");
                    break;
                case "Star":
                    Debug.Log("ʰ��������");
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
