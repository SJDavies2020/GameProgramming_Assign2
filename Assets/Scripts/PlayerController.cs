using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PLayerController : MonoBehaviour
{
    public float targetTime = 60.0f;
    public float moveSpeed = 50f;
    public Rigidbody2D rb;
    Vector2 moveMent;
    public Animator animator;
    public GameObject[] Items;
    public TMPro.TMP_Text ItemsCOl;
    public TMPro.TMP_Text TotalItems;
    public TMPro.TMP_Text Time;
    private int A = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        TotalItems.text = Items.Length.ToString();
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
            A += 1;
            ItemsCOl.text = A.ToString();
        }
    }
}
