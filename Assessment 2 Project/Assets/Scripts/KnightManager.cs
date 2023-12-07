using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class KnightManager : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    //public GameObject knightPrefab;

    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();
    [SerializeField]
    TextMeshProUGUI scoreText;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreValue").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            scoreText.text = "Score: " + score;
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {

                    Ray ray = Camera.main.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "Collectable")
                        {
                            DeleteItem(hit.collider.gameObject);
                        }
                    }
                }
            }
        }
    }

    private void DeleteItem(GameObject Object)
    {
        //Object.SetActive(false);
        score++;
    }
}
