﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
	public class Prescription
	{
        public Prescription()
        {
            PrescriptionMedicament = new HashSet<PrescriptionMedicament>();
        }

        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public Patient Patient { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<PrescriptionMedicament> PrescriptionMedicament { get; set; }
    }
}
