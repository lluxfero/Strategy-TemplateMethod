// Клиентский код.
Light light = new();
Music music = new();
Discoshar disco = new();
SmartSpeakerAlice alice = new(light, music, disco);

light.TurnOff();
Console.WriteLine();
music.TurnOff();
Console.WriteLine();
light.TurnOn();


//*Свет выключился
//Реакция на выключение света:
//*Поп - музыка включилась
//* Дискошар включился

//*Музыка выключилась
//Реакция на выключение музыки:
//*Дискошар выключился

//* Свет включился
//Реакция на включение света:
//*Классическая музыка включилась


// Интерфейс Посредника
public interface ISmartHome
{
    void Notify(object sender, string ev);
}

// Конкретные Посредники
class SmartSpeakerAlice : ISmartHome
{
    private Light _light;
    private Music _music;
    private Discoshar _disco;

    public SmartSpeakerAlice(Light b, Music s, Discoshar d)
    {
        this._light = b;
        this._light.SetMediator(this);
        this._music = s;
        this._music.SetMediator(this);
        this._disco = d;
        this._disco.SetMediator(this);
    }

    public void Notify(object sender, string myEvent)
    {
        if (myEvent == "LightOff")
        {
            Console.WriteLine("Реакция на выключение света:");
            this._music.TurnOnPop();
            this._disco.TurnOn();
        }
        if (myEvent == "MusicOff")
        {
            Console.WriteLine("Реакция на выключение музыки:");
            this._disco.TurnOff();
        }
        if (myEvent == "LightOn")
        {
            Console.WriteLine("Реакция на включение света: ");
            this._music.TurnOnClassical();
        }
    }
}

// Базовый Компонент обеспечивает базовую функциональность
class SmartHomeComponent
{
    protected ISmartHome _mediator;

    public SmartHomeComponent(ISmartHome mediator = null)
    {
        this._mediator = mediator;
    }

    public void SetMediator(ISmartHome mediator)
    {
        this._mediator = mediator;
    }
}

// Конкретные Компоненты реализуют различную функциональность
class Light : SmartHomeComponent
{
    public void TurnOn()
    {
        Console.WriteLine("*Свет включился");
        this._mediator.Notify(this, "LightOn");
    }

    public void TurnOff()
    {
        Console.WriteLine("*Свет выключился");
        this._mediator.Notify(this, "LightOff");
    }
}

class Music : SmartHomeComponent
{
    public void TurnOnPop()
    {
        Console.WriteLine("*Поп-музыка включилась");
        this._mediator.Notify(this, "MusicOn");
    }
    public void TurnOnClassical()
    {
        Console.WriteLine("*Классическая музыка включилась");
        this._mediator.Notify(this, "MusicOn");
    }

    public void TurnOff()
    {
        Console.WriteLine("*Музыка выключилась");

        this._mediator.Notify(this, "MusicOff");
    }
}

class Discoshar : SmartHomeComponent
{
    public void TurnOn()
    {
        Console.WriteLine("*Дискошар включился");
        this._mediator.Notify(this, "DiscosharOn");
    }

    public void TurnOff()
    {
        Console.WriteLine("*Дискошар выключился");

        this._mediator.Notify(this, "DiscosharOff");
    }
}
