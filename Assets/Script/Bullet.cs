using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    Rigidbody rb;

    public GameObject effect;
    public AudioClip sound1;
    //public AudioClip sound2;

    public AudioSource audioS;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc != null)
            {
                audioS.PlayOneShot(sound1);
                Instantiate(effect, transform.position, Quaternion.identity);
                pc.Die();
            }
        }
        if(other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.velocity = transform.forward*speed;

        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
