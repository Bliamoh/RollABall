using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody _rb;
    private int _count;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();

        WinText.text = string.Empty;
    }

	void FixedUpdate ()
	{
	    float moveHorizontal = Input.GetAxis("Horizontal");
	    float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            _count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + _count;
        if (_count == 12)
        {
            WinText.text = "You Win!";
        }
    }
}
