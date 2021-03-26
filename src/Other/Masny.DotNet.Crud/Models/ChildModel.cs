using Masny.DotNet.Crud.Enums;
using System;

namespace Masny.DotNet.Crud.Models
{
    public class ChildModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public ParentModel ParentModel { get; set; }

        public int IntVar { get; set; }

        public int? IntNullVar { get; set; }

        public double DoubleVar { get; set; }

        public string StringVar { get; set; }

        public string StringNullVar { get; set; }

        public float FloatVar { get; set; }

        public decimal DecimalVar { get; set; }

        public char CharVar { get; set; }

        public bool BoolVar { get; set; }

        public EnumType EnumType { get; set; }

        public DateTime DateVar { get; set; }

        public DateTime DateTimeVar { get; set; }
    }
}
