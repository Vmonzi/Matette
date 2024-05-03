using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Victoria Monzi
public class Hit : MonoBehaviour
{ 
    public BaseCharacter        entityChar;
    public Animator             eusebioAnim;
    public Collider             golpe;
    public AudioSource          myAudio;
    public AudioClip            hit;

    private void Start()
    {
        entityChar = GameObject.FindObjectOfType<BaseCharacter>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (eusebioAnim.GetBool("Death")) return;

        if (other.gameObject.layer == 3)
        {
            golpe = this.GetComponent<Collider>();
            if (!entityChar.GetController.GetJumpSensor.IsFalling())
            {
                entityChar.ReceiveDamage(this.GetComponentInParent<Eusebio>().damage);
            }
            myAudio.clip = hit;
            myAudio.Play();
        }
    }
}
