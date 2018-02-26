using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShop : MonoBehaviour {

    public float pizzaCount;

	// Use this for initialization
	void Start () {

        Services.EventManager.Register<PizzaShopHit>(EatPizza);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        Services.EventManager.Unregister<PizzaShopHit>(EatPizza);
    }

    public void EatPizza(GC.GameEvent e)
    {
        pizzaCount++;
        Debug.Log("pizzas eaten = " + pizzaCount);
    }

}
