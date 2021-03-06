﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace EvacuateMe.DAL.Entities
{
    [Table("clients", Schema = "public"),]
    public class Client : Entity
    {        
        [Column("name")]
        public string Name { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("api_key")]
        public string ApiKey { get; set; }

        [Column("car_model")]
        public string CarModel { get; set; }

        [Column("car_colour")]
        public string CarColour { get; set; }

        [Association(ThisKey = "Id", OtherKey = "ClientId")]
        public IEnumerable<Order> Orders { get; set; }

        public Client()
        {

        }

        public Client(Client client)
        {
            this.Id = client.Id;
            this.Name = client.Name;
            this.Phone = client.Phone;
            this.ApiKey = client.ApiKey;
            this.CarColour = client.CarColour;
            this.CarModel = client.CarModel;
        }
    }
}
