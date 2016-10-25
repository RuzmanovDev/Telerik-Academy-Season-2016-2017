# Singleton

## Намерение
Това е патърн, който цели нашето приложение да има една единствена инстанция от определен обект.
Бихме искали да имаме такава споделена инстанция в нашите класове, когато става дума например за някакъв логер.

## Пример
```
using System;

namespace SingletonDesignPattern
{
  /// <summary>
  /// Главен клас за стартиране на примерното приложение
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Главен метод за стартиране
    /// </summary>
    static void Main()
    {

      // Конструкторът е защитен -- операторът new не може да бъде извикан
      Singleton s1 = Singleton.Instance();
      Singleton s2 = Singleton.Instance();

      // Проверка за идентичност на инстанцията
      if (s1 == s2)
      {
        Console.WriteLine("Objects are the same instance"); //и двата обекта са една и съща инстанция на този клас
      }
      // Изчакай удар по конзолата от Котребителя
      Console.ReadKey();
    }
  }

  /// <summary>
  /// The 'Singleton' class – класът Сек
  /// </summary>
  class Singleton
  {
    private static Singleton _instance;  //променлива за единствената инстанция на този клас
    // Конструторът е защитен и не може да бъде извикан
    protected Singleton()
    {

    }

    // Единтвеният начин за инстанцииране е от тук
    public static Singleton Instance()
    {
      // Използва късна инициализация (lazy initialization)
      // N.B.: Да не се използва в многонишкови приложения
      if (_instance == null)
      {
        _instance = new Singleton();
      }
      return _instance;
    }
  }

}
```

# Abstract Factory

## Намерение

Това е патърн, който позволява да отделим и енкапсулираме логиката по създаването на обектите. 
Клиентът създава конкретна имплементация на абстрактната фабрика и я използва през абстрактния интерфейс, 
за да създава конкретни обекти. Той не се интересува какъв конкретен обект получава, тъй като използва само интерфейса на продукта.
Използва се когато нашето приложение ще работи с различни и често изменящи се обекти.

## Пример
```
 abstract class GUIFactory {
     public static GUIFactory getFactory() {
         int sys = readFromConfigFile("OS_TYPE");
         if (sys==0) {
             return(new WinFactory());
         } else {
             return(new OSXFactory());
         }
    }
    public abstract Button createButton();
 }

 class WinFactory:GUIFactory {
     public override Button createButton() {
         return(new WinButton());
     }
 }

 class OSXFactory:GUIFactory {
     public override Button createButton() {
         return(new OSXButton());
     }
 }

 abstract class Button  {
     public string caption;
     public abstract void paint();
 }

 class WinButton:Button {
     public override void paint() {
        Console.WriteLine("I'm a WinButton: "+caption);
     }
 }

 class OSXButton:Button {
     public override void paint() {
        Console.WriteLine("I'm a OSXButton: "+caption);
     }
 }

 class Application {
     static void Main(string[] args) {
         GUIFactory aFactory = GUIFactory.getFactory();
         Button aButton = aFactory.createButton();
         aButton.caption = "Play";
         aButton.paint();
     }
     //output is
     //I'm a WinButton: Play
     //or
     //I'm a OSXButton: Play
 }
 ```

# Fluent interface

## Намерение

Това е патърн, който цели да напарви по-четим API. Имплементира се чрез method cascading.

## Пример
```
// Defines the data context
class Context
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Address { get; set; }
}

class Customer
{
    private Context context = new Context(); // Initializes the context

    // set the value for properties
    public Customer FirstName(string firstName)
    {
        context.FirstName = firstName;
        return this;
    }

    public Customer LastName(string lastName)
    {
        context.LastName = lastName;
        return this;
    }

    public Customer Sex(string sex)
    {
        context.Sex = sex;
        return this;
    }

    public Customer Address(string address)
    {
        context.Address = address;
        return this;
    }

    // Prints the data to console
    public void Print()
    {
        Console.WriteLine("First name: {0} \nLast name: {1} \nSex: {2} \nAddress: {3}", context.FirstName, context.LastName, context.Sex, context.Address);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Object creation
        Customer c1 = new Customer();
        // Using the method chaining to assign & print data with a single line
        c1.FirstName("vinod").LastName("srivastav").Sex("male").Address("bangalore").Print();
    }
}
```