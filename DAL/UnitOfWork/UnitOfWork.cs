using DAL.Repositories;
using DAL.Repository_Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SightseeingdbContext _context;

        private IGuideRepository? _guideRepository;
        private IGuideTourRepository? _guideTourRepository;
        private IReviewRepository? _reviewRepository;
        private IRoleRepository? _roleRepository;
        private ISightRepository? _sightRepository;
        private ITicketRepository? _ticketRepository;
        private ITourRepository? _tourRepository;
        private ITourSightRepository? _tourSightRepository;
        private IUserRepository? _userRepository;

        public UnitOfWork(SightseeingdbContext context)
        {
            _context = context;
        }

        public IGuideRepository Guides { 

            get  
            {
                _guideRepository ??= new GuideRepository(_context);
                return _guideRepository;
            }
        }
        public IGuideTourRepository GuideTours {

            get 
            {
                _guideTourRepository ??= new GuideTourRepository(_context);
                return _guideTourRepository;
            } 
        }
        public IReviewRepository Reviews {

            get 
            {
                _reviewRepository ??= new ReviewRepository(_context);
                return _reviewRepository; 
            } 
        }
        public IRoleRepository Roles {

            get
            {
                _roleRepository ??= new RoleRepository(_context);
                return _roleRepository;
            } 
        }
        public ISightRepository Sights {

            get
            {
                _sightRepository ??= new SightRepository(_context);
                return _sightRepository;
            } 
        }
        public ITicketRepository Tickets { 

            get 
            {
                _ticketRepository ??= new TicketRepository(_context);
                return _ticketRepository;
            } 
        }
        public ITourRepository Tours { 

            get 
            {
                _tourRepository ??= new TourRepository(_context);
                return _tourRepository;
            } 
        }
        public ITourSightRepository TourSights {

            get 
            {
                _tourSightRepository ??= new TourSightRepository(_context);
                return _tourSightRepository;
            }
        }
        public IUserRepository Users { 

            get 
            {
                _userRepository ??= new UserRepository(_context);
                return _userRepository;
            } 
        }

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
