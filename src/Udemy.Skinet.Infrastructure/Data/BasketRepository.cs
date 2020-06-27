﻿using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class BasketRepository : IBasketRepository {
        private readonly IDatabase _db;

        public BasketRepository(IConnectionMultiplexer redis) {
            _db = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId) {
            return await _db.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId) {
            var data = await _db.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket) {
            var created = await _db.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

            if (!created) {
                return null;
            }

            return await GetBasketAsync(basket.Id);
        }
    }
}
