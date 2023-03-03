using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    Ray ray;
    RaycastHit hit;
    public float speed = 10f;

    Vector3 lastClickedPosition;

    bool moving;

    public float magic;

    public Slider Slider;

    public float minutes;

    public float seconds;

    public float timeRemaining = 120;

    public TextMeshProUGUI timer;

    public GameObject ClickedObject;

    public TextMeshProUGUI Beetles;

    public int BeetleCount;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);

            timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            moving = true;

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Beetle")
                {
                    ClickedObject = hit.transform.gameObject;
                    Destroy(ClickedObject);
                    BeetleClicked();
                }
            }
        }

        if(moving && (Vector3)transform.position != lastClickedPosition)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, lastClickedPosition, step);
        }
        else
        {
            moving = false;
        }

        if(timeRemaining < 0)
        {
            Destroy(gameObject);
        }
    }

    public void MagicCollected()
    {
        magic += 0.5f;
        Slider.value = magic;
    }

    public void BeetleClicked()
    {
        magic = magic - 0.1f;
        Slider.value = magic;
        BeetleCount--;
        Beetles.text = BeetleCount.ToString();
    }

}
