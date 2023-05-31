using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;
using System.ComponentModel.DataAnnotations;

namespace PatronRepositorio.Dtos
{
    public class FinancialDataDto
    {
        public double SumOfVenta { get; set; }
        public double SumOfCoste { get; set; }
        public double SumOfDiference { get; set; }
        public double SumOfNumbers { get; set; }
    }
}
