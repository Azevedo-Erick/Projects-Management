using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Seeds;

public class PersonSeed
{

    public static List<Person> GetPersons()
    {
        List<Person> people = new List<Person>()
{
    new Person()
    {
        Id = 1,
        Name = "John Doe",
        Email = "johndoe@example.com",
        PasswordHash = "8c6976e5b5410415bde908bd4dee15dfb167a2c2",
        DateOfBirth = new DateTime(1990, 10, 15),
        ProfileImage = "https://example.com/profiles/johndoe.jpg"
    },
    new Person()
    {
        Id = 2,
        Name = "Jane Smith",
        Email = "janesmith@example.com",
        PasswordHash = "827ccb0eea8a706c4c34a16891f84e7b",
        DateOfBirth = new DateTime(1985, 5, 20),
        ProfileImage = "https://example.com/profiles/janesmith.jpg"
    },
    new Person()
    {
        Id = 3,
        Name = "Bob Johnson",
        Email = "bobjohnson@example.com",
        PasswordHash = "e10adc3949ba59abbe56e057f20f883e",
        DateOfBirth = new DateTime(2000, 1, 1),
        ProfileImage = "https://example.com/profiles/bobjohnson.jpg"
    },
    new Person()
    {
        Id = 4,
        Name = "Sarah Williams",
        Email = "sarahwilliams@example.com",
        PasswordHash = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8",
        DateOfBirth = new DateTime(1995, 7, 10),
        ProfileImage = "https://example.com/profiles/sarahwilliams.jpg"
    },
    new Person()
    {
        Id = 5,
        Name = "Mark Davis",
        Email = "markdavis@example.com",
        PasswordHash = "e6a3a7747d7b17b533b9e89b29a9d7c7f33e31b8",
        DateOfBirth = new DateTime(1988, 4, 1),
        ProfileImage = "https://example.com/profiles/markdavis.jpg"
    },
    new Person()
    {
        Id = 6,
        Name = "Karen Lee",
        Email = "karenlee@example.com",
        PasswordHash = "fcea920f7412b5da7be0cf42b8c93759",
        DateOfBirth = new DateTime(1993, 11, 30),
        ProfileImage = "https://example.com/profiles/karenlee.jpg"
    },
    new Person()
    {
        Id = 7,
        Name = "James Brown",
        Email = "jamesbrown@example.com",
        PasswordHash = "c81e728d9d4c2f636f067f89cc14862c",
        DateOfBirth = new DateTime(1975, 8, 5),
        ProfileImage = "https://example.com/profiles/jamesbrown.jpg"
    },new Person()
    {
        Id = 8,
        Name = "Alex Kim",
        Email = "alexkim@example.com",
        PasswordHash = "6d7fce9fee471194aa8b5b6e47267f03",
        DateOfBirth = new DateTime(1982, 1, 25),
        ProfileImage = "https://example.com/profiles/alexkim.jpg"
    },
    new Person()
    {
        Id = 9,
        Name = "Julia Hernandez",
        Email = "juliahernandez@example.com",
        PasswordHash = "202cb962ac59075b964b07152d234b70",
        DateOfBirth = new DateTime(1998, 3, 12),
        ProfileImage = "https://example.com/profiles/juliahernandez.jpg"
    },
    new Person()
    {
        Id = 10,
        Name = "Andrew Nguyen",
        Email = "andrewn@example.com",
        PasswordHash = "25f9e794323b453885f5181f1b624d0b",
        DateOfBirth = new DateTime(1989, 6, 20),
        ProfileImage = "https://example.com/profiles/andrewn.jpg"
    }
};
        return people;
    }
}
