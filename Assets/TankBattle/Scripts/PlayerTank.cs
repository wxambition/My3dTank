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

        public GameObject secondShellObj; //第二颗炮弹

        void Start() { }

        private void OnCollisionEnter(Collision collision)
        {
            var _name = collision.gameObject.name;
            if (_name.Contains("Enemy"))
            {
                animator.SetTrigger("Dead");
                PlayAudio(audioSource[1], audioDestroy);
                particle.Play(); //播放爆炸特效
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
                case "Trees":
                    speed = 0.8f;
                    return;
                case "Ice":
                    speed = 1.2f;
                    return;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            speed = 1;
        }

        public override void Fire(string name)
        {
            if (playerTankType == PlayerTankType.pow_2 || playerTankType == PlayerTankType.pow_3)
            {
                // 启动双发炮弹的协程
                StartCoroutine(DoubleFireWithDelay(name));
            }
            else
            {
                base.Fire(name);
            }
        }

        private IEnumerator DoubleFireWithDelay(string name)
        {
            // 发射第一发炮弹
            if (shellObj == null)
            {
                shellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
                shellObj.name = name + "_Shell";
                PlayAudio(audioSource[1], audioFire);
            }

            // 添加延迟
            yield return new WaitForSeconds(timeDelay); // 使用 Tank 类中定义的 timeDelay

            // 发射第二发炮弹
            if (secondShellObj == null)
            {
                secondShellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
                secondShellObj.name = name + "_Shell";
                PlayAudio(audioSource[1], audioFire);
            }
        }
    }
}
