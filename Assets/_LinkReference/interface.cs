using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface INewUnit
{
    public void OnNewUnit(Component component_script);
}
public interface IDestroyUnit
{
    public void OnDestroyUnit(Component component_script);
}
public interface IGameResourceProvider
{
    public GameObject GetGameObject(string name);
}