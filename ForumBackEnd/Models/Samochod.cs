using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumBackEnd.Models
{
    public class Samochod
    {
       public string color;
       public int wheels;
        
        public Samochod(string color,int wheels)
        {
            this.wheels = wheels;
            this.color = color;
        }
    }
}