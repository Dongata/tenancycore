using System;

namespace Models.Abstractions
{
    public abstract class BaseDomainEntity
    {
        /// <summary>
        /// Ef pruposes only
        /// </summary>
        protected BaseDomainEntity() { }

        public BaseDomainEntity(Guid id, DateTime createdOn, string createdBy)
        {
            Id = id;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
        }

        public BaseDomainEntity(Guid id, string createdBy)
        {
            Id = id;
            CreatedOn = DateTime.Now;
            CreatedBy = createdBy;
        }

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; protected set; }

        public string CreatedBy { get; protected set; }

        public DateTime? UpdateOn { get; set; }

        public string UpdateBy { get; set; }
    }
}
