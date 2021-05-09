using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassKMD
{
    public static class EventProjectClass
    {
        // делегаты настроек приложения
        //public delegate bool EventSettingApp(); //делегат события добавления МС
       // public static EventAddMSInProject EventAddMSInProjectHandler; //событие добавления МС
        // делегаты настроек приложения

        // делегаты МС
        public delegate bool EventAddMSInProject(MountingScheme ms); //делегат события добавления МС
        public static EventAddMSInProject EventAddMSInProjectHandler; //событие добавления МС

        public delegate bool EventEditMSInProject(int index, MountingScheme ms);//делегат события изменения МС
        public static EventEditMSInProject EventEditMSInProjectHandler;//событие изменения МС
        // делегаты МС

        // делегаты марки
        public delegate bool EventAddMarkaInMS(MarkaKMD marka); //делегат события добавления марки в МС
        public static EventAddMarkaInMS EventAddMarkaInMSHandler; //событие добавления марки

        public delegate List<MarkaKMD> EventArrayMarks(); //делегат передачи массива марок
        public static EventArrayMarks EventArrayMarksHandler; // событие передачи массива марок

        public delegate bool EventEditMarkaInMS(int index, MarkaKMD marka); //делегат события изменения марки
        public static EventEditMarkaInMS EventEditMarkaInMSHandler; //событие изменения марки

        public delegate void EventSettingMarka(SettingMarkaKMD setting); //делегат события изменения настроек марки
        public static EventSettingMarka EventSettingMarkaHandler; //событие изменения настройки марки марки
        // делегаты марки

        // делегаты листа ОЭ
        public delegate bool EventAddListInMS(ListOE list); //делегат события добавления листа в МС
        public static EventAddListInMS EventAddListInMSHandler; //событие добавления листа

        public delegate List<ListOE> EventArrayListOE(); //делегат передачи массива листов в МС
        public static EventArrayListOE EventArrayListOEHandler; // событие передачи массива листов

        public delegate bool EventEditListInMS(int index, ListOE list);//делегат события изменения листа
        public static EventEditListInMS EventEditListInMSHandler;//событие изменения листа
                                                                 // делегаты листа ОЭ

        // делегаты МШ
        public delegate bool EventAddMShInMS(MSh msh); //делегат события добавления МШ в МС
        public static EventAddMShInMS EventAddMShInMSHandler; //событие добавления МШ        

        public delegate bool EventEditMShInMS(int index, MSh msh);//делегат события изменения МШ
        public static EventEditMShInMS EventEditMShInMSHandler;//событие изменения МШ
        // делегаты МШ

        // делегаты ММ
        public delegate bool EventAddMMInMS(MM mm); //делегат события добавления ММ в МС
        public static EventAddMMInMS EventAddMMInMSHandler; //событие добавления ММ        

        public delegate bool EventEditMMInMS(int index, MM mmm);//делегат события изменения ММ
        public static EventEditMMInMS EventEditMMInMSHandler;//событие изменения ММ
        // делегаты ММ

        // делегаты CШ
        public delegate bool EventAddZSh(ZSh zsh); //делегат события добавления CШ
        public static EventAddZSh EventAddZShHandler; //событие добавления CШ        

        public delegate bool EventEditZSh(int index, ZSh zsh);//делегат события изменения CШ
        public static EventEditZSh EventEditZShHandler;//событие изменения CШ
        // делегаты CШ

        // делегаты детали КМД
        public delegate bool EventAddPartInMarka(PartKMD part); //делегат события добавления детали в марку
        public static EventAddPartInMarka EventAddPartInMarkaHandler; //событие добавления детали

        public delegate bool EventEditPartInMarka(int index, PartKMD part); //делегат события изменения детали в марке
        public static EventEditPartInMarka EventEditPartInMarkaHandler; //событие изменения детали
        // делегаты детали КМД

        // делегаты процесса выполнения Статус-панели
        public delegate void EventValueProgress(int value); //делегат события изменения шкалы прогресса
        public static EventValueProgress EventValueProgressHandler; //событие изменения шкалы прогресса
        // делегаты процесса выполнения Статус-панели


    }
}
