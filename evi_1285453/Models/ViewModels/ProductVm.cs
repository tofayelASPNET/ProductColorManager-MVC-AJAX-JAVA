using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace evi_1285453.Models.ViewModels
{
    public class ProductVm
    {
        public ProductVm()
        {
            this.Details = new List<Details>();
        }
        public int PId { get; set; }
        [Required, DisplayName("Product Name")]
        public string PName { get; set; }
        public int Price { get; set; }
        public bool IsAviable { get; set; }
        public DateTime Pdate { get; set; }
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public virtual List<Details> Details { get; set; }
    }
}