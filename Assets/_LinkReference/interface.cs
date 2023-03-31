using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDepencyProvider
{
    public Component GetDepency(Type depency_type);
    public void RegisterAsssistant(Type assistant_type, Component assistant_component);
    public void AddTower(TowerTypes type, GameObject tower); // should be in assistant
    public GameObject GetTower(TowerTypes target_type);
}

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