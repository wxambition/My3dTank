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
        } // 枚举类型，方向

        public Direction direction; //坦克运动的方向
        public Rigidbody rig; //坦克的刚体组件
        public float speed = 1; //坦克移动速度
        public Animator animator; //坦克的Animator组件
        public GameObject shellPrefab; //炮弹预制体
        public Transform shellPos; //炮弹产生的位置
        public GameObject shellObj; //炮弹对象

        public AudioSource[] audioSource; //声音源
        public AudioClip audioFire; //开火声音
        public AudioClip audioDestroy; //销毁声音
        public ParticleSystem particle; //爆炸特效

        public float timeDelay = 0.2f; //发射炮弹间隔的延迟

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
                    //GetComponent<Transform>()等价transform
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
