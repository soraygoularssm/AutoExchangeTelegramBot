using AutoTabadol.DataLayer.Repository;
using AutoTabadol.DataLayer.Repository.Json;
using AutoTabadol.DataLayer.Services;
using AutoTabadol.DataLayer.Services.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTabadol.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        AutoTabadol_DBEntities db = new AutoTabadol_DBEntities();

        private ICategoryRepository _CategoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_CategoryRepository == null)
                {
                    _CategoryRepository = new CategoryRepository(db);
                }

                return _CategoryRepository;
            }
        }

        private IUserAccountRepository _userAccountRepository;
        public IUserAccountRepository userAccountRepository
        {
            get
            {
                if (_userAccountRepository == null)
                {
                    _userAccountRepository = new UserAccountRepository(db);
                }
                return _userAccountRepository;
            }
        }

        private ITabRepository _tabRepository;
        public ITabRepository tabRepository
        {
            get
            {
                if (_tabRepository == null)
                {
                    _tabRepository = new TabRepository(db);
                }

                return _tabRepository;
            }
        }

        private IJsonRepositoryCategory _jsonCategory;
        public IJsonRepositoryCategory jsonCategory
        {
            get
            {
                if (_jsonCategory == null)
                {
                    _jsonCategory = new JsonRepositoryCategory(db);
                }

                return _jsonCategory;
            }
        }

        private ISameCategoryRepository _sameRepository;
        public ISameCategoryRepository sameRepository
        {
            get
            {
                if (_sameRepository == null)
                {
                    _sameRepository = new SameCategoryRepository(db);
                }

                return _sameRepository;
            }
        }


        private IJsonExchangedRepository _exchangedJsonRepository;
        public IJsonExchangedRepository exchangedJsonRepository
        {
            get
            {
                if (_exchangedJsonRepository == null)
                {
                    _exchangedJsonRepository = new JsonExchangedRepository(db);
                }

                return _exchangedJsonRepository;
            }
        }

        private GenericRepository<UserInfo_Table> _UserAccountRepository;
        public GenericRepository<UserInfo_Table> UserAccountRepository
        {
            get
            {
                if (_UserAccountRepository == null)
                {
                    _UserAccountRepository = new GenericRepository<UserInfo_Table>(db);
                }

                return _UserAccountRepository;
            }
        }

        private GenericRepository<Category_Table> _CategoriesRepository;
        public GenericRepository<Category_Table> CategoriesRepository
        {
            get
            {
                if (_CategoriesRepository == null)
                {
                    _CategoriesRepository = new GenericRepository<Category_Table>(db);
                }

                return _CategoriesRepository;
            }
        }

        private GenericRepository<Tab_Table> _TabRepository;
        public GenericRepository<Tab_Table> TabRepository
        {
            get
            {
                if (_TabRepository == null)
                {
                    _TabRepository = new GenericRepository<Tab_Table>(db);
                }

                return _TabRepository;
            }
        }

        private GenericRepository<SameCategory_Table> _SameRepository;
        public GenericRepository<SameCategory_Table> SameRepository
        {
            get
            {
                if (_SameRepository == null)
                {
                    _SameRepository = new GenericRepository<SameCategory_Table>(db);
                }

                return _SameRepository;
            }
        }

        private GenericRepository<CloseMember_Table> _CloseMamberRepository;
        public GenericRepository<CloseMember_Table> CloseMamberRepository
        {
            get
            {
                if (_CloseMamberRepository == null)
                {
                    _CloseMamberRepository = new GenericRepository<CloseMember_Table>(db);
                }

                return _CloseMamberRepository;
            }
        }

        private GenericRepository<Exchanged_Table> _ExchangedRepository;
        public GenericRepository<Exchanged_Table> ExchangedRepository
        {
            get
            {
                if (_ExchangedRepository == null)
                {
                    _ExchangedRepository = new GenericRepository<Exchanged_Table>(db);
                }

                return _ExchangedRepository;
            }
        }

        private GenericRepository<Admin_Table> _AdminRepository;
        public GenericRepository<Admin_Table> AdminRepository
        {
            get
            {
                if (_AdminRepository == null)
                {
                    _AdminRepository = new GenericRepository<Admin_Table>(db);
                }

                return _AdminRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
