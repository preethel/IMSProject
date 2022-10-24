namespace IMSProject.Client.Services.UnitService
{
    public interface IUnitService
    {
        List<Unit> Unit{ get; set; }

        Task GetUnits();

        Task<Unit> GetUnitById(int id);

        Task CreateUnit(Unit unit);

        Task UpdateUnit(Unit unit);

        Task RemoveUnit(Unit unit);

        Task DeleteUnit(int id);
    }
}
