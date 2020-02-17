using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public GameObject endgameUI;
    public Scene scene;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            loseText.text = "Try Again!";
            Invoke("Restart", 1f);
        }
    }

        void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
            scene = SceneManager.GetActiveScene();
            Debug.Log("Next");

            if ((scene.name) == "level2")
                Debug.Log("Next");
            {
                Invoke("EndGame", 1f);
            }
            
            Invoke("NextLevel", 1f);
        }
    }

        void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        void Level2()
    {
        SceneManager.LoadScene("Level2");
    }

    void NextLevel() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void EndGame()
    {
        endgameUI.SetActive(true);
    }
    
}
