    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
  public Rigidbody2D rb { get; private set; }
  public Animator anim { get; private set; }
  public GameObject alivego { get; private set; }

    public virtual void Start()
    {
        alivego = transform.Find("Alive").gameObject;
        rb = alivego.GetComponent<Rigidbody2D>();
        anim = alivego.GetComponent<Animator>();
    }
}
