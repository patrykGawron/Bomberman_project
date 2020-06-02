using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;

    public Rigidbody2D rb;
    public Animator animator;
    public Tilemap tilemap;

    private Vector3Int cell;
    private Vector2 pos;
    private Vector2 setPos;

    public Vector3Int GetCell()
    {
        return cell;
    }
    // Update is called once per frame
    void Update()
    {
        pos.x = Input.GetAxis("Horizontal");
        pos.y = Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", pos.x);
        animator.SetFloat("Vertical", pos.y);
        animator.SetFloat("Speed", pos.sqrMagnitude);

        cell = tilemap.WorldToCell(rb.position);
    }

    private void FixedUpdate()
    {
        if (Math.Abs(pos.y) > 0.5)
        {
            setPos.x = tilemap.GetCellCenterWorld(cell).x;// + pos.x * movementSpeed * Time.fixedDeltaTime;
        } 
        else
        {
            setPos.x = rb.position.x + pos.x * movementSpeed * Time.fixedDeltaTime;
        }
        if (Math.Abs(pos.x) > 0.5)
        {
            setPos.y = tilemap.GetCellCenterWorld(cell).y; // * Math.Abs(pos.x) + pos.y * movementSpeed * Time.fixedDeltaTime;
        }
        else
        {
            setPos.y = rb.position.y + pos.y * movementSpeed * Time.fixedDeltaTime;
        }
        //setPos = rb.position + pos * movementSpeed * Time.fixedDeltaTime;
        rb.position = setPos;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
    }
}
