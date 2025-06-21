using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDetectionM3 : MonoBehaviour
{
    public int goal;
    public int curent;

    public TextMeshProUGUI goalText;

    public bool isGoalReached = false;

    public static Action<int, int, string> OnFlowerCollect;

    public GameObject buton;

    private void Start()
    {
        goal = 20;
        curent = 0;
        OnFlowerCollect?.Invoke(goal, curent, "hadi annemize yerdeki çiçeklerin hepsini toplayalým");
        OnFlowerCollect?.Invoke(goal, curent, "annemize yerden " + curent.ToString() + " adet çiçek topladýk");
        goalText.text = "hadi annemize yerdeki çiçeklerin hepsini toplayalým".ToUpper();
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
            Debug.DrawLine(touchPosition, hit.transform.position);

            if (hit.transform.gameObject.tag == "Flower" || hit.transform.gameObject.tag == "Mavi")
            {
                curent++;
                OnFlowerCollect?.Invoke(goal, curent, "annemize yerden " + curent.ToString() + " adet çiçek topladýk");
                Destroy(hit.transform.gameObject);
                
            }


        }
    }
    public void LevelUp()
    {
        SceneManager.LoadScene(4);
    }

    public void Reload()
    {
        SceneManager.LoadScene(3);
    }


}
