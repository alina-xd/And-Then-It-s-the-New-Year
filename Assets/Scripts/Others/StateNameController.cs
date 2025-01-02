using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateNameController : MonoBehaviour
{
    //player information
    public static bool CanMove;//can move or not
    public static string PlayerName;//player name typed in open screen

    //notes controller
    public static int NoteLength = 0;
    //1,5

    //dialogue controller

    public static bool DialogueRunning;

    //bedroom
    public static int Dindex;//diary iteration index
    public static bool BedroomDiary;//bedroom diary open=true
    public static bool BedroomDialogue1;//bedroom introduction dialogue open=true
    public static bool BedroomDialogue1Started;//box only appear once
    public static bool BedroomDialogue2;//bedroom go to door dialogue open=true
    public static bool BedroomDialogue2Started;//box only appear once

    //living room
    public static bool LivingRoomDialogue1 = true;//living room introduction dialogue open=true
    public static bool LivingRoomDialogue1Started;//dialogue only triggered once
    public static bool LivingRoomDialogue2;//living room cleaning dialogue open=true
    public static bool LivingRoomDialogue2Started;//dialogue only triggered once
    public static bool LivingRoomDialogue3;//living room cleaning end dialogue open=true
    public static bool LivingRoomDialogue3Started;//dialogue only triggered once
    public static bool LivingRoomDialogue4;//living room cleaning end dialogue open=true
    public static bool LivingRoomDialogue4Started;//dialogue only triggered once

    public static bool LivingRoomDialogue5 = true;//relatives in
    public static bool LivingRoomDialogue5Started;//dialogue only triggered once
    public static bool LivingRoomDialogue6;//Dad estracizes us
    public static bool LivingRoomDialogue6Started;//dialogue only triggered once

    public static bool LivingRoomDialogue7 = true;
    public static bool LivingRoomDialogue7Started;

    //counter top
    public static bool CounterTopDialogue1 = true;
    public static bool CounterTopDialogue1Started;
    public static bool CounterTopDialogue2;
    public static bool CounterTopDialogue2Started;
    public static bool CounterTopDialogue3;
    public static bool CounterTopDialogue3Started;
    public static bool CounterTopDialogue4;
    public static bool CounterTopDialogue4Started;
    public static bool CounterTopDialogue5;
    public static bool CounterTopDialogue5Started;
    public static bool CounterTopDialogue6;
    public static bool CounterTopDialogue6Started;

    //dinner table
    public static bool DinnerDialogue1 = true;
    public static bool DinnerDialogue1Started;
    public static bool DinnerDialogue2;
    public static bool DinnerDialogue2Started;
    //food
    public static bool FishDialogue;
    public static bool FishDialogueStarted;
    public static bool DongpoRouDialogue;
    public static bool DongpoRouDialogueStarted;
    public static bool PekingDuckDialogue;
    public static bool PekingDuckDialogueStarted;
    public static bool BokChoiDialogue;
    public static bool BokChoiDialogueStarted;
    public static bool LionsHeadDialogue;
    public static bool LionsHeadDialogueStarted;
    public static bool MapoTofuDialogue;
    public static bool MapoTofuDialogueStarted;
    public static bool DumplingsDialogue;
    public static bool DumplingsDialogueStarted;

    //talking to relatives
    //grandma
    public static bool GrandmaDialogue;
    public static bool GrandmaDialogueStarted;
    //grandpa
    public static bool GrandpaDialogue;
    public static bool GrandpaDialogueStarted;
    //auntie
    public static bool AuntDialogue;
    public static bool AuntDialogueStarted;
    //uncle
    public static bool UncleDialogue;
    public static bool UncleDialogueStarted;

    //kitchen
    public static bool KitchenDialogue1;//kitchen introduction dialogue open=true
    public static bool KitchenDialogue1Started;//dialogue only triggered once

    //door
    public static bool DoorDialogue1 = true;//instructions about fu writing
    public static bool DoorDialogue1Started;
    public static bool DoorDialogue2;//example of fu writing
    public static bool DoorDialogue2Started;
    public static bool DoorDialogue3 = true;//relatives coming
    public static bool DoorDialogue3Started;

    //street
    public static bool StreetDialogue1 = true;
    public static bool StreetDialogue1Started;
    public static bool StreetDialogue2;
    public static bool StreetDialogue2Started;

    //store dialogues
    public static bool QuanjiaDialogue;
    public static bool UnnamedDialogue;
    public static bool ShaxianDialogue;
    public static bool BaiguoyuanDialogue;
    public static bool MixueDialogue;
    public static bool LaiyifenDialogue;
    public static bool LanzhoulamianDialogue;
    public static bool IcbcDialogue;

    //lion dance
    public static bool LionCanMove;
    public static bool DiveComplete;
    public static bool StandUpComplete;
    public static bool LionDanceDialogue1 = true;//stand up instruction
    public static bool LionDanceDialogue1Started;
    public static bool LionDanceDialogue2;//dive instruction
    public static bool LionDanceDialogue2Started;
    public static bool LionDanceDialogue3;//conclusion and free time
    public static bool LionDanceDialogue3Started;

    //fireworks
    public static bool FireworkDialogue1 = true;
    public static bool FireworkDialogue1Started;
    public static bool FireworkDialogue2;
    public static bool FireworkDialogue2Started;

    //observable scene switcher controller
    public static bool DoorAppear;//door in bedroom (scene switcher) appear
    public static bool LivingRoomToKitchen;//switch from living room to kitchen
    public static bool KitchenToLivingRoom;//switch from kitchen to living room

    //living room related
    public static bool CleaningBegin;//trash and stain appear
    public static bool CleaningEnd;//true=dirt does not appear
    public static bool CleanWindow;
    public static bool CleanWall;
    public static int CleanCount;
    public static bool DaddyAppears;
    public static bool PickRelative;//whether picking is available
    public static int Relative;//1=grandpa,2=grandma,3=aunt,4=uncle

    //door related
    public static bool FuWriting;

    void Start()
    {
        CanMove = true;
        //NoteLength = 0;
    }

    //quick start living room scribit for test
    public void QuickLivingRoom()
    {
        LivingRoomDialogue1 = true;
    }
    //quick start kitchen script for test
    public void QuickKitchen()
    {
        KitchenDialogue1 = true;
    }
    //quick start living room scribit for test
    public void QuickLivingRoom2()
    {
        LivingRoomDialogue2 = true;
    }
    public void QuickLivingRoom3()
    {
        LivingRoomDialogue3 = true;
    }
    public void QuickLivingRoom5()
    {
        LivingRoomDialogue5 = true;
    }
    public void QuickDoor()
    {
        DoorDialogue1 = true;
    }
    public void QuickDoorOpen()
    {
        DoorDialogue3 = true;
    }
}
