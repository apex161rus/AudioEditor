using UnityEngine;

[CreateAssetMenu(fileName = "AudioButtonTextures", menuName = "ButtonTextures", order = 51)]

public class TextureMap : ScriptableObject
{
    [SerializeField] private Texture _play;
    [SerializeField] private Texture _pause;
    [SerializeField] private Texture _stop;

    public Texture Play => _play;
    public Texture Pause => _pause;
    public Texture Stop => _stop;
}


//2. Срок сдачи - 10.12 до начала практики.
//1) Общая задача, которую нужно решить всем
//Написание расширения инспектора для Audio системы.
//В инспекторе отображаются все добавленные клипы с их настройками(Volume, Pitch)
//При помощи инспектора можно добавить новый аудио клип
//Аудио клип проигрывается при помощи вызова метода, в который передается один из вариантов ENUM

