﻿using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long idProduct)
        {
            var response = await _client.GetAsync($"{BasePath}/{idProduct}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<bool> DeleteProductById(long idProduct)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{idProduct}");
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API");
            return await response.ReadContentAs<bool>();
        }
    }
}
