namespace IMSProject.Client.Services.COFService
{
    public interface ICOFService
    {
        List<COFmodel> COFmodels{ get; set; }

        Task GetCOF();

        Task<COFmodel> GetCOFById(int id);

        Task CreateCOF(COFmodel cOFmodel);

        Task UpdateCOF(COFmodel cOFmodel);

        Task DeleteCOF(int id);
    }
}
