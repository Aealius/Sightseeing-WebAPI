using DAL.Repository_Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGuideRepository Guides { get; }
        IGuideTourRepository GuideTours { get; }
        IReviewRepository Reviews { get; }
        IRoleRepository Roles { get; }
        ISightRepository Sights { get; }
        ITicketRepository Tickets { get; }
        ITourRepository Tours { get; }
        ITourSightRepository TourSights { get; }
        IUserRepository Users { get; }

        Task SaveChangesAsync();
    }
}
