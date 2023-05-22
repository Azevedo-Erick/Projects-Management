using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Seeds;

public class TagSeed
{

    public static List<Tag> GetTags()
    {
        var tags = new List<Tag>();

        tags.Add(new Tag
        {
            Id = 1,
            Title = "Backend",
            HexColor = "#4CAF50"
        });

        tags.Add(new Tag
        {
            Id = 2,

            Title = "Frontend",
            HexColor = "#2196F3"
        });

        tags.Add(new Tag
        {
            Id = 3,

            Title = "Erro",
            HexColor = "#F44336"
        });

        tags.Add(new Tag
        {
            Id = 4,

            Title = "Dúvida",
            HexColor = "#FFC107"
        });

        tags.Add(new Tag
        {
            Id = 5,

            Title = "Mobile",
            HexColor = "#FF9800"
        });

        tags.Add(new Tag
        {
            Id = 6,

            Title = "Database",
            HexColor = "#673AB7"
        });

        tags.Add(new Tag
        {
            Id = 7,

            Title = "Security",
            HexColor = "#9C27B0"
        });

        tags.Add(new Tag
        {
            Id = 8,

            Title = "Debugging",
            HexColor = "#009688"
        });

        tags.Add(new Tag
        {
            Id = 9,

            Title = "Deployment",
            HexColor = "#795548"
        });

        tags.Add(new Tag
        {
            Id = 10,

            Title = "Documentation",
            HexColor = "#607D8B"
        });

        tags.Add(new Tag
        {
            Id = 11,

            Title = "Performance",
            HexColor = "#E91E63"
        });

        tags.Add(new Tag
        {
            Id = 11,

            Title = "Accessibility",
            HexColor = "#3F51B5"
        });

        tags.Add(new Tag
        {
            Id = 12,

            Title = "Testing",
            HexColor = "#00BCD4"
        });

        return tags;
    }
}
