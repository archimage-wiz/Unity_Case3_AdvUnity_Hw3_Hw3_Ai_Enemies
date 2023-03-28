using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ResourceProviderAssistant : MonoBehaviour, IResourceProviderAssistant
{
    private Dictionary<string, GameObject> game_objects_loaded = new Dictionary<string, GameObject>();

    public void Start() {
        AssistantsContainer.RegisterAsssistant(typeof(IResourceProviderAssistant), this);
        
    }
    
    public GameObject GetGameObject(string name)
    {
        if(game_objects_loaded.ContainsKey(name) == false) {
            game_objects_loaded[name] = (GameObject)Resources.Load($"GameObjectsPrefab/{name}");
            
        }
        return game_objects_loaded[name];
    }


}
