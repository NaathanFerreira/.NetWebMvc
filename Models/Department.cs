using System.Collections.Generic;
using System;
using System.Linq;

namespace WebMvc.Models {
    public class Department {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department(){} // construtor vazio

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // MÉTODOS
        public void AddSeller(Seller seller){
            Sellers.Add(seller);
        }

        public double TotalSales(DateTime initial, DateTime final){
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }

    }
}