using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lesson1.SQL_Injecrion.DAL.Models
{
    public class Card : ICardEntity
    {
        public int Id { get; set; }
        public long NumbCard { get; set; }
        public int CVV_CVC { get; set; }
        public string CardOwner { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Validity { get; set; }
    }
}
