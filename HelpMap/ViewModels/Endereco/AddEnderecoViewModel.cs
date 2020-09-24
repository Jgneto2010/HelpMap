﻿using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.ViewModels
{
    public class AddEnderecoViewModel
    {
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string PontoReferencia { get; set; }
        public double Latidude { get; set; }
        public double Longitude { get; set; }
    }
}
