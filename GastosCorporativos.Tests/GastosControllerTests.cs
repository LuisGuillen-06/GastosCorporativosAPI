using API.Controllers;
using Domain.Entities;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GastosCorporativos.Tests
{
    public class GastosControllerTests
    {
        [Fact]
        public async Task Retornar200Ok_ListaGastos()
        {
            var mockRepo = new Mock<IGastoRepository>();

            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Gasto>
                {
                    new Gasto {Descripcion = "Prueba 1", Monto = 200 },
                    new Gasto {Descripcion = "Prueba 2", Monto = 300 }
                });

            var controller = new GastosController(mockRepo.Object);

            var resultado = await controller.ObtenerTodos();

            var OkResult = Assert.IsType<OkObjectResult>(resultado);

            var listaDevuelta = Assert.IsAssignableFrom<IEnumerable<GastoDTO>>(OkResult.Value);

            Assert.Equal(2,listaDevuelta.Count());  
        }
        
       
        
    }
}
