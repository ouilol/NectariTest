using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

public class Program
{
    public static void Main()
    {
        List<Item> items = new List<Item>{new Table(1), new Paddle(2), new Balls(3)} ;

        //items contains all the items to buy
        //add the table, paddle and balls with the required quantities
        //Display the price of each item in items
        
        foreach (var item in items)
        {
            Console.WriteLine($"Item Name {item} for total of {item.getFullPrice()} $");   
        }
        Console.ReadLine();
    }
}
public abstract class Item
{
    protected int price;
    protected float weight;
    abstract public float getFullPrice();
    public float Weight { get {return weight;} }
}

class Table : Item
{
    public float Qt { get; set; }
    public Table(float qt)
    {
        price = 200;
        weight = 1000;
        Qt = qt;
    }

    public override float getFullPrice() => (price * Qt) * 1.20f; 
}

class Paddle : Item
{
    
    public float Qt { get; set; }
    public Paddle(float qt)
    {
        price = 50;
        weight = 5;
        Qt = qt;
    }
    public override float getFullPrice() => (price * Qt) * 1.20f; 
}


class Balls : Item
{  
    public float Qt { get; set; } 
    public Balls(float qt)
    {
        price = 1;
        weight = 0.5f;
        Qt = qt;
    }    
    public override float getFullPrice() => (price * Qt) * 1.20f; 
}
