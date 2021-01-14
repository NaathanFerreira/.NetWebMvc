namespace WebMvc.Models
{
    public enum SaleStatus : int
    {
        Pending = 0, // Pendente
        Billed = 1, // Faturado, Comprado
        Canceled = 2 // Cancelado
    }
}