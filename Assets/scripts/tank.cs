using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : MonoBehaviour
{

    GameObject barrel;

    public float rotateSpeed;

    public int element = 0;

    bool canShoot = true;

    public float shootTimer = 0f;

    void Start()
    {


        barrel = GameObject.Find("Barrel");
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && canShoot)
        {
            canShoot = false;
            GameObject bullet = ObjectPool.SharedInstance.GetBulletObject(element);
            if (bullet != null)
            {
                bullet.transform.position = barrel.transform.position;
                bullet.transform.rotation = barrel.transform.rotation;
                bullet.SetActive(true);
                bullet.GetComponent<bullet>().launched();
            }
            StartCoroutine(shootDelay());
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (element >= 2)
            {
                element = 0;
            }
            else
            {
                element++;
            }
        }


        float rotationTarget = Input.mousePosition.x - 1000;
        Debug.Log(rotationTarget);
        if (
            (rotationTarget > -600 && transform.rotation.z > 0.05) ||
            (rotationTarget < 600 && transform.rotation.z < 0.75)
        )
        {
            Vector3 targetPostition = new Vector3(0,
                                        Input.mousePosition.x,
                                        0);
            transform.LookAt(targetPostition);

            Vector3 v = new Vector3(0, 0, (-rotationTarget / 10) + 45);
            transform.localRotation = Quaternion.Euler(v);
        }






    }

    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(shootTimer);

        canShoot = true;
    }
}
