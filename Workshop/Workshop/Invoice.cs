using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Workshop
{
    public class Invoice : INotifyPropertyChanged
    {
        public List<WorkshopEntity> WorkshopsList { get; set; }
        public List<LocationEntity> LocationList { get; set; }

        private LocationEntity _location;
        private WorkshopEntity _workshop;
        private string _total;
        public string TotalString;

        public WorkshopEntity Workshop
        {
            get
            {
                return _workshop;
            }
            set
            {
                this._workshop = value;
                this.Total = GetTotal();
                propertyChanged();
            }
        }
        public LocationEntity Location
        {
            get
            {
                return _location;
            }
            set
            {
                this._location = value;
                this.Total = GetTotal();
                propertyChanged();
            }
        }

        public Invoice()
        {
            this.Total = this.GetTotal();
        }

        public string Total
        {
            get { return _total; }
            set { _total = value; propertyChanged(); }
        }

        public string GetTotal()
        {
            if (this._workshop != null && this._location == null)
            {
                return (_workshop.Fees).ToString();
            }
            else if (this._location != null && this._workshop == null)
            {
                return this._location.LodgingFees.ToString();
            }
            else if (this._workshop == null || this._location == null)
            {
                return "";
            }
            else
            {
                return ((_workshop.Duration * _location.LodgingFees) + _workshop.Fees).ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

