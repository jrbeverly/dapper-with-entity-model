using Dapper;
using EntityModel.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Npgsql;
using System.Threading.Tasks;

namespace EntityModel.Repositories
{
    public static class Keys
    {
        public sealed class Employee : EntityKey<Int64>
        {
            public Employee(Int64 key) : base(key)
            {
            }

            public static explicit operator Employee(System.Int64 v)
            {
                return new Employee(v);
            }
        }
    }

    public sealed class Employee : Entity<Keys.Employee, Models.Employee>
    {
        // "Construction" of the Entity from the resultant elements necessary
        public Employee(Int64 ID, String FirstName, String LastName, DateTime DateOfBirth)
        : base(new Keys.Employee(ID),
            new Models.Employee()
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth
            })
        {

        }
    }

    public static class Commands
    {
        public static class Employee
        {
            public static CommandDefinition GetByID(int id)
            {
                return new CommandDefinition("SELECT * FROM employee_getbyid_v1(@id)", new
                {
                    @ID = id,
                });
            }

            public static CommandDefinition GetByDateOfBirth(DateTime dateOfBirth)
            {

                return new CommandDefinition("SELECT * FROM employee_getbydateofbirth_v1(@dob)", new
                {
                    @dob = DateOnly.FromDateTime(dateOfBirth).ToShortDateString(),
                });
            }
        }
    }
}
