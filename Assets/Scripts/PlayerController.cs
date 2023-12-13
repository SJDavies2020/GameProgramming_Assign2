using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class PLayerController : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float moveSpeed = 25f;
    private Rigidbody2D rb;
    Vector2 moveMent;
    private Animator animator;
    public GameObject[] Items;
    public TMPro.TextMeshProUGUI ItemsCol;
    public TMPro.TextMeshProUGUI TotalItems;
    public GameObject Finish;
    public TMPro.TMP_Text Time;
    private int B = 0;

    public GameObject[] Item;
    public AudioClip[] audioClips;
    private AudioSource AudioManager;
    public GameObject Lever1;
    public GameObject Lever2;
    public GameObject Door1;
    public GameObject Door2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TotalItems.text = Items.Length.ToString();
        AudioManager = GetComponent<AudioSource>();
        moveSpeed = 25f;
    }

    private void Update()
    {
        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveMent.x);
        animator.SetFloat("Vertical", moveMent.y);
        animator.SetFloat("Speed", moveMent.sqrMagnitude);

        Debug.Log(moveMent.x);
        Debug.Log(moveMent.y);

        targetTime -= UnityEngine.Time.deltaTime;
        Time.text = targetTime.ToString();
        Debug.Log(Time.text);

        if (targetTime <= 0.0f)
        {
            //timerEnded();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveMent * moveSpeed * UnityEngine.Time.fixedDeltaTime);
        Debug.Log("Body Position: " + rb.position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Item"))
        {
            Destroy(collision.gameObject);

            B = Int32.Parse(ItemsCol.text);
            B = B + 1;
            Debug.Log("Count" +B);
            ItemsCol.SetText(B.ToString());
            //Item.SetValue(gameObject.name, A);
            PlayClip(collision.gameObject.name);
            
        }
        if (collision.gameObject.name.Equals("Lever1"))
        {
            PlayClip(collision.gameObject.tag);
            Door1.SetActive(false);
        }
        else if (collision.gameObject.name.Equals("Lever2"))
        {
            PlayClip(collision.gameObject.tag);
            Door2.SetActive(false);
        }

        else if (collision.gameObject.name.Equals("Exit"))
        {
            PlayClip(collision.gameObject.tag);
            Finish.SetActive(true);
        }

    }

    void PlayClip(string AudioType)
    {
        if (AudioType == "Coin" || AudioType == "Vase")
        {
            AudioManager.clip = audioClips[0];
            AudioManager.PlayOneShot(audioClips[0]);
        }
        else if (AudioType == "DoorOpen")
        {                                                                  
            AudioManager.PlayOneShot(audioClips[1]);
            AudioManager.PlayOneShot(audioClips[1]);
        }
        else if (AudioType == "KeyPickup")
        {
            AudioManager.PlayOneShot(audioClips[2]);
            AudioManager.PlayOneShot(audioClips[2]);
        }
        else if (AudioType == "LevelDone")
        {
            AudioManager.PlayOneShot(audioClips[3]);
            AudioManager.PlayOneShot(audioClips[3]);
        }
        else if (AudioType == "Lever")
        {
            AudioManager.PlayOneShot(audioClips[4]);
            AudioManager.PlayOneShot(audioClips[4]);
        }
        else if (AudioType == "Finish")
        {
            AudioManager.PlayOneShot(audioClips[3]);
            AudioManager.PlayOneShot(audioClips[3]);
        }
    }

}
