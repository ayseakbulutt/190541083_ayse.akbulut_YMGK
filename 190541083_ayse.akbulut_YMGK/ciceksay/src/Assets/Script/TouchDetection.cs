using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDetection : MonoBehaviour
{
    public int goal;
    public int curent;

    public TextMeshProUGUI goalText;

    public bool isGoalReached = false;

    public GameObject buton;

    public static Action<int, int, string> OnFlowerCollect;

    private void Start()
    {
        goal = UnityEngine.Random.Range(8, 12);
        curent = 0;
        OnFlowerCollect?.Invoke(goal, curent, "hadi annemize yerden " + goal.ToString() + " adet �i�ek toplayal�m");
        OnFlowerCollect?.Invoke(goal, curent, "annemize yerden " + curent.ToString() + " adet �i�ek toplad�k");
        goalText.text = "hadi annemize yerden ".ToUpper() + goal.ToString() + " adet �i�ek toplayal�m".ToUpper();

        buton.SetActive(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && curent < goal)
        {
            FlowerCollect();
        }

        if (curent >= goal && !isGoalReached)
        {
            OnFlowerCollect?.Invoke(goal, curent, "AFER�N");
            isGoalReached = true;
            buton.SetActive(true);
        }


    }

    void FlowerCollect()
    {
        // Ekrana dokunulan noktay� al
        Vector2 touchPosition = Input.GetTouch(0).position;

        // Dokunulan noktay� 3D uzaydaki konuma �evir
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // E�er bir objeye �arp�ld�ysa
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Flower" || hit.transform.gameObject.tag == "Mavi")
            {
                curent++;
                OnFlowerCollect?.Invoke(goal, curent, "annemize yerden " + curent.ToString() + " adet �i�ek toplad�k");
                Destroy(hit.transform.gameObject);
            }


        }
    }

    public void LevelUp()
    {
        SceneManager.LoadScene(3);
    }

    public void Reload()
    {
        SceneManager.LoadScene(2);
    }
}
