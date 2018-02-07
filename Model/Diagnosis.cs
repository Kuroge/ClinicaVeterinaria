using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum Severity
    {
        Serious, Moderate, Mild
    }
   public class Diagnosis
    {
        public Disease Disease { get; set; }

        public Severity? Severity { get; set; }
    }
}
