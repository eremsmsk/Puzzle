using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Camera camera;
    GameObject[] golgeler;
    Vector2 baslangic_pozisyon;
    int sayac;
    public GameObject pnlFinish;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        golgeler = GameObject.FindGameObjectsWithTag("golge");
        baslangic_pozisyon = transform.position;
        sayac = 0;
    }

    private void OnMouseDrag()
    {
        Vector3 pozisyon = camera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject golge in golgeler)
            {
                if (gameObject.name == golge.name)
                {

                    float mesafe = Vector3.Distance(golge.transform.position, transform.position);
                    if (mesafe <= 1)
                    {
                        sayac++;

                        transform.position = golge.transform.position;
                        Destroy(this);
                    }
                    else
                    {
                        transform.position = baslangic_pozisyon;
                    }
                }
                
            }
        }

        if (sayac == 3)
        {
            //pnlFinish.SetActive(true);
        }
    }
}
