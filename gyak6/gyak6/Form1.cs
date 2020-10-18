using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyak6
{
    public partial class Form1 : Form
    {
        var mnbService = new MNBArfolyamServiceSoapClient();
        public Form1()
        {
            InitializeComponent();
        }
        var request = new GetExchangeRatesRequestBody()
        {
            currencyNames = "EUR",
            startDate = "2020-01-01",
            endDate = "2020-06-30"
        };
        var response = mnbService.GetExchangeRates(request);
        var result = response.GetExchangeRatesResult;
    }
}
