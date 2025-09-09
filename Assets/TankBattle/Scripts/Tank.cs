using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class Tank : MonoBehaviour
    {
        public enum Direction
        {
            stop,
            forward,
            backward,
            left,
            right,
        } // ö�����ͣ�����

        public Direction direction; //̹���˶��ķ���
        public Rigidbody rig; //̹�˵ĸ������
        public float speed = 1; //̹���ƶ��ٶ�
        public Animator animator; //̹�˵�Animator���
        public GameObject shellPrefab; //�ڵ�Ԥ����
        public Transform shellPos; //�ڵ�������λ��
        public GameObject shellObj; //�ڵ�����

        void Start()
        {
            rig = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            MoveTank(direction);
        }

        void MoveTank(Direction dir)
        {
            animator.SetBool("Move", true);
            switch (dir)
            {
                case Direction.stop:
                    rig.velocity = Vector3.zero;
                    animator.SetBool("Move", false);
                    break;
                case Direction.forward:
                    //GetComponent<Transform>()�ȼ�transform
                    transform.forward = Vector3.forward;
                    rig.velocity = Vector3.forward * speed;
                    break;
                case Direction.backward:
                    transform.forward = Vector3.back;
                    rig.velocity = Vector3.back * speed;
                    break;
                case Direction.left:
                    transform.forward = Vector3.left;
                    rig.velocity = Vector3.left * speed;
                    break;
                case Direction.right:
                    transform.forward = Vector3.right;
                    rig.velocity = Vector3.right * speed;
                    break;
                default:
                    break;
            }

            /*
            if (dir == Direction.forward)
            {
                rig.velocity = Vector3.forward;
            }*/
        }

        public void Fire()
        {
            shellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
        }
    }
}
