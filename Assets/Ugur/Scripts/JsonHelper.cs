using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.name;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.name = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.name = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);

    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] name;
        
    }
}