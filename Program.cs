using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            // создаем объект автозавода
            Autozavod Autozavod = new Autozavod();


            // создаем билдер для седана
            AutoBuilder builder = new SedanAutoBuilder();
            // строим
            Auto SedanAuto = Autozavod.Assemble(builder);
            Console.WriteLine(SedanAuto.ToString());


            // создаем билдер для универсала
            builder = new UniversalAutoBuilder();
            // строим
            Auto UniversalAuto = Autozavod.Assemble(builder);
            Console.WriteLine(UniversalAuto.ToString());


            // создаем билдер для кабриолета
            builder = new CabrioletAutoBuilder();
            // строим
            Auto CabrioletAuto = Autozavod.Assemble(builder);
            Console.WriteLine(CabrioletAuto.ToString());
            Console.WriteLine("\n--------------------------\nLab 1\t:  Patterns\nAuthor\t:  Mykola Fedko\nGroup\t:  IS-62");
            Console.Read();
        }
    }
}

// абстрактный класс строителя
abstract class AutoBuilder
{
    public Auto Auto { get; private set; }
    public void CreateAuto()
    {
        Auto = new Auto();
    }
    public abstract void SetWheel();
    public abstract void SetCarcass();
    public abstract void SetColour();
    public abstract void SetInterior();
}
// автозавод
class Autozavod
{
    public Auto Assemble(AutoBuilder AutoBuilder)
    {
        AutoBuilder.CreateAuto();
        AutoBuilder.SetWheel();
        AutoBuilder.SetCarcass();
        AutoBuilder.SetColour();
        AutoBuilder.SetInterior();
        return AutoBuilder.Auto;
    }
}

// строитель для седана
class SedanAutoBuilder : AutoBuilder
{
    public override void SetWheel()
    {
        this.Auto.Wheel = new Wheel();
    }

    public override void SetCarcass()
    {
        this.Auto.Carcass = new Carcass { Type = "Sedan" };
    }

    public override void SetColour()
    {
        this.Auto.Colour = new Colour { colour = "White" };
    }

    public override void SetInterior()
    {
        this.Auto.Interior = new Interior { Interior_type = "Leather" };
    }
}
//-------------------------------------------------------------------------------------
// строитель для универсала
class UniversalAutoBuilder : AutoBuilder
{
    public override void SetWheel()
    {
        this.Auto.Wheel = new Wheel();
    }

    public override void SetCarcass()
    {
        this.Auto.Carcass = new Carcass { Type = "Universal" };
    }

    public override void SetColour()
    {
        this.Auto.Colour = new Colour { colour = "Black" };
    }

    public override void SetInterior()
    {
        this.Auto.Interior = new Interior { Interior_type = "Textile" };
    }

}
//-------------------------------------------------------------------------------------
// строитель для кабриолета
class CabrioletAutoBuilder : AutoBuilder
{
    public override void SetWheel()
    {
        this.Auto.Wheel = new Wheel();
    }

    public override void SetCarcass()
    {
        this.Auto.Carcass = new Carcass { Type = "Cabriolet" };
    }

    public override void SetColour()
    {
        this.Auto.Colour = new Colour { colour = "Orange" };
    }

    public override void SetInterior()
    {
        this.Auto.Interior = new Interior { Interior_type = "Leather" };
    }

}
//-------------------------------------------------------------------------------------
//колеса
class Wheel
{ }
// каркас
class Carcass
{
    // тип каркаса
    public string Type { get; set; }
}

class Colour
{
    // цвет автомобиля
    public string colour { get; set; }
}

class Interior
{
    // тип салона
    public string Interior_type { get; set; }
}
//-------------------------------------------------------------------------------------

class Auto
{
    // колеса
    public Wheel Wheel { get; set; }
    // каркас
    public Carcass Carcass { get; set; }
    // цвет автомобиля
    public Colour Colour { get; set; }
    // тип салона
    public Interior Interior { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (Wheel != null)
            sb.Append("4 Wheels \n");
        if (Carcass != null)
            sb.Append(Carcass.Type + "\n");
        if (Colour != null)
            sb.Append(Colour.colour + "\n");
        if (Interior != null)
            sb.Append(Interior.Interior_type + "\n");
        return sb.ToString();
    }
}