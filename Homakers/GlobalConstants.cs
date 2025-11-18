using Homakers.Applications.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homakers
{
    public class GlobalConstants
    {
        public static string? BaseAPIAddress { get; set; } = "https://homakerapi-dev-bjf4b3bsgkhndmgf.canadacentral-01.azurewebsites.net/";
        //public static string? BaseAPIAddress { get; set; } = "https://localhost:7269";
        public static string? CustomerID { get; set; }
        public static string? ProfessionalID { get; set; }
        public static List<DistrictsDto>? DistrictList { get; set; }
        public static List<ProfessionsDto>? ProfessionList { get; set; }
    }
}
