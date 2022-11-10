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

        var json = (new { vendedor = new { cpf = "string", email = "string", telefone = "string" }, itemsVendidos = new[] { new { descricao = "string", valor = 0 } } }).Serialize();
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        using var responseArrange = await client.PostAsync("/api/venda", content);
        var resultArrange = (await responseArrange.Content.ReadAsStringAsync()).Deserialize<Venda>();

        // Act
        using var response = await client.GetAsync($"/api/venda/{resultArrange.Id}");
        var result = (await response.Content.ReadAsStringAsync()).Deserialize<Venda>();

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        _ = response.Content.ShouldNotBeNull();
    }

    [Fact]
    public async Task CreateVendas_ShouldReturn_Ok()
    {

        // Arrange
        using var client = Application.CreateClient();

        var json = (new { vendedor = new { cpf = "string", email = "string", telefone = "string" }, itemsVendidos = new[] { new { descricao = "string", valor = 0 } } }).Serialize();
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        using var response = await client.PostAsync("/api/venda", content);
        var result = (await response.Content.ReadAsStringAsync()).Deserialize<Venda>();

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        _ = response.Content.ShouldNotBeNull();

    }


    [Fact]
    public async Task UpdateVenda_ShouldReturn_NoContent()
    {
        // Arrange
        using var client = Application.CreateClient();

        var jsonArrange = (new { vendedor = new { cpf = "string", email = "string", telefone = "string" }, itemsVendidos = new[] { new { descricao = "string", valor = 0 } } }).Serialize();
        var contentArrangge = new StringContent(jsonArrange, Encoding.UTF8, "application/json");
        using var responseArrange = await client.PostAsync("/api/venda", contentArrangge);
        var resultArrange = (await responseArrange.Content.ReadAsStringAsync()).Deserialize<Venda>();

        var json = (new { statusVenda = 1 }).Serialize();
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        using var response = await client.PutAsync($"/api/venda/{resultArrange.Id}", content);
        var result = (await response.Content.ReadAsStringAsync()).Deserialize<bool>();

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

    }

}
