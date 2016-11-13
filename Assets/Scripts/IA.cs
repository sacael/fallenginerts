﻿using UnityEngine;
using System;
using System.Collections;

public class IA : MonoBehaviour {
    enum State {WOOD,IRON,FOOD,SWORD,BOW,HORSE,SEND }
    public GameObject army;
    public Player player;
    public UnitBuildingLife building1;
    public UnitBuildingLife building2;
    public UnitBuildingLife building3;

    public Transform Lane1;
    public Transform Lane2;
    public Transform Lane3;
    private State state;
    // Use this for initialization
    void Start () {
        state = State.WOOD;
        InvokeRepeating("ComputeIA",0, 3);
	}
	void ComputeIA()
    {
        switch(state){
            case State.WOOD:
                {
                    player.BuyMinionWood(player.maxBuyableUnit(new Minion()));
                    if (player.minionFood.Count < 20)
                    {
                        state = State.FOOD;
                    }
                    else if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        state = State.SWORD;
                    }
                    break;
                }
            case State.FOOD:
                {
                    player.BuyMinionFood(player.maxBuyableUnit(new Minion()));
                    if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        state = State.SWORD;
                    }
                    break;
                }
            case State.IRON:
                {
                    player.BuyMinionIron(player.maxBuyableUnit(new Minion()));
                    state = State.SWORD;

                    break;
                }
            case State.SWORD:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Swordsman()),new Swordsman());
                    if (player.population == 200)
                    {
                        state = State.SEND;
                    }
                    else
                    {
                        state = State.BOW;

                    }
                    break;
                }
            case State.BOW:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Bowman()), new Bowman());
                    if (player.population == 200)
                    {
                        state = State.SEND;
                    }
                    else
                    {
                        state = State.HORSE;

                    }
                    break;
                }
            case State.HORSE:
                {
                    player.BuyUnit(player.maxBuyableUnit(new Horseman()), new Horseman());
                    state = State.SEND;
                    break;
                }
            case State.SEND:
                {
                    player.BuyMinionFood(player.maxBuyableUnit(new Minion()));
                    MovingArmy currentArmy = Instantiate(army).GetComponent<MovingArmy>();
                    currentArmy.player = player;
                    currentArmy.army = new Army(player);
                    Army currentRealArmy = currentArmy.army;
                    currentRealArmy.swordsmanCount = player.reserveArmy.swordsmanCount / 2;
                    currentRealArmy.horsemanCount = player.reserveArmy.horsemanCount / 2;
                    currentRealArmy.bowmanCount = player.reserveArmy.bowmanCount / 2;
                    if (building1.life == 0)
                    {
                        currentArmy.transform.position = Lane1.position;
                    }
                    else if (building2.life == 0)
                    {
                        currentArmy.transform.position = Lane2.position;
                    }
                    else if (building3.life == 0)
                    {
                        currentArmy.transform.position = Lane3.position;
                    }
                    else
                    {
                        switch ((int)Math.Round(UnityEngine.Random.value * 3 + 0.5))
                        {
                            case 1:
                                {
                                    currentArmy.transform.position = Lane1.position;
                                    break;
                                }
                            case 2:
                                {
                                    currentArmy.transform.position = Lane2.position;
                                    break;
                                }
                            case 3:
                                {
                                    currentArmy.transform.position = Lane3.position;
                                    break;
                                }
                        }
                    }
                    
                    player.reserveArmy.swordsmanCount -= currentRealArmy.swordsmanCount;
                    player.reserveArmy.bowmanCount -= currentRealArmy.bowmanCount;
                    player.reserveArmy.horsemanCount -= currentRealArmy.horsemanCount;
                    if (player.minionWood.Count < 20)
                    {
                        state = State.WOOD;
                    }
                    else if (player.minionFood.Count < 20)
                    {
                        state = State.FOOD;
                    }
                    else if (player.minionIron.Count < 20)
                    {
                        state = State.IRON;
                    }
                    else
                    {
                        if (player.reserveArmy.bowmanCount == 0)
                        {
                            state = State.BOW;
                        }
                        else if(player.reserveArmy.horsemanCount == 0)
                        {
                            state = State.HORSE;
                        }
                        else
                        {
                            state = State.SWORD;
                        }
                        
                    }
                    break;
                }
        }

    }
    // Update is called once per frame
    void Update () {
	
	}
}