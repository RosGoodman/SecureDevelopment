namespace SecureDev.HomeWork.DAL.Models
{
    /// <summary> Интерфейс карты для использования в репоозитории. </summary>
    public interface ICardEntity
    {
        //интерфейс добавлен для меньшей связанности в репозитории
        //т.к. в данный момент тут только номер карты то и проверка наличия в БД 
        //производится только по номеру.
        //при желании интерфейс можно расширять

        /// <summary> Номер карты. </summary>
        public long NumbCard { get; set; }
    }
}
