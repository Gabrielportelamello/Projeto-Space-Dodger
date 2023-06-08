using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPlacar : MonoBehaviour
{
    public Button button;
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PressButton", delay);
    }

    // Update is called once per frame
    void Update()
    {
        button.onClick.Invoke();
    }
}
