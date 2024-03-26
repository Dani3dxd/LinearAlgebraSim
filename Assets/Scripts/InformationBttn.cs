using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationBttn : MonoBehaviour
{
    [SerializeField] private GameObject _information;
    // Start is called before the first frame update
    public void whenButtonClicked()
    {
        if (_information.activeInHierarchy == true) 
            _information.SetActive(false);
        else
            _information.SetActive(true);
    }
}
