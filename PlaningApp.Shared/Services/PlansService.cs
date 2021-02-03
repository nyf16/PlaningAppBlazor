﻿using AKSoftware.WebApi.Client;
using PlaningApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaningApp.Shared.Services
{
    public class PlansService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public PlansService(string url)
        {
            _baseUrl = url;
        }

        public string AccessToken
        {
            get => client.AccessToken;
            set
            {
                client.AccessToken = value;
            }
        }

        /// <summary>
        /// Retrieve all the plans from the API with pagination
        /// </summary>
        /// <param name="page">Number of the page</param>
        /// <returns></returns>
        public async Task<PlansCollectionPagingResponse> GetAllPlansByPageAsync(int page = 1)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans?page={page}");
            return response.Result;
        }

        /// <summary>
        /// Return a Plan by ID
        /// </summary>
        /// <param name="page">ID of the plan to be retrieved</param>
        /// <returns></returns>
        public async Task<PlansCollectionPagingResponse> SearchPlansByPageAsync(string query, int page = 1)
        {
            var response = await client.GetProtectedAsync<PlansCollectionPagingResponse>($"{_baseUrl}/api/plans/search?query={query}&page={page}");
            return response.Result;
        }
    }
}
