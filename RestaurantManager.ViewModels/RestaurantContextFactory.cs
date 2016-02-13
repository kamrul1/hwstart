﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public static class RestaurantContextFactory
    {
        private static RestaurantContext _restaurantContext;

        public static async Task<RestaurantContext> GetRestaurantContextAsync()
        {
            if (_restaurantContext == null)
            {
                _restaurantContext = new RestaurantContext();
                await _restaurantContext.InitializeContextAsync();
            }

            return _restaurantContext;
        }

    }
}
