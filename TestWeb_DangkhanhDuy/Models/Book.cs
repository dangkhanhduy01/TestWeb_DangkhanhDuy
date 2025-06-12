using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb_DangkhanhDuy.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string TenSach { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string TacGia { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double GiaBia { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SoLuong { get; set; }
    }
}

