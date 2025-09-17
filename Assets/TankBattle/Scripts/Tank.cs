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

        public AudioSource[] audioSource; //����Դ
        public AudioClip audioFire; //��������
        public AudioClip audioDestroy; //��������
        public ParticleSystem particle; //��ը��Ч

        public float timeDelay = 0.2f; //�����ڵ�������ӳ�

        void Start()
        {
            rig = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            particle.Stop();
            timeDelay = 0.2f;
        }

        void Update()
        {
            MoveTank(direction);
        }

        protected void MoveTank(Direction dir)
        {
            animator.SetBool("Move", true);
            PlayAudio(audioSource[0]);
            switch (dir)
            {
                case Direction.stop:
                    rig.velocity = Vector3.zero;
                    animator.SetBool("Move", false);
                    audioSource[0].Stop();
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

        public virtual void Fire(string name)
        {
            if (shellObj != null)
                return;

            shellObj = Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
            shellObj.name = name + "_Shell";
            PlayAudio(audioSource[1], audioFire);
        }

        public void PlayAudio(AudioSource audio)
        {
            if (audio.isPlaying)
                return;
            audio.Play();
        }

        public void PlayAudio(AudioSource audio, AudioClip clip) //int audioId
        {
            audio.clip = clip;
            audio.Play();
        }

        public void SetSpeed(float newSpeed)
        {
            speed = newSpeed;
        }
    }
}
