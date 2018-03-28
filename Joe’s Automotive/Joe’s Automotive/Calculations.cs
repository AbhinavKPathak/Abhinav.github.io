using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Joe_s_Automotive
{
    class Calculations : INotifyPropertyChanged
    {
        private const decimal OIL_CHANGE_CHARGE = 26;
        private const decimal LUBE_JOB_CHARGE = 18;
        private const decimal RADIATOR_FLUSH_CHARGE = 30;
        private const decimal TRANSMISSION_FLUSH_CHARGE = 80;
        private const decimal INSPECTION_CHARGE = 15;
        private const decimal MUFFLER_REPLACEMENT_CHARGE = 100;
        private const decimal TIRE_ROTATION_CHARGE = 20;
        private const decimal LABOUR_CHARGE_PER_HOUR = 20;
        private const decimal SALES_TAX_ON_PARTS = 0.06M;

        public decimal TotalCharge;

        //Stores all individual charges in total.
        public ObservableCollection<string> Bill = new ObservableCollection<string>();

        public decimal LaborCharge=0;
        public decimal LaborCharges
        {
            get { return LaborCharge; }
            set
            {
                LaborCharge = value;
                NotifyChanged();
            }
        }

        private decimal PartsCharge=0;
        public decimal PartsCharges
        {
            get { return PartsCharge; }
            set
            {
                PartsCharge = value;
                NotifyChanged();
            }
        }

        //Sets a boolean to indicate status of checkbox.
        private Boolean Oil_Change_Checked;
        public Boolean OilChange
        {
            get { return Oil_Change_Checked; }
            set
            {
                if (Oil_Change_Checked != value)
                    Oil_Change_Checked = value;
                NotifyChanged();
            }
        }

        private Boolean Lube_Job_Checked;
        public Boolean LubeJob
        {
            get { return Lube_Job_Checked; }
            set
            {
                if (Lube_Job_Checked != value)
                    Lube_Job_Checked = value;
                NotifyChanged();
            }

        }

        private Boolean Radiator_Flush_Checked;
        public Boolean RadiatorFlush
        {
            get { return Radiator_Flush_Checked; }
            set
            {
                if (Radiator_Flush_Checked != value)
                    Radiator_Flush_Checked = value;
                NotifyChanged();
            }

        }

        private Boolean Transmission_Flush_Checked;
        public Boolean TransmissionFlush
        {
            get { return Transmission_Flush_Checked; }
            set
            {
                if (Transmission_Flush_Checked != value)
                    Transmission_Flush_Checked = value;
                NotifyChanged();
            }

        }

        private Boolean Inspection_Checked;
        public Boolean Inspection
        {
            get { return Inspection_Checked; }
            set
            {
                if (Inspection_Checked != value)
                    Inspection_Checked = value;
                NotifyChanged();
            }

        }
        private Boolean Muffler_Replacement_Checked;
        public Boolean MufflerReplacement
        {
            get { return Muffler_Replacement_Checked; }
            set
            {
                if (Muffler_Replacement_Checked != value)
                    Muffler_Replacement_Checked = value;
                NotifyChanged();
            }

        }

        private Boolean Tire_Rotation_Checked;
        public Boolean TireRotation
        {
            get { return Tire_Rotation_Checked; }
            set
            {
                if (Tire_Rotation_Checked != value)
                    Tire_Rotation_Checked = value;
                NotifyChanged();
            }

        }

        //Calculates total charges.
        public decimal TotalCharges()
        {
            Bill.Add("\t\t\t\tBreakdown Of Charges");
            Bill.Add("============================================================");
            TotalCharge += OilLubeCharges();
            TotalCharge += FlushCharges();
            TotalCharge += MiscCharges();
            TotalCharge += OtherCharges();
            TotalCharge += TaxCharges();

            return TotalCharge;
        }

        //Returns the total charges for an oil change and/or a lube job, if any. 
        private decimal OilLubeCharges()
        {
            if (Oil_Change_Checked && Lube_Job_Checked)
            {
                Bill.Add("Oil Change : " + OIL_CHANGE_CHARGE.ToString("c"));
                Bill.Add("Lube Job : " + LUBE_JOB_CHARGE.ToString("c"));
                return OIL_CHANGE_CHARGE + LUBE_JOB_CHARGE;
            }
            else if (Oil_Change_Checked)
            {
                Bill.Add("Oil Change : " + OIL_CHANGE_CHARGE.ToString("c"));
                return OIL_CHANGE_CHARGE;
            }
            else if (Lube_Job_Checked)
            {
                Bill.Add("Lube Job : " + LUBE_JOB_CHARGE.ToString("c"));
                return LUBE_JOB_CHARGE;
            }
            else
                return 0;
        }

        //Returns the total charges for a radiator flush and/or a transmission flush, if any. 
        private decimal FlushCharges()
        {
            if (Radiator_Flush_Checked && Transmission_Flush_Checked)
            {
                Bill.Add("Radiator Flush : " + RADIATOR_FLUSH_CHARGE.ToString("c"));
                Bill.Add("Transmission Flush : " + TRANSMISSION_FLUSH_CHARGE.ToString("c"));
                return RADIATOR_FLUSH_CHARGE + TRANSMISSION_FLUSH_CHARGE;
            }
            else if (Radiator_Flush_Checked)
            {
                Bill.Add("Radiator Flush : " + RADIATOR_FLUSH_CHARGE.ToString("c"));
                return RADIATOR_FLUSH_CHARGE;
            }
            else if (Transmission_Flush_Checked)
            {
                Bill.Add("Transmission Flush : " + TRANSMISSION_FLUSH_CHARGE.ToString("c"));
                return TRANSMISSION_FLUSH_CHARGE;
            }
            else
                return 0;
        }

        // Returns the total charges for an inspection, muffler replacement, and/or a tire replacement, if any. 
        private decimal MiscCharges()
        {
            if (Inspection_Checked && Muffler_Replacement_Checked && Tire_Rotation_Checked)
            {
                Bill.Add("Inspection : " + INSPECTION_CHARGE.ToString("c"));
                Bill.Add("Muffler Replacement : " + MUFFLER_REPLACEMENT_CHARGE.ToString("c"));
                Bill.Add("Tire Rotation : " + TIRE_ROTATION_CHARGE.ToString("c"));
                return INSPECTION_CHARGE + MUFFLER_REPLACEMENT_CHARGE + TIRE_ROTATION_CHARGE;
            }
            else if (Inspection_Checked && Muffler_Replacement_Checked)
            {
                Bill.Add("Inspection : " + INSPECTION_CHARGE.ToString("c"));
                Bill.Add("Muffler Replacement : " + MUFFLER_REPLACEMENT_CHARGE.ToString("c"));
                return INSPECTION_CHARGE + MUFFLER_REPLACEMENT_CHARGE;
            }
            else if (Muffler_Replacement_Checked && Tire_Rotation_Checked)
            {
                Bill.Add("Muffler Replacement : " + MUFFLER_REPLACEMENT_CHARGE.ToString("c"));
                Bill.Add("Tire Rotation : " + TIRE_ROTATION_CHARGE.ToString("c"));
                return MUFFLER_REPLACEMENT_CHARGE + TIRE_ROTATION_CHARGE;
            }
            else if (Inspection_Checked && Tire_Rotation_Checked)
            {
                Bill.Add("Inspection : " + INSPECTION_CHARGE.ToString("c"));
                Bill.Add("Tire Rotation : " + TIRE_ROTATION_CHARGE.ToString("c"));
                return INSPECTION_CHARGE + TIRE_ROTATION_CHARGE;
            }
            else if (Inspection_Checked)
            {
                Bill.Add("Inspection : " + INSPECTION_CHARGE.ToString("c"));
                return INSPECTION_CHARGE;
            }
            else if (Muffler_Replacement_Checked)
            {
                Bill.Add("Muffler Replacement : " + MUFFLER_REPLACEMENT_CHARGE.ToString("c"));
                return MUFFLER_REPLACEMENT_CHARGE;
            }
            else if (Tire_Rotation_Checked)
            {
                Bill.Add("Tire Rotation : " + TIRE_ROTATION_CHARGE.ToString("c"));
                return TIRE_ROTATION_CHARGE;
            }
            else
                return 0;
        }

        //Returns the total charges for other services (parts and labor, if any) 
        private decimal OtherCharges()
        {
            LaborCharge *= LABOUR_CHARGE_PER_HOUR;
            if (PartsCharge > 0 && LaborCharge > 0)
            {
                Bill.Add("Parts : " + PartsCharge.ToString("c"));
                Bill.Add("Labor : " + LaborCharge.ToString("c"));
                return PartsCharge + LaborCharge;
            }
            else if (PartsCharge > 0)
            {
                Bill.Add("Parts : " + PartsCharge.ToString("c"));
                return PartsCharge;
            }
            else if (LaborCharge > 0)
            {
                Bill.Add("Labor : " + LaborCharge.ToString("c"));
                return LaborCharge;
            }
            else
                return 0;
        }

        // Returns the amount of sales tax on parts, if any.  
        public decimal TaxCharges()
        {
            if (PartsCharge > 0)
            {
                return PartsCharge * SALES_TAX_ON_PARTS;
            }
            else
                return 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
