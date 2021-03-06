﻿using System;

namespace Contoso.Shop.Api.Catalog.Dtos
{
    public class DepartamentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }
    }
}