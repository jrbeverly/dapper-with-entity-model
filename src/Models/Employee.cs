using System;

namespace EntityModel.Models
{
    // Technically only an interface is necessary for this, to allow things like `IReadOnly`
    // or `IReadWriteEmployee` (monad) for these kinds of models
    //
    // ID & related primitives are excluded as they are "database" primitives
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
