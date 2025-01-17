﻿using Product.Api.RabbitMq;
using Product.Api.Repositories;
using Product.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Product.Api.Entities.Dtos;
using Product.Api.Entities.Enums;

namespace Product.Api.Test
{
	public class MockTestingRepository
	{
		private readonly Mock<AppSettings> settings;
		private readonly Mock<SendToGetMessage> sendToGet;
		private readonly Mock<IProductRepository> productRepository;
		private readonly ProductRepository repository;
		public MockTestingRepository()
		{
			settings = new Mock<AppSettings>();
			sendToGet = new Mock<SendToGetMessage>();
			productRepository = new Mock<IProductRepository>();
			repository = new ProductRepository(settings.Object, sendToGet.Object);
		}

		[Fact]
		public async Task TestCreateProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			await repository.CreateProductAsync(dto);
			var product = await repository.GetProductAsync("Test");

			//Assert
			Assert.NotNull(product);
			Assert.Equal("Test", product.Name);
			Assert.Equal(1000, product.Price);
		}

		[Fact]
		public async Task TestDeleteProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			await repository.CreateProductAsync(dto);
			var product = await repository.GetProductAsync("Test");
			await repository.DeleteProductAsync(product.Id);

			var deleteproduct = await repository.GetProductAsync("Test");

			//Assert
			Assert.Null(deleteproduct);
		}

		[Fact]
		public async Task TestUpdateProductAsync()
		{
			var dto = new CreateProductDto()
			{
				Name = "Test",
				Price = 1000,
				Count = 2,
			};
			await repository.CreateProductAsync(dto);
			var product = await repository.GetProductAsync("Test");
			var updatedto = new UpdateProductDto()
			{
				Name = "Update",
				Price = 2000,
				Status = EProductStatus.Active,
			};
			await repository.UpdateProductAsync(product.Id,updatedto);

			var updateproduct = await repository.GetProductAsync(product.Id);

			//Assert
			Assert.NotNull(updateproduct);
			Assert.Equal(EProductStatus.Active, updateproduct.Status);
			Assert.Equal("Update",updateproduct.Name);
			Assert.Equal(2000, updateproduct.Price);
		}
	}
}
