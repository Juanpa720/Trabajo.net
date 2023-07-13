﻿using Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Consumable
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public bool Disponible { get; internal set; }

        public Consumable(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        override public string ToString()
        {
            Func<string,string> upperCase = texto => texto.ToUpper();

            return Name + ": " + Price + ", Cantidad: " + Quantity;
        }
    }
}