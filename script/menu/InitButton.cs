using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InitButton : MonoBehaviour
{
    private GameObject lastSelect;

    // Start is called before the first frame update
    void Start()
    {
        lastSelect = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        //使选择始终停留在页面上
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelect);
        }
        else
        {
            lastSelect = EventSystem.current.currentSelectedGameObject;
        }
    }
}
