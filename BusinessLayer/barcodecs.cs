using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
  public   class barcodecs
    {
        public string generateBarcode()
        {
            try
            {
                string[] charPool = "1-2-3-4-5-6-7-8-9-0".Split('-');
                StringBuilder rs = new StringBuilder();
                int length = 10;
                Random rnd = new Random();
                while (length-- > 0)
                {
                    int index = (int)(rnd.NextDouble() * charPool.Length);
                    if (charPool[index] != "-")
                    {
                        rs.Append(charPool[index]);
                        charPool[index] = "-";
                    }
                    else
                        length++;
                }
                return rs.ToString();
            }
            catch (Exception ex)
            {
                //ErrorLog.WriteErrorLog("Barcode", ex.ToString(), ex.Message);
            }
            return "";
        }

        public Byte[] getBarcodeImage(string barcode, string file)
        {
            try
            {
                BarCode39 _barcode = new BarCode39();
              
               
                return (_barcode.Code39(barcode));
            }
            catch (Exception ex)
            {
                //ErrorLog.WriteErrorLog("Barcode", ex.ToString(), ex.Message);
            }
            return null;
        }
    }
}
