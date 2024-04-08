using System;
using System.Collections.Generic;
using System.Text;
using static Prototype.UserConstructor;

namespace Prototype
{
    class UseInterface
    {

        //[Fact]
        public void Test()
        {
            //var alice = new Person("Alice", new Address("Road", 1));
            //var bob = alice.DeepCopy();
            //bob.Address.HouseNumber = 2;

            //bob.Name = "Bob";

            //Assert.Equal("Alice", alice.Name);
            //Assert.Equal(1, alice.Address.HouseNumber);

            //Assert.Equal("Bob", bob.Name);
            //Assert.Equal("Road", bob.Address.StreetName);
            //Assert.Equal(2, bob.Address.HouseNumber);
        }
        public interface IDeepCopyable<out T>
        {
            T DeepCopy();
        }
        public record Address : IDeepCopyable<Address>
        {
            public Address()
            {

            }
            public Address(string streetName, int houseNumber)
            {
                StreetName = streetName;
                HouseNumber = houseNumber;
            }

            public string StreetName { get; set; }
            public int HouseNumber { get; set; }
            public Address (Address address)
            {
                StreetName = address.StreetName;
                HouseNumber = address.HouseNumber;
            }
            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }
        }
        public record Person : IDeepCopyable<Person>
        {
            public Person()
            {
            }

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
            public Address Address { get; set; }

            public Person DeepCopy()
            {
                return new Person(Name, Address.DeepCopy());
            }
        }
    }
   
}

    



