using DAL.Repository_Interfaces;

namespace DAL.UnitOfWork
{
    internal class UnitOfWork:IUnitOfWork, IDisposable
    {
        private readonly SightseeingdbContext _context;

        private IGuideRepository _guideRepository;
        private IGuideTourRepository _guideTourRepository;
        private IReviewRepository _reviewRepository;
        private IRoleRepository _roleRepository;
        private ISightRepository _sightRepository;
        private ITicketRepository _ticketRepository;
        private ITourRepository _tourRepository;
        private ITourSightRepository _tourSightRepository;
        private IUserRepository _userRepository;
        private bool _disposed;

        public UnitOfWork(SightseeingdbContext context)
        {
            _context = context;
        }

        public IGuideRepository Guides { get { return _guideRepository; } }
        public IGuideTourRepository GuideTours { get { return _guideTourRepository;} }
        public IReviewRepository Reviews { get { return _reviewRepository; } }
        public IRoleRepository Roles { get { return _roleRepository;} }
        public ISightRepository Sights { get { return _sightRepository;} }
        public ITicketRepository Tickets { get { return _ticketRepository;} }
        public ITourRepository Tours { get { return _tourRepository;} }
        public ITourSightRepository TourSights { get { return _tourSightRepository;} }
        public IUserRepository Users { get { return _userRepository;} }

        public async Task SaveChangesAsync()
        {
                await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
