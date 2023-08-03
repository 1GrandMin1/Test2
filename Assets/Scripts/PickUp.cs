using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] GameObject _slotButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int  i = 0;  i <inventory._slots.Length;  i++)
            {
                if (inventory._isFull[i]== false)
                {
                    inventory._isFull[i] = true;
                    Instantiate(_slotButton, inventory._slots[i].transform);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
