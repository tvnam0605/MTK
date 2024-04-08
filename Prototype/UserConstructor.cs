using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype
{
    class UserConstructor
    {
        //[Fact]
        public static void Test()
        {
            var alice = new Person("Alice", new Address("Road", 1));
            var bob = new Person(alice);
            //bob.Name = "Bob";

            Console.WriteLine("Alice Name="+alice.Name);
            Console.WriteLine("Bob Name="+ bob.Name);
            //var bob = new Person(alice)
            //{
            //    Name = "Bob"
            //};

            //Assert.Equal("Alice", alice.Name);
            //Assert.Equal("Bob", bob.Name);
            //Assert.Equal("Road", bob.Address.StreetName);
            //Assert.Equal(1, bob.Address.HouseNumber);
        }

        public class Address
        {
            private object address;

            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;


            }
            public Address(Address address)
            {
                StreetName = address.StreetName;
                HouseNumber = address.HouseNumber;
            }

            public Address(object address)
            {
                this.address = address;
            }

            public string StreetName { get; }
            public int HouseNumber { get; set; }

            internal Address DeepCopy()
            {
                throw new NotImplementedException();
            }
        }
        public class Person
        {
            public Person(string name, Address address)
            {
                Address = address;
                Name = name;
                
            }
            public Person(Person person)
            {
                Name = person.Name;
                Address = new Address(person.Address);
            }
            public string Name { get; set; }
            public Address Address { get; }
        }

    }
}
