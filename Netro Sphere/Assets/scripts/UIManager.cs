using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text text_km_total;
    [SerializeField] Text text_money;
    private GameManager gameManager;
    // Use this for initialization
    void Start()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text_money.text = gameManager.money.ToString();
        text_km_total.text = gameManager.km + " KM:";
    }
}
