﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

namespace EvacuateMe.DAL.Entities
{
    [Table("orders", Schema = "public")]
    public class Order : Entity
    {        
        [Column("client")]
        public int ClientId { get; set; }

        [Column("worker")]
        public int WorkerId { get; set; }

        [Column("start_client_lat")]
        public double StartClientLat { get; set; }

        [Column("start_client_long")]
        public double StartClientLong { get; set; }

        [Column("start_worker_lat")]
        public double StartWorkerLat { get; set; }

        [Column("start_worker_long")]
        public double StartWorkerLong { get; set; }

        [Column("beginning_time")]
        public DateTime BeginingTime { get; set; }

        [Column("termination_time")]
        public DateTime TerminationTime { get; set; }

        [Column("final_lat")]
        public double FinalLat { get; set; }

        [Column("final_long")]
        public double FinalLong { get; set; }

        [Column("car_model")]
        public string CarModel { get; set; }

        [Column("car_colour")]
        public string CarColour { get; set; }

        [Column("car_type")]
        public int CarTypeId { get; set; }

        [Column("summary")]
        public double Summary { get; set; }

        [Column("distance")]
        public double Distance { get; set; }

        [Column("rate")]
        public int Rate { get; set; }

        [Column("status")]
        public int StatusId { get; set; }

        public Client Client { get; set; }

        public Worker Worker { get; set; }

        public CarType CarType { get; set; }

        public OrderStatus Status { get; set; }
    }
}
