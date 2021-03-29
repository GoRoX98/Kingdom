using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
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
    private OrderStruct UnitOrder;


    void Awake()
    {
        MainSprite = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
        Position = GetComponent<Transform>();
        Player = GameObject.Find("Player");
        World = GameObject.Find("World");
        Parametrs.Sprites = World.GetComponent<WorldList>().UnitSprites;
        if (Type == UnitType.Advisor)
        {
            gameObject.AddComponent<BoxCollider2D>();
            UnitOrder = new OrderStruct(false, 0);
        }
    }

    void Start()
    {
        RegionPosition();
    }

    void FixedUpdate()
    {
        //Deselect
        if (Player.GetComponent<Action>().TrigerLMB == true) SelectUnit = false;

        if (Type == UnitType.Advisor)
        {
            if (SelectUnit == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    UnitOrder.NewOrder(1);
                    print("New order");
                }
            }

            if (Stay == true && UnitOrder.OrderStatus() == true && Moving == false)
            {
                Moving = true;
                MoveMode();
            }


        }

        if (Moving == true)
        {
            RegionPosition();
        }
    }

    void OnMouseDown()
    {
        //Deselect others
        //Player.GetComponent<Action>().TrigerLMB = true;
        SelectUnit = true;

    }

    private void InitializationAdviser()
    {

    }

    private void RegionPosition()
    {
        GameObject[] Regions = World.GetComponent<World>().Regions;
        for (int i = 0; Regions.Length >= i; i++)
        {
            if (Position.position.x > Regions[i].GetComponent<Transform>().position.x - 2.99f && Position.position.x < Regions[i].GetComponent<Transform>().position.x + 3.01f)
            {
                RegionIdPosition = i;
                break;
            }
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
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.localScale = new Vector2(0.3f, 0.3f);
            gameObject.transform.position = new Vector2(Position.position.x, -3.5f);
            //make icon
            if (Type == UnitType.Advisor)
            {
                if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Architect)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[3];
                }
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Capitan)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[2];
                }
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Spy)
                {
                    gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Parametrs.Sprites[1];
                }
            }
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            if (Type == UnitType.Advisor)
            {
                if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Architect)     MainSprite.sprite = Parametrs.Sprites[3];
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Capitan)   MainSprite.sprite = Parametrs.Sprites[2];
                else if (Parametrs.TypeOfAdviser == UnitParametrs.AdviserType.Spy)      MainSprite.sprite = Parametrs.Sprites[1];
            }
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<Movement>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.localScale = new Vector2(4f, 4f);
            gameObject.transform.position = new Vector2(Position.position.x, -0.1f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
