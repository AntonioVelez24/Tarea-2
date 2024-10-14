using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    private Rigidbody2D myRB;
    [SerializeField]
    private float speed = 8;
    private float direction;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        //if (up == KeyCode.None) up = KeyCode.UpArrow;
        //if (down == KeyCode.None) down = KeyCode.DownArrow;
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        myRB.velocity = new Vector2(myRB.velocity.x, speed*direction);        
        float clamp = Mathf.Clamp(transform.position.y, limitInferior, limitSuperior);
        transform.position = new Vector2(transform.position.x, clamp);
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
        }
        if (other.tag == "Enemy")
        {
            player_lives = player_lives - 1;
        }
    }
    public void ReadMovementX(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<float>();
    }
}
