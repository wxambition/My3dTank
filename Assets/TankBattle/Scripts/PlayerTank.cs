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

        public GameObject secondShellObj; //�ڶ����ڵ�

        void Start() { }

        private void OnCollisionEnter(Collision collision)
        {
            var _name = collision.gameObject.name;
            if (_name.Contains("Enemy"))
            {
                animator.SetTrigger("Dead");
                PlayAudio(audioSource[1], audioDestroy);
                particle.Play(); //���ű�ը��Ч
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
                // ����˫���ڵ���Э��
                StartCoroutine(DoubleFireWithDelay(name));
            }
            else
            {
                base.Fire(name);
            }
        }

        private IEnumerator DoubleFireWithDelay(string name)
        {
            // �����һ���ڵ�
            if (shellObj == null)
            {
                shellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
                shellObj.name = name + "_Shell";
                PlayAudio(audioSource[1], audioFire);
            }

            // ����ӳ�
            yield return new WaitForSeconds(timeDelay); // ʹ�� Tank ���ж���� timeDelay

            // ����ڶ����ڵ�
            if (secondShellObj == null)
            {
                secondShellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
                secondShellObj.name = name + "_Shell";
                PlayAudio(audioSource[1], audioFire);
            }
        }
    }
}
