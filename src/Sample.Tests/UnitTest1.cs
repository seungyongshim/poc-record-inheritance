using System;
using FluentAssertions;
using Xunit;

public record DtoInfo
{
    public string Header { get; init; } = "1";
}

public record Dto(string Body) : DtoInfo;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var dto = new Dto("Body");

        var m = dto switch
        {
            { Header: _ } => dto with { Header = "Header" },
            //DtoInfo x => x with { Header = "Header" },
        };

       
        m.Should().BeEquivalentTo(new
        {
                Header = "Header",
                Body = "Body",
        });
    }
}
