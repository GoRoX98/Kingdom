using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct OrderStruct
{
    public enum OrderType
    {
        None,
        Build,
        Boost,
        Repair,
        Explore,
        Spy,
        Subotage,
        Deffense,
        Raid,
        Attack
    }
    public enum OrderUrgency
    {
        NotUrgent,
        Standart,
        Urgent
    }
    private bool WeHaveTheOrder;
    //private OrderUrgency Urgency;
    private int RegionId;
    private OrderType TypeOfOrder;

    public OrderStruct (bool Order)
    {
        WeHaveTheOrder = Order;
        RegionId = 0;
        TypeOfOrder = OrderType.None;
    }

    public OrderStruct (bool Order, int RegionId, OrderType OType)
    {
        WeHaveTheOrder = Order;
        this.RegionId = RegionId;
        TypeOfOrder = OType;
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
