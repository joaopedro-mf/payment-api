namespace tech_test_payment_api.Infrastructure.Tests.Integration.Fixture;
using System;
using System.Collections.Generic;
using Domain.Enum;
using Domain.Models;
using tech_test_payment_api.Infrastructure.Context;

internal static class DbContextExtensions
{
    public static PaymentDbContext AddTestData(this PaymentDbContext context)
    {
        var vendedores = new List<Vendedor>
        {
            new Vendedor { Id = Guid.NewGuid(), Cpf = "1111111111" , Email = "1", Telefone="telefone"},
            new Vendedor { Id = Guid.NewGuid(), Cpf = "22222222222" , Email = "2", Telefone="telefone" },
            new Vendedor { Id = Guid.NewGuid(), Cpf = "3333333333" , Email = "3", Telefone="telefone" }
        };

        context.Vendedores.AddRange(vendedores);

        var items = new List<Item>()
        {
            new Item { Id = Guid.NewGuid(), Descricao = "Item 1", Valor = 10 },
            new Item { Id = Guid.NewGuid(), Descricao = "Item 2", Valor = 20  },
            new Item { Id = Guid.NewGuid(), Descricao = "Item 3", Valor = 30 }
        };

        context.Items.AddRange(items);

        var vendas = new List<Venda>()
        {
            new Venda (items, vendedores[0]){ Id = Guid.NewGuid() },
            new Venda (items, vendedores[1]){ Id = Guid.NewGuid() },
            new Venda (items, vendedores[2]){ Id = Guid.NewGuid() }
        };

        context.Vendas.AddRange(vendas);

        _ = context.SaveChanges();

        return context;
    }
}
