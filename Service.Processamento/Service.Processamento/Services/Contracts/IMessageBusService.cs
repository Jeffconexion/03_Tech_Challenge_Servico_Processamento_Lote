namespace Service.Processamento.Services.Contracts
{
    public interface IMessageBusService
    {
        Task ProcessQueue(CancellationToken cancellationToken);
    }
}
