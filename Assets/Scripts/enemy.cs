using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public Transform target;  // Referencia al transform del jugador
    public float movementSpeed = 3f;  // Velocidad de movimiento del enemigo
    public float rotateSpeed = 0.0225f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(!target){
            GetTarget();
        } else{
            RotateTowardsTarget();
        }
    }

    // Update is called once per frame
    private void FixedUpdate(){
        rb.velocity = transform.up * movementSpeed;
    }

    private void RotateTowardsTarget(){
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q =  Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            target = null;
            Debug.Log("GAME OVER PETON");
            SceneManager.LoadScene("GameOver");

        }
    }
}
