using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Ex1
{
    class Person
    {
        private string name;
        private int age;
        private string description;

        public string Name
        {
            get { return this.name; }
            set { this.name = value;}
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}

//Write a console application to create a text file and save your basic details like name, age, address 
//    ( use dummy data). Read the details from same file and print on console.