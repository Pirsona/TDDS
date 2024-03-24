using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIN : MonoBehaviour
{
    private float _speed=50;
    private PlayerController _controller;
    // Start is called before the first frame update
    void Start()
    {
       _controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(1);
    }
}
