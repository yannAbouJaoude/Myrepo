﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    class Refrigerateur:Electromenager
    {
        public Refrigerateur(double hauteur, double largeur, double longueur, string description) : base(hauteur, largeur, longueur, description)
        {

        }
    }
}