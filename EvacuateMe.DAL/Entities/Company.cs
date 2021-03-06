﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace EvacuateMe.DAL.Entities
{
    [Table("companies", Schema = "public")]
    public class Company : Entity
    {          
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("contact_phone")]
        public string ContactPhone { get; set; }

        [Column("email")]
        public string EMail { get; set; }
        
        [Column("min_sum")]
        public double MinSum { get; set; }
        
        [Column("tariff")]
        public double Tariff { get; set; }

        [Column("sum_rate")]
        public int SumRate { get; set; }

        [Column("count_rate")]
        public int CountRate { get; set; }

        [Column("logo_url")]
        public string LogoUrl { get; set; }

        [Column("login")]
        public string Login { get; set; }
    
        [Column("password")]
        public string Password { get; set; }

        [Column("api_key")]
        public string ApiKey { get; set; }

        [Association(ThisKey = "Id", OtherKey = "CompanyId")]
        public IEnumerable<Worker> Workers { get; set; }
    }
}
