namespace tech_test_payment_api.Presentation.Tests.Integration.Endpoints;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Extensions;
using Shouldly;
using Xunit;


public class VendaEndpointTests
{
    private static readonly ApiApplication Application = new();

    [Fact]
    public async Task GetVendas_ShouldReturn_Ok()
    {

        // Arrange
        using var client = Application.CreateClient();
        var id = Guid.NewGuid();

        // Act
        using var response = await client.GetAsync($"/api/vendas/{id}");
        var result = (await response.Content.ReadAsStringAsync());

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

    }

    [Fact]
    public async Task CreateVendas_ShouldReturn_Ok()
    {

        // Arrange
        using var client = Application.CreateClient();

        var json = (new { }).Serialize();
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        using var response = await client.PostAsync("/api/vendas", content);
        var result = (await response.Content.ReadAsStringAsync()).Deserialize<Venda>();

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

    }


    [Fact]
    public async Task UpdateVenda_ShouldReturn_NoContent()
    {
        // Arrange
        using var client = Application.CreateClient();
        var json = (new { }).Serialize();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var id = Guid.NewGuid();

        // Act
        using var response = await client.PutAsync($"/api/vendas/{id}", content);
        var result = (await response.Content.ReadAsStringAsync()).Deserialize<Venda>();

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

    }

}
