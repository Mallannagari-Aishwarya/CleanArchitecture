using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using cleanteeh.Domain.Exceptions;
using cleanTeeth.domain.Enums;
using cleanTeeth.Domain.valueObjects;

namespace cleanTeeth.Domain.Entities{
    public class Appointment{
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public Guid DentistId { get; private set; }
        public Guid DentalOfficeId { get; private set; }
        public AppointmentStatus Status{get; private set;}
        public TimeInterval TimeInterval{get;private set;}
        public Patient? Patient { get; private set; }
        public Dentist? Dentist { get; private set; }
        public DentalOffice? DentalOffice { get; private set; }

        public Appointment(Guid patientId,Guid dentistId,Guid dentalOfficeId,TimeInterval timeInterval)
        {
            if (TimeInterval.Start < DateTime.UtcNow)
            {
                throw new Exception($"The start time connot be in the past");
            }
            
            PatientId = patientId;
            DentistId = dentistId;
            DentalOfficeId = dentalOfficeId;
            TimeInterval=timeInterval;
            Status = AppointmentStatus.Scheduled;
            Id = Guid.CreateVersion7();

        }
        public void Cancel()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only Scheduled appointments can be Cancelled");
            }
            Status=AppointmentStatus.Cancelled;
            
        }

        public void Complete()
        {
            if (Status != AppointmentStatus.Scheduled)
            {
                throw new BusinessRuleException("Only scheduled Appointments can be completed");
            }
            Status=AppointmentStatus.Completed;
        }

    }
}