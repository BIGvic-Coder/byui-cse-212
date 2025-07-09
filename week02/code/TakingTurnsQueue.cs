using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public int TurnsRemaining { get; set; } // Track remaining turns
  public int Turns { get; } // <-- what the tests are expecting

    public Person(string name, int turns)
    {
        Name = name;
        TurnsRemaining = turns;
        Turns = turns;
    }

    public bool HasInfiniteTurns()
    {
        return Turns <= 0;
    }
}

public class TakingTurnsQueue
{
    private Queue<Person> queue = new Queue<Person>();

    public int Length => queue.Count;

    public void AddPerson(string name, int turns)
    {
        queue.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = queue.Dequeue();
        var returnCopy = new Person(person.Name, person.TurnsRemaining); // Copy for test assertions

        // Decrease turn if not infinite
        if (!person.HasInfiniteTurns())
        {
            person.TurnsRemaining--;
        }

        // Re-enqueue if still has turns or is infinite
        if (person.HasInfiniteTurns() || person.TurnsRemaining > 0)
        {
            queue.Enqueue(person);
        }

        return returnCopy;
    }
}
