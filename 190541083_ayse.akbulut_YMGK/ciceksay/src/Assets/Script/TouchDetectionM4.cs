using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDetectionM4 : MonoBehaviour
{
    public int goal;
    public int curent;

    public TextMeshProUGUI goalText;

    public bool isGoalReached = false;

    public static Action<int, int, string> OnFlowerCollect;

    public GameObject buton;

    private void Start()
    {
        goal = 10;
        curent = 0;
        OnFlowerCollect?.Invoke(goal, curent, "hadi annemize yerdeki mavi çiçeklerin hepsini toplayalým");
        OnFlowerCollect?.Invoke(goal, curent, "annemize " + curent.ToString() + " adet mavi çiçek topladýk");
        goalText.text = "hadi annemize yerdeki mavi çiçeklerin hepsini toplayalým".ToUpper();
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
            OnFlowerCollect?.Invoke(goal, curent, "AFERÝN");
            isGoalReached = true;
            buton.SetActive(true);
        }


    }

    void FlowerCollect()
    {
        // Ekrana dokunulan noktayý al
        Vector2 touchPosition = Input.GetTouch(0).position;

        // Dokunulan noktayý 3D uzaydaki konuma çevir
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Eðer bir objeye çarpýldýysa
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Mavi")
            {
                curent++;
                OnFlowerCollect?.Invoke(goal, curent, "annemize yerden " + curent.ToString() + " adet mavi çiçek topladýk");
                Destroy(hit.transform.gameObject);
                
            }


        }
    }
    public void LevelUp()
    {
        SceneManager.LoadScene(5);
    }

    public void Reload()
    {
        SceneManager.LoadScene(4);
    }
}
