using System;
using System.Collections.Generic;
using System.Linq;

public class KeyValue<K, V>
{
    public K key;
    public V value;

    public KeyValue(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

class MyHashMap<K, V>
{
    private const int bucketSize = 16;

    private readonly LinkedList<KeyValue<K, V>>[] elements = new LinkedList<KeyValue<K, V>>[bucketSize];


    private int GetPositionByHash(K key)
    {
        if (key.Equals(null))
        {
            throw new ArgumentNullException();
        }
        int hashCode = key.GetHashCode();
        hashCode = (hashCode) ^ (hashCode >> bucketSize);
        int index = hashCode & (bucketSize - 1);
        return index;

    }

    public void Put(K key, V value)
    {
        int position = GetPositionByHash(key);
        bool keyAlreadyExists = false;

        KeyValue<K, V> itemToAdd = new KeyValue<K, V>(key, value);

        if (elements[position] != null)
        {
            foreach (var listItem in elements[position])
            {
                if (listItem.key.Equals(itemToAdd.key))
                {
                    listItem.value = itemToAdd.value;
                    keyAlreadyExists = true;
                }
            }
        }
        else
        {
            LinkedList<KeyValue<K, V>> linkedList = new LinkedList<KeyValue<K, V>>();
            linkedList.AddLast(itemToAdd);
            elements[position] = linkedList;
            keyAlreadyExists = true;
        }
        
        if (!keyAlreadyExists)
        {
            elements[position].AddLast(itemToAdd);
        }
    }

    public V Get(K key)
    {
        int hashCode = key.GetHashCode();
        hashCode = (hashCode) ^ (hashCode >> bucketSize);
        int index = hashCode & (bucketSize - 1);

        if (elements[index] != null)
        {
            foreach (var item in elements[index])
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
        }
        throw new ArgumentNullException();
        
    }

    public void Clear()
    {
        foreach (var element in elements)
        {
            if (element != null)
            {
                element.Clear();
            }
        }
    }

    public V Remove(K key)
    {
        int index = GetPositionByHash(key);
        if (elements[index] != null)
        {
            foreach (var item in elements[index])
            {
                if (item.key.Equals(key))
                {
                    V result = item.value;
                    elements[index].Remove(item);
                    return result;
                }
            }
        }

        throw new ArgumentNullException();
    }

}

public class Solution
{
    private static void Main(string[] args)
    {
        MyHashMap<string, int> myMap = new MyHashMap<string, int>();

        // helper list to store all the keys
        List<string> keys = new List<string>();

        string line;

        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
        {
            if (line == "CLEAR")
            {
                myMap.Clear();
                keys.Clear();
                continue;
            }

            string[] keyValue = line.Split(' ');

            string key = keyValue[0];

            if (key == "REMOVE")
            {
                string keyToRemove = keyValue[1];
                int removedValue = myMap.Remove(keyToRemove);
                keys.Remove(keyToRemove);
                Console.WriteLine(removedValue + " removed");
                continue;
            }

            int value = int.Parse(keyValue[1]);

            myMap.Put(key, value);
            if (!keys.Contains(key))
            {
                keys.Add(key);
            }
        }

        foreach (string key in keys)
        {
            Console.WriteLine(myMap.Get(key));
        }
    }
}