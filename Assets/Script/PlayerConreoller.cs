using System.Collections;
using System.Collections.Generic;



using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public VariableJoystick joy;
    private Animator anim;
    public bool isDie;

    public void Die()
    {
        isDie = true;
        
        StartCoroutine(DelayDie());
        
        
    }

    IEnumerator DelayDie()
    {
        if (isDie == true)
        {
            anim.SetBool("isDie", true);
        }
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isDie = false;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spaceship")
        {
            SceneManager.LoadScene("ClearScenes");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;


        float xspeed = xInput * speed;
        float zspeed = zInput * speed;

        Vector3 newVe1 = new Vector3(xspeed, 0f, zspeed);
        //playerRigidbody.velocity = newVe1;

        if ((!isDie) &&(xInput != 0f || zInput != 0f))
        {
            //playerRigidbody.velocity = newVel;
            playerRigidbody.transform.rotation = Quaternion.LookRotation(newVe1);
            playerRigidbody.MovePosition(playerRigidbody.position
                                    + transform.forward * speed * Time.deltaTime);
        }

    }
}
