using System;

public interface ICharacter
{
    // Property
    string Name { get; set; }

    // Event
    event Action OnDeath;

    // Method
    void Interact(int amount);
}
