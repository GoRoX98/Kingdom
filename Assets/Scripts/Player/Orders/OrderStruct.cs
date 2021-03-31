using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OrderStruct
{
    public enum OrderUrgency
    {
        NotUrgent,
        Standart,
        Urgent
    }
    private bool WeHaveTheOrder;
    //private OrderUrgency Urgency;
    private int RegionId;

    public OrderStruct (bool Order, int RegionId)
    {
        WeHaveTheOrder = Order;
        this.RegionId = RegionId;
    }

    public void NewOrder(int RegionId)
    {
        WeHaveTheOrder = true;
        this.RegionId = RegionId;
    }

    public bool OrderStatus()
    {
        return WeHaveTheOrder;
    }

    public int OrderPos()
    {
        return RegionId;
    }

    public void OrderComplete()
    {
        WeHaveTheOrder = false;
    }

    public string OrderText()
    {
        return $"I have order: {WeHaveTheOrder} in location {RegionId}";
    }
}
