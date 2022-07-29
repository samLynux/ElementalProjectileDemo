using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float timer = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void particleEvent()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {
        yield return new WaitForSeconds(timer);

        gameObject.SetActive(false);
    }

}
