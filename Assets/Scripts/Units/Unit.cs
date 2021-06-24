using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Unit : MonoBehaviour
{

    public enum UnitType
    {
        Messenger = 0,
        Advisor = 1,
        Army = 2
    }

    private GameObject World;
    private GameObject Player;
    private Transform Position;
    private Animator Animator;
    private SpriteRenderer MainSprite;

    public UnitType Type;
    public UnitParametrs Parametrs;
    public int RegionIdPosition;
    public bool Stay = true;
    public bool Moving = false;
    public bool SelectUnit = false;
    public OrderStruct UnitOrder;

    public bool OrderMessege = false;
    public GameObject Point;


    void Awake()
    {
        MainSprite = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Position = GetComponent<Transform>();
        Player = GameObject.Find("Player");
        World = GameObject.Find("World");
        Parametrs.Sprites = World.GetComponent<WorldList>().UnitSprites;
    }

    void Start()
    {
        RegionPosition();
        if (Type == UnitType.Advisor)
        {
            gameObject.AddComponent<BoxCollider2D>();
            UnitOrder = new OrderStruct(false);
        }
        if (Type == UnitType.Messenger)
        {
            if (OrderMessege == true)
            {
                Moving = true;
                Stay = false;
                MoveMode();
                GetComponent<Movement>().LetsMove(Type, Point.GetComponent<Unit>().RegionIdPosition);
            }
            else Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //Deselect
        if (Player.GetComponent<Action>().TrigerLMB == true) SelectUnit = false;

        //Code for Advisors
        if (Type == UnitType.Advisor)
        {

            if (Stay == true && UnitOrder.OrderStatus() == true && Moving == false && UnitOrder.OrderPos() != RegionIdPosition)
            {
                Moving = true;
                Stay = false;
                MoveMode();
                GetComponent<Movement>().LetsMove(Type, UnitOrder.OrderPos());
            }


        }

        //Movement of unit
        if (Moving == true)
        {
            RegionPosition();
            Moving = GetComponent<Movement>().MoveStatus();
            if (Moving == false)
            {
                Stay = true;
                if (Type == UnitType.Messenger) Delivered();
            }
        }

        //Try complete order
        if (UnitOrder.OrderStatus() == true)
        {
            TryDoOrder();
            if (Type == UnitType.Army && Moving == false)
            {
                Moving = true;
                Stay = false;
                GetComponent<Movement>().LetsMove(Type, UnitOrder.OrderPos());
            }
        }

    }

    void OnMouseDown()
    {
        //Deselect others
        Player.GetComponent<Action>().TrigerLMB = true;
        SelectUnit = true;
        if (Type != UnitType.Messenger)     GameObject.Find("Canvas").GetComponent<InteractionUI>().UnitOrderUI(1, Parametrs.TypeOfAdviser, gameObject);
    }

    private void RegionPosition()
    {
        GameObject[] Regions = World.GetComponent<World>().Regions;
        for (int i = 0; Regions.Length > i; i++)
        {
            if (Position.position.x > Regions[i].GetComponent<Transform>().position.x - 2.99f && Position.position.x < Regions[i].GetComponent<Transform>().position.x + 3.01f)
            {
                RegionIdPosition = i;
                break;
            }
        }
    }

    private void TryDoOrder()
    {
        if(Stay == true && UnitOrder.OrderPos() == RegionIdPosition && Moving == false && Type != UnitType.Army)
        {
            UnitOrder.OrderComplete();
            print("Order complete");
            MoveMode();
        }

        if (Stay == true && UnitOrder.OrderPos() == RegionIdPosition && Moving == false && Type == UnitType.Army)
        {
            UnitOrder.OrderComplete();
            print("Order complete");
        }
    }

    private void MoveMode()
    {
        if (Moving == true)
        {
            MainSprite.sprite = Parametrs.Sprites[0];
            Animator.enabled = true;
            GetComponent<PolygonCollider2D>().enabled = true;
            GetComponent<Movement>().enabled = true;
            //make icon + param for advisor
            if (Type == UnitType.Advisor)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
                gameObject.transform.position = new Vector2(Position.position.x, -3.5f);

                if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Architect)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[2];
                }
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Capitan)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[3];
                }
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Spy)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[1];
                }
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else
        {
            if (Type == UnitType.Advisor)
            {
                if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Architect) MainSprite.sprite = Parametrs.Sprites[2];
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Capitan) MainSprite.sprite = Parametrs.Sprites[3];
                else MainSprite.sprite = Parametrs.Sprites[1];
                Animator.enabled = false;
                GetComponent<PolygonCollider2D>().enabled = false;
                GetComponent<Movement>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = true;
                gameObject.transform.localScale = new Vector2(4f, 4f);
                gameObject.transform.position = new Vector2(Position.position.x, -0.1f);
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else Destroy(gameObject);
        }
    }

    public void NewMessege(GameObject Unit, OrderStruct Order)
    {
        UnitOrder = Order;
        OrderMessege = true;
        Point = Unit;
    }

    public void Delivered()
    {
        Point.GetComponent<Unit>().UnitOrder.NewOrder(UnitOrder.GetOrder().Region, UnitOrder.GetOrder().Type);
        Destroy(gameObject);
    }
}
