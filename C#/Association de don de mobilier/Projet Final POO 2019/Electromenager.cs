﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final_POO_2019
{
    [Serializable]
    abstract class Electromenager:Objet_Volumineux
    {
        protected Electromenager(double hauteur,double largeur,double longueur, string description) : base(hauteur,largeur,longueur,description)
        {
        }
    }
}
