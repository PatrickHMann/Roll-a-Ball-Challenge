using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text scoreText;
    public Text loseText;
    private Rigidbody rb;
    private int count;
    private int lives;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            score = score + 1;

            SetText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            lives = lives - 1; 
            SetText();
        }

    }

    void SetText()
    {

        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You Lose!";
            Destroy(rb);
        }
        if (score == 12)
        {
            rb.transform.position = new Vector3(67.09f, 0.57f, 25.49f);
        }
        if (score == 20)
        {
            winText.text = "You win!";
        }

    }


}