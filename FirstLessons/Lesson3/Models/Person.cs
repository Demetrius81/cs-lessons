using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3;
internal class Person
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public DateTime BirthDay { get; init; }
    public Gender Gender { get; init; }

    public Person(string name, string lastName, DateTime birthDay, Gender gender)
    {
        Name = name;
        LastName = lastName;
        BirthDay = birthDay;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"{Name} {LastName}, {Gender} - {BirthDay}";
    }
}
internal class FamilyMember : Person
{
    public FamilyMember Mother { get; set; } = null!;
    public FamilyMember Father { get; set; } = null!;
    public List<FamilyMember> Childs { get; set; }

    public FamilyMember(string name, string lastName, DateTime birthDay, Gender gender) : base(name, lastName, birthDay, gender)
    {
        Childs = new List<FamilyMember>();
    }

    public void SetParents(FamilyMember father, FamilyMember mother)
    {
        this.Father = father;
        this.Mother = mother;
    }

    public void AddChild(FamilyMember child)
    {
        Childs.Add(child);
    }

    public void RemoveChild(FamilyMember child)
    {
        Childs.Remove(child);
    }

    public void printFamily()
    {
        Console.WriteLine(this.ToString());

        Console.WriteLine("Mother:");
        Console.WriteLine(Mother is null ? "None" : Mother.ToString());

        Console.WriteLine("Father:");
        Console.WriteLine(Father is null ? "None" : Father.ToString());

        Console.WriteLine("Brothers:");

        if (Childs is not null && Childs.Count > 1)
        {
            foreach (FamilyMember child in Childs)
            {
                if (child.Gender == Gender.Male)
                {
                    Console.WriteLine(child is null ? "None" : child.ToString());
                }
            }

            Console.WriteLine("Sisters:");

            foreach (FamilyMember child in Childs)
            {
                if (child.Gender == Gender.Female)
                {
                    Console.WriteLine(child is null ? "None" : child.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("None");
        }

        Console.WriteLine("Grandmothers:");
        Console.WriteLine(Father.Mother is not null ? Father.Mother.ToString() : "None");
        Console.WriteLine(Mother.Mother is not null ? Mother.Mother.ToString() : "None");

        Console.WriteLine("Grandfathers:");
        Console.WriteLine(Father.Father is not null ? Father.Father.ToString() : "None");
        Console.WriteLine(Mother.Father is not null ? Mother.Father.ToString() : "None");
    }

    public void printPerson(FamilyMember person)
    {
        person.ToString();

        if (person.Childs.Count > 0)
        {
            foreach (FamilyMember child in person.Childs)
            {
                printPerson(child);
            }
        }
    }
}
