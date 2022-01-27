using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SecureDev.HomeWork.DAL.Models
{
    /// <summary> Модель банковской карты. </summary>
    public class Card : ICardEntity
    {
        /// <summary> ID карты в БД. </summary>
        public int Id { get; set; }
        /// <summary> Номер карты. </summary>
        public long NumbCard { get; set; }
        /// <summary> Проверочный код. </summary>
        public int CVV_CVC { get; set; }
        /// <summary> Держатель карты. </summary>
        public string CardOwner { get; set; }

        /// <summary> Дата окончания действия карты. </summary>
        [BindProperty]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Validity { get; set; }
    }
}
