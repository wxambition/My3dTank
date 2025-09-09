using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CLTank
{
    public class Shell : MonoBehaviour
    {
        public float speed = 5;
        public Rigidbody rg; //炮弹刚体

        void Start()
        {
            rg = GetComponent<Rigidbody>();
            //speed = 5;
        }

        void Update()
        {
            rg.velocity = transform.forward * speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
            if(collision.gameObject.name=="Brick")
            Destroy(gameObject); //销毁炮弹对象
        }
    }
}
