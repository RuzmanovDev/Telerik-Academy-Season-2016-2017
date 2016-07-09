using AcademyRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
   public class ExtendedEngine :Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    string name = commandWords[2];
                    Point position = Point.Parse(commandWords[3]);
                    int owner = int.Parse(commandWords[4]);
                    this.AddObject(new Knight(name, position, owner));
                    break;

                case "house":
                    Point pos = Point.Parse(commandWords[2]);
                    int ow = int.Parse(commandWords[3]);

                    this.AddObject(new House(pos, ow));
                    break;

                case "giant":
                    Point p = Point.Parse(commandWords[3]);
                    this.AddObject(new Giant(commandWords[2], p));
                    break;

                case "rock":
                    int hp = int.Parse(commandWords[2]);
                    Point poss = Point.Parse(commandWords[3]);
                    this.AddObject(new Rock(hp, poss));
                    break;

                case "ninja":
                    string nameofNinja = commandWords[2];
                    Point posOfNinja = Point.Parse(commandWords[3]);
                    int ninjaOwner = int.Parse(commandWords[4]);
                    this.AddObject(new Ninja(nameofNinja, posOfNinja, ninjaOwner));
                    break;
                default: base.ExecuteCreateObjectCommand(commandWords);
                    break;
            }
        }
    }
}
