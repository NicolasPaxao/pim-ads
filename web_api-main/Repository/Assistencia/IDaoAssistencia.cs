using web_api.Models;

namespace web_api.Repository.Assistencia
{
    public interface IDaoAssistencia
    {
        List<AssistenciaModel> GetAllAssistencias();
        string PostAssistencia(AssistenciaModel assistencia);

        public void PutAssistencia(AssistenciaModel assistencia);

        public void DeleteAssistencia(int id);
    }
}
