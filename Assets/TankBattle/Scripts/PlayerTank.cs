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
                Destroy(gameObject, 1f); //销毁自己（敌人坦克）
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var tag = other.tag;
            switch (tag)
            {
                case "Bomb":
                    Debug.Log("拾到了炸弹");
                    break;
                case "Clock":
                    Debug.Log("拾到了闹钟");
                    break;
                case "Heart":
                    Debug.Log("拾到了加车");
                    break;
                case "Shield":
                    Debug.Log("拾到了盾牌");
                    break;
                case "Spade":
                    Debug.Log("拾到了铁锹");
                    break;
                case "Star":
                    Debug.Log("拾到了星星");
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
