using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool SharedInstance;
    public List<GameObject> FirePooledBullets;
    public GameObject FireBulletsToPool;
    public int FireBulletAmountToPool;

    public List<GameObject> WaterPooledBullets;
    public GameObject WaterBulletsToPool;
    public int WaterBulletAmountToPool;

    public List<GameObject> EarthPooledBullets;
    public GameObject EarthBulletsToPool;
    public int EarthBulletAmountToPool;


    public List<GameObject> pooledFireExplosion;
    public GameObject FireExplosionToPool;
    public int FireExplosionAmountToPool;

    public List<GameObject> pooledWaterExplosion;
    public GameObject WaterExplosionToPool;
    public int WaterExplosionAmountToPool;

    public List<GameObject> pooledEarthExplosion;
    public GameObject EarthExplosionToPool;
    public int EarthExplosionAmountToPool;


    public List<GameObject> pooledWaterTrail;
    public GameObject WaterTrailToPool;
    public int WaterTrailAmountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {

        FirePooledBullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < FireBulletAmountToPool; i++)
        {

            tmp = Instantiate(FireBulletsToPool);
            tmp.SetActive(false);
            FirePooledBullets.Add(tmp);
        }

        WaterPooledBullets = new List<GameObject>();
        for (int i = 0; i < WaterBulletAmountToPool; i++)
        {

            tmp = Instantiate(WaterBulletsToPool);
            tmp.SetActive(false);
            WaterPooledBullets.Add(tmp);
        }

        EarthPooledBullets = new List<GameObject>();
        for (int i = 0; i < EarthBulletAmountToPool; i++)
        {

            tmp = Instantiate(EarthBulletsToPool);
            tmp.SetActive(false);
            EarthPooledBullets.Add(tmp);
        }

        pooledFireExplosion = new List<GameObject>();
        for (int i = 0; i < FireExplosionAmountToPool; i++)
        {

            tmp = Instantiate(FireExplosionToPool);
            tmp.SetActive(false);
            pooledFireExplosion.Add(tmp);
        }

        pooledWaterExplosion = new List<GameObject>();
        for (int i = 0; i < WaterExplosionAmountToPool; i++)
        {

            tmp = Instantiate(WaterExplosionToPool);
            tmp.SetActive(false);
            pooledWaterExplosion.Add(tmp);
        }

        pooledEarthExplosion = new List<GameObject>();
        for (int i = 0; i < EarthExplosionAmountToPool; i++)
        {

            tmp = Instantiate(EarthExplosionToPool);
            tmp.SetActive(false);
            pooledEarthExplosion.Add(tmp);
        }

        pooledWaterTrail = new List<GameObject>();
        for (int i = 0; i < WaterTrailAmountToPool; i++)
        {

            tmp = Instantiate(WaterTrailToPool);
            tmp.SetActive(false);
            pooledWaterTrail.Add(tmp);
        }
    }

    public GameObject GetBulletObject(int x)
    {
        if (x == 0)
        {
            for (int i = 0; i < FireBulletAmountToPool; i++)
            {
                if (!FirePooledBullets[i].activeInHierarchy)
                {
                    return FirePooledBullets[i];
                }
            }
        }
        else if (x == 1)
        {
            for (int i = 0; i < WaterBulletAmountToPool; i++)
            {
                if (!WaterPooledBullets[i].activeInHierarchy)
                {
                    return WaterPooledBullets[i];
                }
            }
        }
        else if (x == 2)
        {
            for (int i = 0; i < EarthBulletAmountToPool; i++)
            {
                if (!EarthPooledBullets[i].activeInHierarchy)
                {
                    return EarthPooledBullets[i];
                }
            }

        }

        return null;
    }

    public GameObject GetFireExplosionObject()
    {
        for (int i = 0; i < FireExplosionAmountToPool; i++)
        {
            if (!pooledFireExplosion[i].activeInHierarchy)
            {
                return pooledFireExplosion[i];
            }
        }
        return null;
    }

    public GameObject GetWaterExplosionObject()
    {
        for (int i = 0; i < WaterExplosionAmountToPool; i++)
        {
            if (!pooledWaterExplosion[i].activeInHierarchy)
            {
                return pooledWaterExplosion[i];
            }
        }
        return null;
    }

    public GameObject GetEarthExplosionObject()
    {
        for (int i = 0; i < EarthExplosionAmountToPool; i++)
        {
            if (!pooledEarthExplosion[i].activeInHierarchy)
            {
                return pooledEarthExplosion[i];
            }
        }
        return null;
    }

    public GameObject GetWaterTrailObject()
    {
        for (int i = 0; i < WaterTrailAmountToPool; i++)
        {
            if (!pooledWaterTrail[i].activeInHierarchy)
            {
                return pooledWaterTrail[i];
            }
        }
        return null;
    }

}