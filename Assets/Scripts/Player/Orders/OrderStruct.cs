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
        if (TypeOfOrder == OrderType.None) WeHaveTheOrder = false;
    }

    public void NewOrder(int RegionId, OrderType TypeOfOrder)
    {
        WeHaveTheOrder = true;
        this.RegionId = RegionId;
        this.TypeOfOrder = TypeOfOrder;
        if (TypeOfOrder == OrderType.None) WeHaveTheOrder = false;
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

    public (int Region, OrderType Type) GetOrder()
    {
        return (RegionId, TypeOfOrder);
    }

    /// <summary>
    /// Convert Srting to OrderType
    /// </summary>
    /// <param name="Type">string name of order type</param>
    /// <returns>OrderType</returns>
    public OrderType ToOrderType(string Type)
    {
        OrderType newOrder;
        if (Type == "Subotage") newOrder = OrderType.Subotage;
        else if (Type == "Build") newOrder = OrderType.Build;
        else if(Type == "Boost") newOrder = OrderType.Boost;
        else if(Type == "Repair") newOrder = OrderType.Repair;
        else if(Type == "Explore") newOrder = OrderType.Explore;
        else if(Type == "Spy") newOrder = OrderType.Spy;
        else newOrder = OrderType.None;

        return newOrder;
    }
}
