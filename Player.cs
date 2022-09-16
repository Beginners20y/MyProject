using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float JumpSpeed = 5f;
    public float speedT;
    private Rigidbody rig;
    public float swipeS = 5f;
    public bool Right;
    public bool Left;
    public LayerMask Ground;
    public Transform GroundCheck;
    public ParticleSystem DeathEffect;
    public ParticleSystem DeathEffect2;
    public ParticleSystem DeathEffect3;
    public GameObject Lose;
    public GameObject Finish;
    public GameObject Quad1;
    public AudioSource Background;
    public AudioSource FinishAudio;
    private bool Stop = true;
   

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Invoke("PlayBackgroundAudio",1.0f);
    }


    void Update()
    {  
        transform.Translate(Vector3.forward * speedT * Time.deltaTime);//forward;

        if(Input.touchCount > 0)
        {               
            if(finger.deltaPosition.x > 1.0f)  
            {
                Right = true;
                Left = false;
            }
           
             if(finger.deltaPosition.x < -1.0f)
            {
                Right = false;
                Left = true;
            }
        }
        else if(Input.touchCount < 0)
        {
            speedT = 0;
            Left = false;
            Right = false;
        }
     }

     bool IsGrounded()
     {
        return Physics.CheckSphere(GroundCheck.position, .1f, Ground);
     }

     private void OnCollisionEnter(Collision col)
     {
        if(col.gameObject.tag == "Trap")
        {
            Instantiate(DeathEffect, transform.position,Quaternion.identity);
            Destroy(gameObject);
            Lose.SetActive(true);
            Background.Stop();
        }
        
        if(col.gameObject.tag == "Trap2")
        {
            Instantiate(DeathEffect2, transform.position,Quaternion.identity);
            Destroy(gameObject);
            Lose.SetActive(true);
            Background.Stop();
        }

        if(col.gameObject.tag == "Trap3")
        {
            Instantiate(DeathEffect3, transform.position,Quaternion.identity);
            Destroy(gameObject);
            Platf.Size=0.6f;
            Lose.SetActive(true);
            Background.Stop();
        }

        if(col.gameObject.tag == "Trap5")
        {
            Instantiate(DeathEffect, transform.position,Quaternion.identity);
            Destroy(gameObject);
            Platf.Size = 0.6f;
            Lose.SetActive(true);
            Background.Stop();
            SpawM.MoveT = false;
        }

        if(col.gameObject.tag == "MoveTraps")
        {
            SpawM.MoveT = true;
        }

        if(col.gameObject.tag == "Finish")
        {
            speedT = 0f;
            Stop = false;
            Quad1.SetActive(true);
            Finish.SetActive(true);
            Background.Stop();
            FinishAudio.Play();
        }
     }

      void PlayBackgroundAudio()
     {
        Background.Play();
     }
 }


