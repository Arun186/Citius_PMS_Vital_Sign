using System;
using System.Collections.Generic;
using Vital_Repository.Dtos;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Threading.Tasks;

namespace Vital_Repository.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private VitalSignContext _context = null;
        private GenericRepository<Patient> _patientRepository;
        private GenericRepository<VitalSigns> _vitalRepository;
        private GenericRepository<Diagnosis> _diagnosisRepository;
        private GenericRepository<Pprocedure> _pprocedureRepository;
        private GenericRepository<Medication> _medicationRepository;
        private GenericRepository<PatientVisit> _patientVisitRepository;

        #endregion

        public UnitOfWork()
        {
            _context = new VitalSignContext();
        }

        #region Public Repository Creation properties...

        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new GenericRepository<Patient>(_context);
                }
                return _patientRepository;
            }
        }

        public GenericRepository<VitalSigns> VitalRepository
        {
            get
            {
                if (_vitalRepository == null)
                {
                    _vitalRepository = new GenericRepository<VitalSigns>(_context);
                }
                return _vitalRepository;
            }
        }
        public GenericRepository<PatientVisit> PatientVisitRepository
        {
            get
            {
                if (_patientVisitRepository == null)
                {
                    _patientVisitRepository = new GenericRepository<PatientVisit>(_context);
                }
                return _patientVisitRepository;
            }
        }
        public GenericRepository<Diagnosis> DiagnosisRepository
        {
            get
            {
                if (_diagnosisRepository == null)
                {
                    _diagnosisRepository = new GenericRepository<Diagnosis>(_context);
                }
                return _diagnosisRepository;
            }
        }
        public GenericRepository<Pprocedure> PprocudureRepository
        {
            get
            {
                if (_pprocedureRepository == null)
                {
                    _pprocedureRepository = new GenericRepository<Pprocedure>(_context);
                }
                return _pprocedureRepository;
            }
        }
        public GenericRepository<Medication> MedicationRepository
        {
            get
            {
                if (_medicationRepository == null)
                {
                    _medicationRepository = new GenericRepository<Medication>(_context);
                }
                return _medicationRepository;
            }
        }


        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);
                Debug.WriteLine("Errors : " + outputLines);
                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
