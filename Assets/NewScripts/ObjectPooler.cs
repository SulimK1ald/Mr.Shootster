/*using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler instance;

    [Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Bullet_1,
            Bullet_2,
            Bullet_3,
            Bullet_4,
        }

        public ObjectType Type;
        public GameObject prefab;
        public int StartCount;
    }

    [SerializeField]
    private List<ObjectInfo> objectsInfo;

    private Dictionary<ObjectInfo.ObjectType, Pool> pools;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        initPool();
    }

    private void initPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>();

        var emptyGo = new GameObject();

        foreach (var obj in objectsInfo)
        {
            var container = Instantiate(emptyGo, transform, false);
            container.name = obj.Type.ToString();

            pools[obj.Type] = new Pool(container.transform);

            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObject(obj.Type, container.transform);
                pools[obj.Type].Objects.Enqueue(go);
            }
        }
        Destroy(emptyGo);
    }
    private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent)
    {
        var go = Instantiate(objectsInfo.Find(x >= x.Type == type).prefab, parent);
        go.SetActive(false);
        return go;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0 ?
            pools[type].Objects.Dequeue() : InstantiateObject(type, pools[type].Container);

        obj.SetActive(true);
        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<iPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
    }
}*/
